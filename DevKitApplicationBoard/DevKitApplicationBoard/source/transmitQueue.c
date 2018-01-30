/*
File:   transmitQueue.c
Author: Taylor Robbins
Date:   01\30\2018
Description: 
	** A service that provides easy management of packets that need to
	** be transmitted across the Sure-Fi radio. 
*/

#include "defines.h"
#include "transmitQueue.h"

#include "debug.h"
#include "sureCommands.h"
#include "sureResponses.h"
#include "tickTimer.h"

// +--------------------------------------------------------------+
// |              Private Structure/Type Definitions              |
// +--------------------------------------------------------------+
typedef struct
{
	u8 payloadSize;
	u8 payload[TRANSMIT_QUEUE_PAYLOAD_SIZE];
	TransmitFinishedCallback_f* callback;
} TxQueueItem_t;

typedef enum
{
	QueueState_Idle,
	QueueState_WaitingForSuccess,
	QueueState_WaitingForTxFinish,
	QueueState_WaitingForTxData,
} QueueState_t;

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
struct
{
	u8 numItems;
	TxQueueItem_t items[TRANSMIT_QUEUE_LENGTH];
} queue;

QueueState_t queueState = QueueState_Idle;
bool gotTransmitInfo = false;
TransmitInfo_t transmitInfoBuffer;
bool gotAckPacket = false;
u8 ackPacketLength = 0;
u8 ackPacketBuffer[MAX_UID_LENGTH + TRANSMIT_QUEUE_PAYLOAD_SIZE];

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static void PopItem(TransmitInfo_t* txInfo, u8 ackDataLength, u8* ackData)
{
	Assert(queue.numItems >= 1);
	
	TxQueueItem_t* item = &queue.items[0];
	if (item->callback != nullptr)
	{
		item->callback(item->payloadSize, item->payload, txInfo, ackDataLength, ackData);
	}
	else
	{
		WriteLine_D("Transmit finished with no callback");
	}
	
	//Shift all the items down by one
	u8 iIndex = 0;
	for (iIndex = 0; iIndex+1 < queue.numItems; iIndex++)
	{
		queue.items[iIndex] = queue.items[iIndex+1];
	}
	queue.numItems--;
}

static inline void ChangeQueueState(QueueState_t newState)
{
	// PrintLine_D("QueueState 0x%02X => 0x%02X", queueState, newState);
	TransmitQueueTimeout = TRANSMIT_QUEUE_TIMEOUT;
	queueState = newState;
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitTransmitQueue()
{
	ClearStruct(queue);
}

void UpdateTransmitQueue()
{
	switch (queueState)
	{
		case QueueState_WaitingForSuccess:
		{
			if (SureGotSuccess && SureSuccessCmd == SureCmd_TransmitData)
			{
				ChangeQueueState(QueueState_WaitingForTxFinish);
			}
			else if (SureGotFailure && SureFailureCmd == SureCmd_TransmitData)
			{
				PopItem(nullptr, 0, nullptr);
				ChangeQueueState(QueueState_Idle);
			}
		} break;
		
		case QueueState_WaitingForTxFinish:
		{
			if (SureGotTransmitFinished)
			{
				ChangeQueueState(QueueState_WaitingForTxData);
			}
		} break;
		
		case QueueState_WaitingForTxData:
		{
			if (SureGotTxInfo)
			{
				transmitInfoBuffer = SureTxInfo;
				gotTransmitInfo = true;
				
				if (transmitInfoBuffer.ackDataLength == 0)
				{
					gotAckPacket = true;
					ackPacketLength = 0;
				}
			}
			
			if (!gotAckPacket && SureGotAckPacket)
			{
				ackPacketLength = SureAckPacketLength;
				if (ackPacketLength > ArrayCount(ackPacketBuffer))
				{
					WriteLine_E("WARNING: ack data length was larger than transmit queue ack packet buffer");
					ackPacketLength = ArrayCount(ackPacketBuffer);
				}
				memcpy(ackPacketBuffer, SureAckPacket, ackPacketLength);
				gotAckPacket = true;
			}
			
			if (gotTransmitInfo && gotAckPacket)
			{
				PopItem(&transmitInfoBuffer, ackPacketLength, &ackPacketBuffer[0]);
				ChangeQueueState(QueueState_Idle);
				// Fall through to idle state handling
			}
			else
			{
				break;
			}
		}
		
		case QueueState_Idle:
		{
			if (queue.numItems > 0)
			{
				if (!SureModuleStatus.busy)
				{
					TxQueueItem_t* item = &queue.items[0];
					
					SureTransmitData(item->payloadSize, item->payload);
					
					SureGotSuccess = false;
					SureGotFailure = false;
					SureGotTransmitFinished = false;
					SureGotTxInfo = false;
					SureGotAckPacket = false;
					gotTransmitInfo = false;
					gotAckPacket = false;
					ChangeQueueState(QueueState_WaitingForSuccess);
				}
			}
		} break;
		
		
	}
	
	if (queueState != QueueState_Idle && TransmitQueueTimeout == 0)
	{
		WriteLine_E("WARNING: Transmit queue state machine timed out! Check that TRANSMIT_QUEUE_TIMEOUT is correct");
		PopItem(nullptr, 0, nullptr);
		ChangeQueueState(QueueState_Idle);
	}
}

bool TransmitQueuePush(u8 payloadSize, const u8* payload, TransmitFinishedCallback_f* callback)
{
	if (payloadSize > TRANSMIT_QUEUE_PAYLOAD_SIZE)
	{
		WriteLine_E("Payload too large for transmit queue. Try changing TRANSMIT_QUEUE_PAYLOAD_SIZE.");
		return false;
	}
	if (queue.numItems >= TRANSMIT_QUEUE_LENGTH)
	{
		WriteLine_E("Transmit queue is full!");
		return false;
	}
	
	TxQueueItem_t* item = &queue.items[queue.numItems];
	item->payloadSize = payloadSize;
	memcpy(item->payload, payload, payloadSize);
	item->callback = callback;
	queue.numItems++;
	
	return true;
}

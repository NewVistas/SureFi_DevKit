/*
File:   transmitQueue.h
Author: Taylor Robbins
Date:   01\30\2018
*/

#ifndef _TRANSMIT_QUEUE_H
#define _TRANSMIT_QUEUE_H

// +--------------------------------------------------------------+
// |                      Public Definitions                      |
// +--------------------------------------------------------------+
//NOTE: In order to save space we only store a buffer of 16 bytes for each item
//		on the transmit queue. Feel free to make this larger if needed by your application
#define TRANSMIT_QUEUE_PAYLOAD_SIZE 16 //bytes
//NOTE: This is the max number of transmits that can be pushed onto the queue.
#define TRANSMIT_QUEUE_LENGTH       8 //items
//NOTE: If you have packets that might take longer than this time you should increase this value
#define TRANSMIT_QUEUE_TIMEOUT      5000 //ms

// +--------------------------------------------------------------+
// |              Public Structure/Type Definitions               |
// +--------------------------------------------------------------+
typedef void TransmitFinishedCallback_f(u8 sentPayloadSize, const u8* sentPayload,
	const TransmitInfo_t* txInfo, u8 ackDataLength, const u8* ackData);

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitTransmitQueue();
void UpdateTransmitQueue();
bool TransmitQueuePush(u8 payloadSize, const u8* payload, TransmitFinishedCallback_f* callback);

#endif //  _TRANSMIT_QUEUE_H

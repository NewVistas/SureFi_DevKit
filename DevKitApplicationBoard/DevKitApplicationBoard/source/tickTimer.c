/*
File:   tickTimer.c
Author: Taylor Robbins
Date:   01\22\2018
Description: 
	** Handles initializing and handling the Timer Counter peripheral to be
	** used as a 1ms tick counter 
*/

#include "defines.h"
#include "tickTimer.h"

#include "micro.h"
#include "debug.h"

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
volatile u32 TickCounter = 0;

volatile u32 JumperDebounceCountdown = 0;
volatile u32 TransmitQueueTimeout = 0;
volatile u32 GenericCountdown[NUM_COUNTDOWN_TIMERS];

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitializeTickTimer()
{
	u8 tIndex; for (tIndex = 0; tIndex < NUM_COUNTDOWN_TIMERS; tIndex++)
	{
		GenericCountdown[tIndex] = 0;
	}
	
	/* Configure RTT for a 1 second tick interrupt */
	rtt_sel_source(RTT, false);
	rtt_init(RTT, 32); //TODO: Make this based of some other clock defines/variables?
	
	u32 prevTime = rtt_read_timer_value(RTT);
	while (prevTime == rtt_read_timer_value(RTT));
	
	/* Enable RTT interrupt */
	NVIC_DisableIRQ(RTT_IRQn);
	NVIC_ClearPendingIRQ(RTT_IRQn);
	NVIC_SetPriority(RTT_IRQn, 0);
	NVIC_EnableIRQ(RTT_IRQn);
	rtt_enable_interrupt(RTT, RTT_MR_RTTINCIEN);
}


// +--------------------------------------------------------------+
// |                  Interrupt Service Routines                  |
// +--------------------------------------------------------------+
void RTT_Handler(void)
{
	TickCounter++;
	
	Decrement(JumperDebounceCountdown);
	Decrement(TransmitQueueTimeout);
	
	u8 tIndex; for (tIndex = 0; tIndex < NUM_COUNTDOWN_TIMERS; tIndex++)
	{
		Decrement(GenericCountdown[tIndex]);
	}
	
	//NOTE: We have to read the status for this interrupt to work correctly
	u32 status = rtt_get_status(RTT);
	(void)(status); //Unused variable
}

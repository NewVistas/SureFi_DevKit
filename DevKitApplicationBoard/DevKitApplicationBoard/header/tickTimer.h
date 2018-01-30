/*
File:   tickTimer.h
Author: Taylor Robbins
Date:   01\22\2018
*/

#ifndef _TICK_TIMER_H
#define _TICK_TIMER_H

// +--------------------------------------------------------------+
// |                        Public Defines                        |
// +--------------------------------------------------------------+
#define NUM_COUNTDOWN_TIMERS 4

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
extern volatile u32 TickCounter;

extern volatile u32 JumperDebounceCountdown;
extern volatile u32 TransmitQueueTimeout;
extern volatile u32 GenericCountdown[NUM_COUNTDOWN_TIMERS];

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitializeTickTimer();

#endif //  _TICK_TIMER_H

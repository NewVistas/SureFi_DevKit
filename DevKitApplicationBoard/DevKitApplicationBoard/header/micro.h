/*
File:   micro.h
Author: Taylor Robbins
Date:   01\17\2018
*/

#ifndef _MICRO_H
#define _MICRO_H

// +--------------------------------------------------------------+
// |                      Public Definitions                      |
// +--------------------------------------------------------------+
#define DEBUG_LED1_PORT PIOA
#define DEBUG_LED1_MASK PIO_PA7

#define DEBUG_LED2_PORT PIOB
#define DEBUG_LED2_MASK PIO_PB4

#define POWER_LED_PORT PIOA
#define POWER_LED_MASK PIO_PA8

#define MODE1_JUMPER_PORT PIOB
#define MODE1_JUMPER_MASK PIO_PB14

#define MODE2_JUMPER_PORT PIOB
#define MODE2_JUMPER_MASK PIO_PB9

#define MODE3_JUMPER_PORT PIOB
#define MODE3_JUMPER_MASK PIO_PB8

// +==============================+
// |            Atmel             |
// +==============================+
#define UnlockPowerManagementController() (PMC->PMC_WPMR) = (0x504D4300)
#define LockPowerManagementController()   (PMC->PMC_WPMR) = (0x504D4301)

#define UnlockPort(port) (port)->PIO_WPMR = (0x504D4300)

#define EnablePin(port, mask)  (port)->PIO_PER = (mask)
#define DisablePin(port, mask) (port)->PIO_PDR = (mask)

#define SetAsOutput(port, mask) (port)->PIO_OER = (mask)
#define SetAsInput(port, mask)  (port)->PIO_ODR = (mask)

#define EnableOutputWrite(port, mask) (port)->PIO_OWER = (mask)
#define DisableOutputWrite(port, mask) (port)->PIO_OWDR = (mask)

#define EnablePullUp(port, mask)  (port)->PIO_PUER = (mask)
#define DisablePullUp(port, mask) (port)->PIO_PUDR = (mask)

#define EnablePinInterrupt(port, mask)  (port)->PIO_IER = (mask)
#define DisablePinInterrupt(port, mask) (port)->PIO_IDR = (mask)

#define SetPinHigh(port, mask) (port)->PIO_SODR = (mask)
#define SetPinLow(port, mask)  (port)->PIO_CODR = (mask)
#define SetPinValue(port, mask, value) (port)->PIO_ODSR = (((port)->PIO_ODSR & (~(mask))) | ((value) ? mask : 0))

#define GetPinInputValue(port, mask) ((bool)((port)->PIO_PDSR & (mask)))

#define ConfigureOutput(port, mask, high) do \
{                                            \
	UnlockPort(port);                        \
	EnablePin(port, mask);                   \
	SetAsOutput(port, mask);                 \
	EnableOutputWrite(port, mask);           \
	if (high)   { SetPinHigh(port, mask); }  \
	else        { SetPinLow (port, mask); }  \
} while(0)

#define ConfigureInput(port, mask, pullup) do  \
{                                              \
	UnlockPort(port);                          \
	SetAsInput(port, mask);                    \
	DisablePinInterrupt(port, mask);           \
	if (pullup) { EnablePullUp (port, mask); } \
	else        { DisablePullUp(port, mask); } \
	EnablePin(port, mask);                     \
} while(0)

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void MicroInit();
void QuickDelay();
void ResetWatchdog();
void MicroEnableInterrupts();
void MicroDisableInterrupts();

#endif //  _MICRO_H

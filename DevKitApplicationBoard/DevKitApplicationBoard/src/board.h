/*
File:   board.h
Author: Taylor Robbins
Date:   01\17\2018
*/

#ifndef _BOARD_H
#define _BOARD_H

#define BOARD_FREQ_SLCK_XTAL        (32768U)
#define BOARD_FREQ_SLCK_BYPASS      (32768U)
#define BOARD_FREQ_MAINCK_XTAL      (12000000U)
#define BOARD_FREQ_MAINCK_BYPASS    (12000000U)
#define BOARD_MCK                   CHIP_FREQ_CPU_MAX
#define BOARD_OSC_STARTUP_US        15625

#endif //  _BOARD_H

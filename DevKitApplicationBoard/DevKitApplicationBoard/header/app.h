/*
File:   app.h
Author: Taylor Robbins
Date:   01\26\2018
*/

#ifndef _APP_H
#define _APP_H

// +--------------------------------------------------------------+
// |                      Public Definitions                      |
// +--------------------------------------------------------------+
#define TEST_BUTTON_PORT PIOA
#define TEST_BUTTON_MASK PIO_PA16

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
extern bool AppRunning;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void AppInitialize();
void AppStart();
void AppStop();
void AppUpdate();

#endif //  _APP_H

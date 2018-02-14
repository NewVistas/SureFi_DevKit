/*
File:   bleApp.h
Author: Taylor Robbins
Date:   02\14\2018
*/

#ifndef _BLE_APP_H
#define _BLE_APP_H

// +--------------------------------------------------------------+
// |                        Public Globals                        |
// +--------------------------------------------------------------+
extern bool BleAppRunning;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void InitializeBleApp();
void BleAppStart();
void BleAppStop();
void BleAppUpdate();

#endif //  _BLE_APP_H

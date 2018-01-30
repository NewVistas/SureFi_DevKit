/*
File:   helpers.h
Author: Taylor Robbins
Date:   01\24\2018
*/

#ifndef _HELPERS_H
#define _HELPERS_H

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
bool IsHexChar(char c);
u8 GetHexCharValue(char c);
u8 ParseHexByte(const char* chars);
const char* GetSureErrorStr(u8 sureError);
const char* GetSureCmdStr(u8 sureCmd);

#endif //  _HELPERS_H

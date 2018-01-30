/*
File:   debug.c
Author: Taylor Robbins
Date:   01\19\2018
Description: 
	** Holds a layer that works on top of myUart to handle sending
	** debug output to a generic windows terminal
*/

#include "defines.h"
#include "debug.h"

#include <stdarg.h>

#include "uartFifos.h"

// +--------------------------------------------------------------+
// |                     Private Definitions                      |
// +--------------------------------------------------------------+
#define DEBUG_PRINT_BUFFER_SIZE 1024

// +--------------------------------------------------------------+
// |                       Private Globals                        |
// +--------------------------------------------------------------+
static char debugPrintBuffer[DEBUG_PRINT_BUFFER_SIZE];
static bool onNewLine = true;
static bool debugInputReady = false;
static u8 debugInputLength = 0;
static char debugInputBuffer[64];

#if OUTPUT_LEVEL_PREFIX
// static const char* levelPrefixes[OutputLevel_NumLevels] = {  };
static const char* levelPrefixes[OutputLevel_NumLevels] =
{
	"\x01", "\x02", "\x03", "\x04"
	// "D: ", "I: ", "E: ", "O: "
};
#endif

// +--------------------------------------------------------------+
// |                      Private Functions                       |
// +--------------------------------------------------------------+
static void DebugOutput(OutputLevel_t outputLevel, const char* functionName, const char* charPntr, u16 numChars)
{
	Assert(outputLevel < OutputLevel_NumLevels);
	
	u16 cIndex = 0;
	for (cIndex = 0; cIndex < numChars; cIndex++)
	{
		char nextChar = charPntr[cIndex];
		
		if (onNewLine && nextChar != '\n')
		{
			#if OUTPUT_LEVEL_PREFIX
			AppUartSendString(AppUart_DebugOutput, levelPrefixes[outputLevel]);
			#endif
			
			#if OUTPUT_FUNCTION_PREFIX
			AppUartSendString(AppUart_DebugOutput, functionName);
			AppUartSendString(AppUart_DebugOutput, ": ");
			#endif
		}
		
		if (nextChar == '\n')
		{
			AppUartSendData(AppUart_DebugOutput, (const u8*)NEW_LINE_STR, NEW_LINE_STR_LENGTH);
			onNewLine = true;
		}
		else
		{
			AppUartSendData(AppUart_DebugOutput, (u8*)&nextChar, 1);
			onNewLine = false;
		}
	}
}

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void UpdateDebugInput()
{
	// +================================+
	// | Echo Characters and Save Input |
	// +================================+
	while (AppUartGetRxNumBytes(AppUart_DebugOutput) > 0)
	{
		char newChar = (char)AppUartPopRxByte(AppUart_DebugOutput);
		bool echo = false;
		if (newChar == '\n')
		{
			debugInputReady = true;
			echo = true;
		}
		else if (newChar == '\b')
		{
			if (!debugInputReady && debugInputLength > 0)
			{
				debugInputLength--;
				debugInputBuffer[debugInputLength] = '\0';
				echo = true;
			}
		}
		else if (newChar >= ' ' && newChar <= '~')
		{
			if (!debugInputReady && debugInputLength+1 < ArrayCount(debugInputBuffer))
			{
				debugInputBuffer[debugInputLength] = newChar;
				debugInputBuffer[debugInputLength+1] = '\0';
				debugInputLength++;
				echo = true;
			}
		}
		else
		{
			AppUartPrintString(AppUart_DebugOutput, "[0x%02X]", newChar);
		}
		
		if (echo) { AppUartSendData(AppUart_DebugOutput, (u8*)&newChar, 1); }
	}
}

bool DebugInputReady()
{
	return debugInputReady;
}

void ClearDebugInput()
{
	debugInputBuffer[0] = '\0';
	debugInputLength = 0;
	debugInputReady = false;
}

const char* GetDebugInput(u8* inputLengthOut)
{
	if (inputLengthOut != nullptr) { *inputLengthOut = debugInputLength; }
	return &debugInputBuffer[0];
}

void DebugWrite(OutputLevel_t outputLevel, const char* functionName, const char* str)
{
	DebugOutput(outputLevel, functionName, str, (u16)strlen(str));
}

void DebugWriteLine(OutputLevel_t outputLevel, const char* functionName, const char* str)
{
	DebugOutput(outputLevel, functionName, str, (u16)strlen(str));
	DebugOutput(outputLevel, functionName, "\n", 1);
}

void DebugPrint(OutputLevel_t outputLevel, const char* functionName, const char* formatStr, ...)
{
	va_list vargs;
	
	va_start(vargs, formatStr);
	int printResult = vsnprintf(debugPrintBuffer, DEBUG_PRINT_BUFFER_SIZE, formatStr, vargs);
	va_end(vargs);
	
	if (printResult > 0 && printResult < DEBUG_PRINT_BUFFER_SIZE)
	{
		DebugOutput(outputLevel, functionName, debugPrintBuffer, printResult);
	}
}

void DebugPrintLine(OutputLevel_t outputLevel, const char* functionName, const char* formatStr, ...)
{
	va_list vargs;
	
	va_start(vargs, formatStr);
	int printResult = vsnprintf(debugPrintBuffer, DEBUG_PRINT_BUFFER_SIZE, formatStr, vargs);
	va_end(vargs);
	
	if (printResult > 0 && printResult < DEBUG_PRINT_BUFFER_SIZE)
	{
		DebugOutput(outputLevel, functionName, debugPrintBuffer, printResult);
	}
	DebugOutput(outputLevel, functionName, "\n", 1);
}


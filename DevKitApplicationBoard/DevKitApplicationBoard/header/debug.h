/*
File:   debug.h
Author: Taylor Robbins
Date:   01\19\2018
*/

#ifndef _DEBUG_H
#define _DEBUG_H

// +--------------------------------------------------------------+
// |                      Public Definitions                      |
// +--------------------------------------------------------------+
#define DEBUG_OUTPUT_ENABLED true
#define DEBUG_LEVEL_ENABLED (true && DEBUG_OUTPUT_ENABLED)
#define INFO_LEVEL_ENABLED  (true && DEBUG_OUTPUT_ENABLED)
#define ERROR_LEVEL_ENABLED (true && DEBUG_OUTPUT_ENABLED)
#define OTHER_LEVEL_ENABLED (true && DEBUG_OUTPUT_ENABLED)

#define NEW_LINE_STR           "\n"
#define NEW_LINE_STR_LENGTH    1
#define OUTPUT_LEVEL_PREFIX    true
#define OUTPUT_FUNCTION_PREFIX false

// +--------------------------------------------------------------+
// |              Public Structure/Type Definitions               |
// +--------------------------------------------------------------+
typedef enum
{
	OutputLevel_Debug = 0,
	OutputLevel_Info,
	OutputLevel_Error,
	OutputLevel_Other,
	OutputLevel_NumLevels,
} OutputLevel_t;

// +--------------------------------------------------------------+
// |                       Public Functions                       |
// +--------------------------------------------------------------+
void UpdateDebugInput();
bool DebugInputReady();
void ClearDebugInput();
const char* GetDebugInput(u8* inputLengthOut);
void DebugWrite(OutputLevel_t outputLevel, const char* functionName, const char* str);
void DebugWriteLine(OutputLevel_t outputLevel, const char* functionName, const char* str);
void DebugPrint(OutputLevel_t outputLevel, const char* functionName, const char* formatStr, ...);
void DebugPrintLine(OutputLevel_t outputLevel, const char* functionName, const char* formatStr, ...);

// +--------------------------------------------------------------+
// |                        Public Macros                         |
// +--------------------------------------------------------------+
#if DEBUG_LEVEL_ENABLED
	#define Write_D(str)                do { DebugWrite    (OutputLevel_Debug, __func__, str); } while(0)
	#define WriteLine_D(str)            do { DebugWriteLine(OutputLevel_Debug, __func__, str); } while(0)
	#define Print_D(formatStr, ...)     do { DebugPrint    (OutputLevel_Debug, __func__, formatStr, ##__VA_ARGS__); } while(0)
	#define PrintLine_D(formatStr, ...) do { DebugPrintLine(OutputLevel_Debug, __func__, formatStr, ##__VA_ARGS__); } while(0)
#else
	#define Write_D(str)                //blank
	#define WriteLine_D(str)            //blank
	#define Print_D(formatStr, ...)     //blank
	#define PrintLine_D(formatStr, ...) //blank
#endif

#if INFO_LEVEL_ENABLED
	#define Write_I(str)                do { DebugWrite    (OutputLevel_Info, __func__, str); } while(0)
	#define WriteLine_I(str)            do { DebugWriteLine(OutputLevel_Info, __func__, str); } while(0)
	#define Print_I(formatStr, ...)     do { DebugPrint    (OutputLevel_Info, __func__, formatStr, ##__VA_ARGS__); } while(0)
	#define PrintLine_I(formatStr, ...) do { DebugPrintLine(OutputLevel_Info, __func__, formatStr, ##__VA_ARGS__); } while(0)
#else
	#define Write_I(str)                //blank
	#define WriteLine_I(str)            //blank
	#define Print_I(formatStr, ...)     //blank
	#define PrintLine_I(formatStr, ...) //blank
#endif

#if ERROR_LEVEL_ENABLED
	#define Write_E(str)                do { DebugWrite    (OutputLevel_Error, __func__, str); } while(0)
	#define WriteLine_E(str)            do { DebugWriteLine(OutputLevel_Error, __func__, str); } while(0)
	#define Print_E(formatStr, ...)     do { DebugPrint    (OutputLevel_Error, __func__, formatStr, ##__VA_ARGS__); } while(0)
	#define PrintLine_E(formatStr, ...) do { DebugPrintLine(OutputLevel_Error, __func__, formatStr, ##__VA_ARGS__); } while(0)
#else
	#define Write_E(str)                //blank
	#define WriteLine_E(str)            //blank
	#define Print_E(formatStr, ...)     //blank
	#define PrintLine_E(formatStr, ...) //blank
#endif

#if OTHER_LEVEL_ENABLED
	#define Write_O(str)                do { DebugWrite    (OutputLevel_Other, __func__, str); } while(0)
	#define WriteLine_O(str)            do { DebugWriteLine(OutputLevel_Other, __func__, str); } while(0)
	#define Print_O(formatStr, ...)     do { DebugPrint    (OutputLevel_Other, __func__, formatStr, ##__VA_ARGS__); } while(0)
	#define PrintLine_O(formatStr, ...) do { DebugPrintLine(OutputLevel_Other, __func__, formatStr, ##__VA_ARGS__); } while(0)
#else
	#define Write_O(str)                //blank
	#define WriteLine_O(str)            //blank
	#define Print_O(formatStr, ...)     //blank
	#define PrintLine_O(formatStr, ...) //blank
#endif

#endif //  _DEBUG_H

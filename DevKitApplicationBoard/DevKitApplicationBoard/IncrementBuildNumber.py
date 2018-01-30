# File:   IncrementBuildNumber.py
# Author: Taylor Robbins
# Date:   01\19\2018
# Description: 
# 	Opens a file, searches it for a define by name and increments it's numeric value 

import re
import os
import sys

print("===== Running IncrementVersionNumber.py =====")
print("Passed %u arguments: %s" % (len(sys.argv), str(sys.argv)))

if (len(sys.argv) < 3 or len(sys.argv[1]) == 0 or len(sys.argv[2]) == 0):
#
	print("Usage: IncrementBuildNumber.py \"path/to/version.h\" DEFINE_NAME")
#

versionFilePath    = sys.argv[1]
defineName         = sys.argv[2]
tempFilePath       = versionFilePath + ".temp"
searchRegex        = '\\#define\\s+' + defineName + '\\s+([0-9]+)'
versionFile        = None
foundVersionNumber = False
newVersionNumber   = ""
fileContents = ""
newFileContents = ""

try:
#
	versionFile = open(versionFilePath, "r")
#
except IOError:
#
	print("Could not open \"%s\" to increment build number" % (versionFilePath))
#

if (versionFile != None):
#
	fileContents = versionFile.read()
	versionFile.close()
#

if (len(fileContents) > 0):
#
	searchResult = re.search(searchRegex, fileContents);
	if (searchResult == None):
	#
		print("Search failed with no matches using regex: \"%s\"" % (searchRegex))
	#
	elif (len(searchResult.groups()) < 1):
	#
		print("Regex only returned %u groups" % (len(searchResult.groups())))
	#
	else:
	#
		currentVersionStr = searchResult.group(1)
		currentVersionNumber = int(currentVersionStr, 10)
		print("Current version is %u" % (currentVersionNumber))
		
		foundVersionNumber = True
		newVersionNumber = currentVersionNumber + 1
		newFileContents = fileContents[:searchResult.start(1)] + str(newVersionNumber) + fileContents[searchResult.end(1):]
		# print("New File Contents: \"%s\"" % (newFileContents))
	#
	
	tempFile = open(tempFilePath, "w")
	tempFile.write(newFileContents)
	tempFile.close()
	
	os.remove(versionFilePath)
	os.rename(tempFilePath, versionFilePath)
#

if (foundVersionNumber):
#
	print("\"%s\" incremented to %u" % (defineName, newVersionNumber))
#
else:
#
	print("Could not find \"%s\" define in \"%s\". Build number not incremented" % (defineName, versionFilePath))
#

print("===== Finished IncrementVersionNumber.py =====")

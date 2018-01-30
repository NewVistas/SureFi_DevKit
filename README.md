# Sure-Fi Module Development Kit
This repository contains the source for all the projects related to the Sure-Fi Module Development Kit. This includes the firmware for the application board, and the software for the Windows, iOS, and Android applications. These projects are released alongside the Sure-Fi Module as example projects as well as useful tools to be used when expirmenting with the module.

# DevKitApplicationBoard
Contains an Atmel Studio project that acts as a starting point for people to experiment and develop ebmedded applications on the plug-in board that comes with the development kit. The project is designed for SAM4S16BA chip on the application board. It contains an example embedded application that can be enabled using the jumper on the board.

# DevKitWindowsApp
Contains the source code of the Visual Studio project for the Windows application. It's written in C# and allows you to configure the Module through an FTDI cable connected to the Application Board's windows interface UART.

# DevKitIOSApp
Contains the source code of the XCode project for the iOS application. It's written in Swift3 and allows you to configure the Module through the BLE chip using an iPhone or iPad.

# DevKitAndroidApp
Contains the source code of the Android Studio project for the Android application. It's written in Kotlin and allows you to configure the Module through the BLE chip using an Android phone.

Renode changelog
================

This document describes notable changes to the Renode framework.

1.4.1 - 2018.06.28
------------------

Added:

* AXI UART Lite model

Changed:

* event dispatching on WPF on Windows

Fixed:

* an error in handling of generated code on Windows, causing the emulated application to misbehave
* font loading and default font size on Windows

1.4.0 - 2018.06.22
------------------

Added:

* support for RISC-V Privileged Architecture 1.10
* 64-bit RISC-V target emulation
* support for HiFive Unleashed platform
* support for SiFive Freedom E310 platform
* new way of handling time progression and synchronization in the whole framework
* support for 64-bit registers
* basic support for a range of SiLabs EFM32, EFR32 and EZR32 MCUs
* several new Robot keywords
* Wireshark support for macOS

Changed:

* Windows runs a 64-bit version of Renode
* 32-bit host OSes are no longer supported
* Robot tests can now be marked as OS-specific or ignored
* improvements in CC2538 radio model
* enum values in REPL files can now be provided as integers
* updated interrupt model in RISC-V
* MaximumBlockSize is no longer forced to 1 when starting GDB server

Fixed:

* several fixes in REPL grammar
* fixes in Robot test handling
* fixes in GDB watchpoints and breakpoints
* few other fixes in GDB integration layer
* floating point operations in RISC-V
* atomic operations in RISC-V
* high CPU usage when loading many nodes at the same time
* deserialization of the UART windows
* symbol names caching when loading new symbol files
* several minor fixes in different platform files

1.3.0 - 2018.01.26
------------------

Added:

* EmulationEnvironment - a mechanism to handle sensor data in a centralized way
* test for loading REPL files
* several registers and commands in CC2538RF
* SCSS device for QuarkC1000 platform
* sample scripts with two nodes running a Zephyr demo

Changed:

* ComparingTimer and LimitTimer are now more similar in terms of API
* macOS runs a 64-bit version of Renode
* changed Arduino 101 with CC2520 board to Quark C1000 devkit
* improvements in RISC-V interrupt handling
* current working directory is now always a part of Monitor's default path

Fixed:

* crash when closing Renode with Wireshark enabled but not yet started
* handling of timer events for a specific timer configuration
* implementation of LED tester
* starting Robot on Windows without administrative privileges
* terminal state after running Robot tests
* improper timer initialization in RISC-V's CoreLevelInterruptor
* text highlighting in wrapped lines in terminal windows

1.2.0 - 2017.11.15
------------------

Added:

* support for RISC-V architecture
* support for Microsemi Mi-V platform
* thin OpenOCD layer in GDB remote protocol support

Changed:

* timers can now hold values up to 64 bits
* ``Button`` peripheral can now have inverted logic
* GDB server can be configured to autostart after the first "monitor halt" received

Fixed:

* translation cache invalidation on manual writes to memory
* reset of ``LimitTimer`` peripheral, which is the base for most of the supported timers

1.1.0 - 2017.11.14
------------------

Added:

* sample scripts for different platforms
* support for running Renode on Windows
* EFR32MG cpu support. For the list of peripherals, see efr32mg.repl
* more robust support for SVD files
* support for '\n -> \r\n' patching in Termsharp console windows
* support for font configuration in Termsharp
* support for CRC in Ethernet
* packaging scripts

Changed:

* API for UART-related keywords in Robot Framework integration layer
* the project infrastructure now supports C# 7.0
* directory organization

Fixed:

* several minor fixes in platform description format (.repl)
* bug where Renode hanged after issuing the "help" command in the Monitor

1.0.0 - 2017.06.13
------------------

This is the initial release of Renode.
Renode is a virtual development and testing tool for multinode embedded networks.
For more information please visit `<https://www.renode.io>`_.


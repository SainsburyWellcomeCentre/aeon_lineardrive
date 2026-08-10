# Aeon LinearDrive

A Harp device that drives a FAULHABER linear actuator over an RS232 link, exposing the motor's position, speed, and current limits as Harp registers. In Project Aeon it is the linear actuator of the Neuropixels commutation-translation system, paired with the ONIX commutator and adjusted in closed loop to maintain the right slack in the tethering cable. The device is controlled from Bonsai, or any .NET application, through the `Aeon.LinearDrive` package.

## Getting started

Flash the firmware and deploy the application to the Raspberry Pi Pico as described in [`firmware`](firmware), then drive the device through its Harp registers:

1. Set the reference with `HomePosition`, in encoder counts.
2. Enable the driver by writing `1` to `EnableMotorDriver`.
3. Command a target with `SetPosition`, and read the live `Position` event.

Speed and safety limits are set through `LimitSpeed`, `LimitContinuousCurrent`, `LimitPeakCurrent`, and `LimitPosition`. The `Aeon.LinearDrive` package wraps the register interface for Bonsai and .NET; see [`software`](software).

## Harp register map

| Register | MessageType | Address | PayloadType | Description |
| --- | --- | --- | --- | --- |
| SetSpeed | Write | 33 | S16 | Set Linear rail velocity, [-7583, 7583] rpm. |
| Speed | Event | 34 | S16 | Current Linear rail velocity, [-7583, 7583] rpm. |
| EnableMotorDriver | Write | 40 | U8 | Linear rail control, 0 = disable, 1 = enable. |
| LimitPosition | Write | 41 | S32 | Linear rail position limits, default -1000, 160000 encoder counts. |
| HomePosition | Write | 42 | S32 | Linear rail home position, in encoder counts. |
| SetPosition | Write | 43 | S32 | Linear rail goto position, in encoder counts. |
| Position | Event | 44 | S32 | Linear rail current position, in encoder counts. |
| LimitSpeed | Write | 45 | U16 | Linear rail speed limit, default 7583 rpm. |
| LimitContinuousCurrent | Write | 46 | U16 | Linear rail Continuous current limit, default 900 mA. |
| LimitPeakCurrent | Write | 47 | U16 | Linear rail Peak current limit, default 900 mA. |
| EnableLimitPosition | Write | 48 | U8 | Position range limit control, 0 = disable, 1 = enable. |

Velocity is the motor shaft speed in rpm and position is in motor encoder counts, both passed to the FAULHABER controller as-is. No gearhead or lead-screw conversion to linear displacement is applied on the device.

## Dependencies

The device runs a MicroPython image on the RP2040, built from the `v1.18-swc` branch of the SWC MicroPython fork, which compiles in the `usbcdc` and `harpsync` modules the firmware relies on. The `microharp` framework and the application in [`firmware`](firmware) are copied onto the board filesystem.

- MicroPython image: [`SainsburyWellcomeCentre/micropython` at `v1.18-swc`](https://github.com/SainsburyWellcomeCentre/micropython/tree/v1.18-swc)
- microharp framework: [`micropython-microharp` at `df88717c`](https://github.com/SainsburyWellcomeCentre/micropython-microharp/tree/df88717c966ac3c177d1f9f41d29ec503de5deea). Pin this commit; the current version of microharp is an incompatible rewrite.

A prebuilt firmware image is attached to each release, so building from source is only needed to change the firmware itself. See [`firmware`](firmware) for the flash and deploy steps.

## Citation Policy

If you use this software or hardware, please cite it as below:

D. Campagner, J. Bhagat, G. Lopes, L. Calcaterra, A. G. Pouget, A. Almeida, T. T. Nguyen, C. H. Lo, T. Ryan, B. Cruz, F. J. Carvalho, Z. Li, A. Erskine, J. Rapela, O. Folsz, M. Marin, J. Ahn, S. Nierwetberg, S. C. Lenzi, J. D. S. Reggiani, SGEN group – SWC GCNU Experimental Neuroethology Group. _Aeon: an open-source platform to study the neural basis of ethological behaviours over naturalistic timescales._ Preprint at https://doi.org/10.1101/2025.07.31.664513 (2025)

[![DOI:10.1101/2025.07.31.664513](https://img.shields.io/badge/DOI-10.1101%2F2025.07.31.664513-AE363B.svg)](https://doi.org/10.1101/2025.07.31.664513)

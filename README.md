# Aeon LinearDrive

Commutator linear drive Harp device.

Provides control of the linear drive to control the position of the commutator from Bonsai.

## Dependencies

The target must be running a firmware image built from the v1.18-swc branch of the MicroPython project.

Additionally, the SWC microharp package must be present on the filesystem of the target.

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

## Quick Start

To control the position of the linear drive:
- set home
- enable the drive
- set position

## Citation Policy

If you use this software or hardware, please cite it as below:

D. Campagner, J. Bhagat, G. Lopes, L. Calcaterra, A. G. Pouget, A. Almeida, T. T. Nguyen, C. H. Lo, T. Ryan, B. Cruz, F. J. Carvalho, Z. Li, A. Erskine, J. Rapela, O. Folsz, M. Marin, J. Ahn, S. Nierwetberg, S. C. Lenzi, J. D. S. Reggiani, SGEN group – SWC GCNU Experimental Neuroethology Group. _Aeon: an open-source platform to study the neural basis of ethological behaviours over naturalistic timescales._ Preprint at https://doi.org/10.1101/2025.07.31.664513 (2025)

[![DOI:10.1101/2025.07.31.664513](https://img.shields.io/badge/DOI-10.1101%2F2025.07.31.664513-AE363B.svg)](https://doi.org/10.1101/2025.07.31.664513)

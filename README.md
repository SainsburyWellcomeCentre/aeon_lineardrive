# Aeon LinearDrive
Commutator linear drive harp device.

Provides control of the linear drive to control the position of the commutator from Bonsai.

## Dependencies
The target must be running a firmware image built from the v1.18-swc branch of the micropython project.

Additionally, the SWC microharp package must be present on the filesystem of the target.

## Harp register map
| MessageType | Address | PayloadType | Payload | Description |
| --- | --- | --- | --- | --- |
| Write | 33 | S16 | vel | Set Linear rail velocity, [-7583, 7583] TODO: units. |
| Event | 34 | S16 | vel | Current Linear rail velocity, [-7583, 7583] TODO: units. |
| Write | 40 | U8 | ctl | Linear rail control, 0 = disable, 1 = enable. |
| Write | 41 | S32 | -ve, +ve | Linear rail position limits, default -1000, 160000. |
| Write | 42 | S32 | pos | Linear rail home pos [-2147483648, 2147483647] TODO: units. |
| Write | 43 | S32 | pos | Linear rail goto pos [-2147483648, 2147483647] TODO: units. |
| Event | 44 | S32 | pos | Linear rail current pos [-2147483648, 2147483647] TODO: units. |
| Write | 45 | U16 | spd | Linear rail speed limit, default 7583. |
| Write | 46 | U16 | ctl | Linear rail Continuous current limit, default 900 (mA). |
| Write | 47 | U16 | ctl | Linear rail Peak current limit, default 900 (mA). |
| Write | 48 | U8 | ctl | Position range limit control, 0 = disable, 1 = enable. |

## Quick Start
To control the position of the linear drive;
- set home
- enable the drive
- set position

## Notes
This is a work in progress copied from the Perturbation Treadmill Code base pert-tread-drv

## Citation Policy

If you use this software or hardware, please cite it as below:

D. Campagner, J. Bhagat, G. Lopes, L. Calcaterra, A. G. Pouget, A. Almeida, T. T. Nguyen, C. H. Lo, T. Ryan, B. Cruz, F. J. Carvalho, Z. Li, A. Erskine, J. Rapela, O. Folsz, M. Marin, J. Ahn, S. Nierwetberg, S. C. Lenzi, J. D. S. Reggiani, SGEN group&mdash;SWC GCNU Experimental Neuroethology Group. _Aeon: an open-source platform to study the neural basis of ethological behaviours over naturalistic timescales._ Preprint at https://doi.org/10.1101/2025.07.31.664513 (2025)

[![DOI:10.1101/2025.07.31.664513](https://img.shields.io/badge/DOI-10.1101%2F2025.07.31.664513-AE363B.svg)](https://doi.org/10.1101/2025.07.31.664513)


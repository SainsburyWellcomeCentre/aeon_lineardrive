# pert-tread-drv
Commutator linear drive harp device.

Provides control of the treadmill's drive belt and tilt mechanism from Bonsai.

## Dependencies
The target must be running a firmware image built from the v1.18-swc branch of the micropython project.

Additionally, the SWC microharp package must be present on the filesystem of the target.

## Harp register map
| MessageType | Address | PayloadType | Payload | Description |
| --- | --- | --- | --- | --- |
| Write | 32 | U8 | ctl | Belt drive control, 0 = disable, 1 = enable. |
| Write | 33 | S16 | vel | Set belt drive velocity, [-5000, 5000] TODO: units. |
| Event | 34 | S16 | vel | Current belt drive velocity, [-5000, 5000] TODO: units. |
| Write | 40 | U8 | ctl | Tilt mechanism control, 0 = disable, 1 = enable. |
| Write | 41 | S32 | -ve, +ve | Tilt mechanism position limits, default -6100, 6100. |
| Write | 42 | S32 | pos | Tilt mechanism home pos [-32768, 32767] TODO: units. |
| Write | 43 | S32 | pos | Tilt mechanism goto pos [-32768, 32767] TODO: units. |
| Event | 44 | S32 | pos | Tilt mechanism current pos [-32768, 32767] TODO: units. |
| Write | 45 | U16 | spd | Tilt mechanism speed limit, default 2000. |

## Quick Start
To control the position of the treadmill;
- set home
- enable the drive
- set position

## Notes
This is a work in progress copied from the Perturbation Treadmill Code base pert-tread-drv
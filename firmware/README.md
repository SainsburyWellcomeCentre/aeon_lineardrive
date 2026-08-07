# Firmware

The application in this folder runs under MicroPython on the Raspberry Pi Pico (RP2040). `main.py` is the boot entry point, layered on top of a MicroPython base image and the microharp framework.

## Firmware stack

1. A MicroPython base image built from the [`v1.18-swc`](https://github.com/SainsburyWellcomeCentre/micropython/tree/v1.18-swc) branch of the SWC MicroPython fork, which provides the `usbcdc` and `harpsync` modules the application imports. A prebuilt image is published as the release asset `micropython-v1.18-swc-pico.uf2`.
2. The [`microharp`](https://github.com/SainsburyWellcomeCentre/micropython-microharp/tree/df88717c966ac3c177d1f9f41d29ec503de5deea) Harp framework, at commit `df88717c`, copied onto the board filesystem. Pin this commit; the current version of microharp is an incompatible rewrite.
3. The application `.py` files in this folder.

## Install

1. Hold BOOTSEL, connect the Pico, and copy the `micropython-v1.18-swc-pico.uf2` release asset onto it to flash the base image.
2. Copy the `microharp` package from commit `df88717c` onto the board filesystem, so its modules import as `microharp`.
3. Copy the application files from this folder onto the board; `main.py` runs on boot.

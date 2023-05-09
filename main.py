"""Con Linear Drive main application entrypoint."""
# Import standard library modules.
import uasyncio
from machine import Pin, UART

# Import SWC-IRFL library modules.
import usbcdc
import harpsync
from ptdevice import PtDevice

# Instance the hardware interfaces.
stream = usbcdc.usbcdc(1)
sync = harpsync.harpsync(0)
led = Pin(6, Pin.OUT)
uart = UART(1, 115200, tx=Pin(4), rx=Pin(5, pull=Pin.PULL_UP), timeout=5)
#estop = Pin(2, mode=Pin.IN, pull=Pin.PULL_UP)

# Instance the device object and launch its application.
#theDevice = PtDevice(stream, sync, led, uart, estop)
theDevice = PtDevice(stream, sync, led, uart)
uasyncio.run(theDevice.main())

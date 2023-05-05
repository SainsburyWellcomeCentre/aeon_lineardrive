"""Pertubation treadmill device class."""
from micropython import const
from machine import Pin, Timer

from microharp.device import HarpDevice
from microharp.types import HarpTypes
from microharp.register import ReadWriteReg, OperationalCtrlReg
from microharp.event import LooseEvent

from fhdrive import FaulhaberDrive
from ptregisters import EnableReg, PositionLimReg, PositionHomeReg, \
    PositionSetReg, PositionActReg, SpeedLimReg, VelocitySetReg, VelocityActReg


class PtDevice(HarpDevice):
    """Pertubation treadmill drive Harp device."""
    R_BELT_ENA = const(32)
    R_BELT_VSET = const(33)
    R_BELT_VACT = const(34)

    R_TILT_ENA = const(40)
    R_TILT_PLIM = const(41)
    R_TILT_HOME = const(42)
    R_TILT_PSET = const(43)
    R_TILT_PACT = const(44)
    R_TILT_SLIM = const(45)

    def __init__(self, stream, sync, led, uart, estop, trace=False):
        """Constructor.

        Connects the logical device to its physical interfaces, creates the drives and register map.
        """
        super().__init__(stream, sync, led, trace=trace)

        self.drives = (
            FaulhaberDrive(uart, 1),
            FaulhaberDrive(uart, 2)
        )

        registers = {
            HarpDevice.R_DEVICE_NAME: ReadWriteReg(HarpTypes.U8, tuple(b'Pertubation Treadmill')),

            PtDevice.R_BELT_ENA: EnableReg(self.drives[0], estop),
            PtDevice.R_BELT_VSET: VelocitySetReg(self.drives[0]),
            PtDevice.R_BELT_VACT: VelocityActReg(self.drives[0]),

            PtDevice.R_TILT_ENA: EnableReg(self.drives[1], estop),
            PtDevice.R_TILT_PLIM: PositionLimReg(self.drives[1]),
            PtDevice.R_TILT_HOME: PositionHomeReg(self.drives[1]),
            PtDevice.R_TILT_PSET: PositionSetReg(self.drives[1]),
            PtDevice.R_TILT_PACT: PositionActReg(self.drives[1]),
            PtDevice.R_TILT_SLIM: SpeedLimReg(self.drives[1])
        }
        self.registers.update(registers)

        self.velocityEvent = LooseEvent(
            PtDevice.R_BELT_VACT, self.registers[PtDevice.R_BELT_VACT].typ, self.rxMessages)
        self.positionEvent = LooseEvent(
            PtDevice.R_TILT_PACT, self.registers[PtDevice.R_TILT_PACT].typ, self.rxMessages)
        Timer(period=100, callback=self.velocityEvent.callback)
        Timer(period=100, callback=self.positionEvent.callback)

        estop.irq(handler=self._estop_irq, trigger=Pin.IRQ_RISING)

    def _ctrl_hook(self):
        """Private member function.

        Control register write hook, updates device state.
        """
        super()._ctrl_hook()

        if self.registers[HarpDevice.R_OPERATION_CTRL].OP_MODE != OperationalCtrlReg.STANDBY_MODE:
            self.velocityEvent.enabled = True
            self.positionEvent.enabled = True
        else:
            self.velocityEvent.enabled = False
            self.positionEvent.enabled = False

    def _estop_irq(self, ins):
        """Private member function.

        Stop pin interrupt handler, disables all drives.
        """
        for drive in self.drives:
            drive.en = False

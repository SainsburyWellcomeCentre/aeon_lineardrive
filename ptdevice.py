"""Com Linear drive device class."""
from micropython import const
from machine import Pin, Timer

from microharp.device import HarpDevice
from microharp.types import HarpTypes
from microharp.register import ReadWriteReg, OperationalCtrlReg
from microharp.event import LooseEvent

from fhdrive import FaulhaberDrive
from ptregisters import EnableReg, PositionLimReg, PositionHomeReg, \
    PositionSetReg, PositionActReg, SpeedLimReg, VelocitySetReg, \
    VelocityActReg, ContCurLimReg, PeakCurLimReg, PosLimEnReg


class PtDevice(HarpDevice):
    """Com Linear drive Harp device."""
#    R_BELT_ENA = const(32)
#    R_BELT_VSET = const(33)
#    R_BELT_VACT = const(34)

    R_DRV_ENA = const(40)
    R_DRV_PLIM = const(41)
    R_DRV_HOME = const(42)
    R_DRV_PSET = const(43)
    R_DRV_PACT = const(44)
    R_DRV_SLIM = const(45)
    R_DRV_CCLIM = const(46)
    R_DRV_PCLIM = const(47)
    R_DRV_PLIMENA = const(48)
    R_DRV_VSET = const(33)
    R_DRV_VACT = const(34)

#    def __init__(self, stream, sync, led, uart, estop, trace=False):
    def __init__(self, stream, sync, led, uart, trace=False):
        """Constructor.

        Connects the logical device to its physical interfaces, creates the drives and register map.
        """
        super().__init__(stream, sync, led, trace=trace)

        self.drives = FaulhaberDrive(uart, 2)

        registers = {
            HarpDevice.R_DEVICE_NAME: ReadWriteReg(HarpTypes.U8, tuple(b'Rotary Joint Linear drive')),

            PtDevice.R_DRV_ENA: EnableReg(self.drives),
            PtDevice.R_DRV_PLIM: PositionLimReg(self.drives),
            PtDevice.R_DRV_HOME: PositionHomeReg(self.drives),
            PtDevice.R_DRV_PSET: PositionSetReg(self.drives),
            PtDevice.R_DRV_PACT: PositionActReg(self.drives),
            PtDevice.R_DRV_SLIM: SpeedLimReg(self.drives),
            PtDevice.R_DRV_VSET: VelocitySetReg(self.drives),
            PtDevice.R_DRV_VACT: VelocityActReg(self.drives),
            PtDevice.R_DRV_CCLIM: ContCurLimReg(self.drives),
            PtDevice.R_DRV_PCLIM: PeakCurLimReg(self.drives),
            PtDevice.R_DRV_PLIMENA: PosLimEnReg(self.drives)
            
        }
        self.registers.update(registers)


        self.positionEvent = LooseEvent(
            PtDevice.R_DRV_PACT, self.registers[PtDevice.R_DRV_PACT].typ, self.rxMessages)
        Timer(period=100, callback=self.positionEvent.callback)

#        estop.irq(handler=self._estop_irq, trigger=Pin.IRQ_RISING)

    def _ctrl_hook(self):
        """Private member function.

        Control register write hook, updates device state.
        """
        super()._ctrl_hook()

        if self.registers[HarpDevice.R_OPERATION_CTRL].OP_MODE != OperationalCtrlReg.STANDBY_MODE:
#            self.velocityEvent.enabled = True
            self.positionEvent.enabled = True
#            self.positionEvent.enabled = False
        else:
#            self.velocityEvent.enabled = False
            self.positionEvent.enabled = False

#    def _estop_irq(self, ins):
#        """Private member function.
#
#        Stop pin interrupt handler, disables all drives.
#        """
#        for drive in self.drives:
#            drive.en = False

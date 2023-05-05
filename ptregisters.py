"""Pertubation treadmill register classes."""
from microharp.types import HarpTypes
from microharp.register import ReadWriteReg, ReadOnlyReg


class EnableReg(ReadWriteReg):

    """Pertubation treadmill EnableReg register.

    Non-zero writes enable the drive, writes of zero disable the drive,
    Reads return (1,) or (0,) for the enabled or disabled states respectively.
    """

    def __init__(self, drive, estop):
        super().__init__(HarpTypes.U8)
        self.drive = drive
        self.estop = estop

    def read(self, typ):
        self.value = (int(self.drive.en),)
        return super().read(typ)

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.en = bool(self.value[0])# and not self.estop.value()


class PositionLimReg(ReadWriteReg):

    """Pertubation treadmill PositionLimReg register.

    Writes set the position limits of drive, reads return the set limits.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S32, (-1000, 160000))
        self.drive = drive
        self.write(self.typ, self.value)

    def read(self, typ):
        neglimit, poslimit = self.drive.neglimit, self.drive.poslimit
        if neglimit is not None and poslimit is not None:
            self.value = (neglimit, poslimit)
        return super().read(typ)

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.neglimit = self.value[0]
        self.drive.poslimit = self.value[1]


class PositionHomeReg(ReadWriteReg):

    """Pertubation treadmill PositionHomeReg register.

    Writes set the home position of the drive, reads return the previous write value.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S32)
        self.drive = drive

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.home = self.value[0]


class PositionSetReg(ReadWriteReg):

    """Pertubation treadmill PositionSetReg register.

    Writes set the absolute position of drive, reads return the previous write value.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S32)
        self.drive = drive

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.position = self.value[0]


class PositionActReg(ReadOnlyReg):

    """Pertubation treadmill PositionActReg register.

    Reads return the current position of drive.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S32)
        self.drive = drive

    def read(self, typ):
        position = self.drive.position
        if position is not None:
            self.value = (position,)
        return super().read(typ)


class SpeedLimReg(ReadWriteReg):

    """Pertubation treadmill SpeedLimReg register.

    Writes set the speed limit of drive, reads return the limit.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.U16, (2000,))
        self.drive = drive
        self.drive.speed = self.value[0]

    def read(self, typ):
        speed = self.drive.speed
        if speed is not None:
            self.value = (speed,)
        return super().read(typ)

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.speed = self.value[0]


class VelocitySetReg(ReadWriteReg):

    """Pertubation treadmill VelocitySetReg register.

    Writes set the velocity of drive, reads return the previous write value.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S16)
        self.drive = drive

    def write(self, typ, value):
        super().write(typ, value)
        self.drive.velocity = self.value[0]


class VelocityActReg(ReadOnlyReg):

    """Pertubation treadmill VelocityActReg register.

    Reads return the current velocity of drive.
    """

    def __init__(self, drive):
        super().__init__(HarpTypes.S16)
        self.drive = drive

    def read(self, typ):
        velocity = self.drive.velocity
        if velocity is not None:
            self.value = (velocity,)
        return super().read(typ)

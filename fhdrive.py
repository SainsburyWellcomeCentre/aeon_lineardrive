"""Faulhaber drive class."""
import re


class FaulhaberDrive():
    """Faulhaber drive class."""

    @property
    def en(self):
        return self._en

    @en.setter
    def en(self, value):
        self._en = value
        self._command('EN' if self._en else 'DI')

    @property
    def home(self):
        return self._query('POS')

    @home.setter
    def home(self, value):
        self._parameter('HO', value)

    @property
    def position(self):
        return self._query('POS')

    @position.setter
    def position(self, value):
        self._parameter('LA', value)
        self._command('M')

    @property
    def poslimit(self):
        return self._query('GPL')

    @poslimit.setter
    def poslimit(self, value):
        self._parameter('LL', value)

    @property
    def neglimit(self):
        return self._query('GNL')

    @neglimit.setter
    def neglimit(self, value):
        self._parameter('LL', value)

    @property
    def velocity(self):
        return self._query('GN')

    @velocity.setter
    def velocity(self, value):
        self._parameter('V', value)

    @property
    def speed(self):
        return self._query('GSP')

    @speed.setter
    def speed(self, value):
        self._parameter('SP', value)

    def __init__(self, uart, address):
        """Constructor. Initialises the class."""
        self.uart = uart
        self.address = address
        self.regex = re.compile(b'-?\d+')

    def _command(self, command):
        """Send a command."""
        self.uart.write(f'{self.address}{command}\r')

    def _parameter(self, parameter, value):
        """Set parameter to value."""
        self.uart.write(f'{self.address}{parameter}{value}\r')

    def _query(self, query):
        """Send query and return the parameter value fron the response."""
        self.uart.write(f'{self.address}{query}\r')
        response = self.uart.readline()
        if response is not None:
            match = self.regex.search(response)
            response = int(match.group(0)) if match is not None else None
        return response

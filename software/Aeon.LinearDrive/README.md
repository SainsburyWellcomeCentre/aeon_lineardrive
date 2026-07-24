## About

`Aeon.LinearDrive` provides an asynchronous API and reactive operators for data acquisition and control of Aeon LinearDrive devices.

## How to Use

To use `Aeon.LinearDrive` for visual reactive programming, please install this package using the [Bonsai package manager](https://bonsai-rx.org/docs/articles/packages.html).

The package can also be used from any .NET application:
```c#
using Aeon.LinearDrive;

using var device = await Device.CreateAsync("COM3");
var whoAmI = await device.ReadWhoAmIAsync();
var deviceName = await device.ReadDeviceNameAsync();
var timestamp = await device.ReadTimestampSecondsAsync();
Console.WriteLine($"{deviceName} WhoAmI: {whoAmI} Timestamp (s): {timestamp}");
```

## Feedback & Contributing

`Aeon.LinearDrive` is released as open-source under the [BSD 3-Clause license](https://licenses.nuget.org/BSD-3-Clause). Bug reports and contributions are welcome at [the GitHub repository](https://github.com/SainsburyWellcomeCentre/aeon_lineardrive).

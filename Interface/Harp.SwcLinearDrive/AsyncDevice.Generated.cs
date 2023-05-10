using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.SwcLinearDrive
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with SwcLinearDrive devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a SwcLinearDrive device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with SwcLinearDrive devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableMotorDriver register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<EnableFlag> ReadEnableMotorDriverAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableMotorDriver.Address));
            return EnableMotorDriver.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableMotorDriver register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<EnableFlag>> ReadTimestampedEnableMotorDriverAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableMotorDriver.Address));
            return EnableMotorDriver.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableMotorDriver register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableMotorDriverAsync(EnableFlag value)
        {
            var request = EnableMotorDriver.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the LimitPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<LimitPositionPayload> ReadLimitPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(LimitPosition.Address));
            return LimitPosition.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the LimitPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<LimitPositionPayload>> ReadTimestampedLimitPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(LimitPosition.Address));
            return LimitPosition.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the LimitPosition register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLimitPositionAsync(LimitPositionPayload value)
        {
            var request = LimitPosition.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the HomePosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<int> ReadHomePositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(HomePosition.Address));
            return HomePosition.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the HomePosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<int>> ReadTimestampedHomePositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(HomePosition.Address));
            return HomePosition.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the HomePosition register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteHomePositionAsync(int value)
        {
            var request = HomePosition.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the SetPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<int> ReadSetPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(SetPosition.Address));
            return SetPosition.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the SetPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<int>> ReadTimestampedSetPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(SetPosition.Address));
            return SetPosition.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the SetPosition register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteSetPositionAsync(int value)
        {
            var request = SetPosition.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Position register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<int> ReadPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(Position.Address));
            return Position.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Position register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<int>> ReadTimestampedPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt32(Position.Address));
            return Position.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the LimitSpeed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLimitSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitSpeed.Address));
            return LimitSpeed.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the LimitSpeed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLimitSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitSpeed.Address));
            return LimitSpeed.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the LimitSpeed register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLimitSpeedAsync(ushort value)
        {
            var request = LimitSpeed.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the SetSpeed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<short> ReadSetSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(SetSpeed.Address));
            return SetSpeed.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the SetSpeed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<short>> ReadTimestampedSetSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(SetSpeed.Address));
            return SetSpeed.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the SetSpeed register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteSetSpeedAsync(short value)
        {
            var request = SetSpeed.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Speed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<short> ReadSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(Speed.Address));
            return Speed.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Speed register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<short>> ReadTimestampedSpeedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadInt16(Speed.Address));
            return Speed.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the LimitContinuousCurrent register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLimitContinuousCurrentAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitContinuousCurrent.Address));
            return LimitContinuousCurrent.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the LimitContinuousCurrent register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLimitContinuousCurrentAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitContinuousCurrent.Address));
            return LimitContinuousCurrent.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the LimitContinuousCurrent register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLimitContinuousCurrentAsync(ushort value)
        {
            var request = LimitContinuousCurrent.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the LimitPeakCurrent register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadLimitPeakCurrentAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitPeakCurrent.Address));
            return LimitPeakCurrent.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the LimitPeakCurrent register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedLimitPeakCurrentAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(LimitPeakCurrent.Address));
            return LimitPeakCurrent.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the LimitPeakCurrent register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteLimitPeakCurrentAsync(ushort value)
        {
            var request = LimitPeakCurrent.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the EnableLimitPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<EnableFlag> ReadEnableLimitPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLimitPosition.Address));
            return EnableLimitPosition.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the EnableLimitPosition register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<EnableFlag>> ReadTimestampedEnableLimitPositionAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(EnableLimitPosition.Address));
            return EnableLimitPosition.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the EnableLimitPosition register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteEnableLimitPositionAsync(EnableFlag value)
        {
            var request = EnableLimitPosition.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }
    }
}

using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Aeon.LinearDrive
{
    /// <summary>
    /// Generates events and processes commands for the LinearDrive device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the LinearDrive device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="LinearDrive"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(LinearDrive);

        /// <summary>
        /// Gets a read-only mapping from address to register type.
        /// </summary>
        public static new IReadOnlyDictionary<int, Type> RegisterMap { get; } = new Dictionary<int, Type>
            (Bonsai.Harp.Device.RegisterMap.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            { 40, typeof(EnableMotorDriver) },
            { 41, typeof(LimitPosition) },
            { 42, typeof(HomePosition) },
            { 43, typeof(SetPosition) },
            { 44, typeof(Position) },
            { 45, typeof(LimitSpeed) },
            { 33, typeof(SetSpeed) },
            { 34, typeof(Speed) },
            { 46, typeof(LimitContinuousCurrent) },
            { 47, typeof(LimitPeakCurrent) },
            { 48, typeof(EnableLimitPosition) }
        };
    }

    /// <summary>
    /// Represents an operator that groups the sequence of <see cref="LinearDrive"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of LinearDrive messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="LinearDrive"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="LinearDrive"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="LinearDrive"/> device.
    /// </summary>
    /// <seealso cref="EnableMotorDriver"/>
    /// <seealso cref="LimitPosition"/>
    /// <seealso cref="HomePosition"/>
    /// <seealso cref="SetPosition"/>
    /// <seealso cref="Position"/>
    /// <seealso cref="LimitSpeed"/>
    /// <seealso cref="SetSpeed"/>
    /// <seealso cref="Speed"/>
    /// <seealso cref="LimitContinuousCurrent"/>
    /// <seealso cref="LimitPeakCurrent"/>
    /// <seealso cref="EnableLimitPosition"/>
    [XmlInclude(typeof(EnableMotorDriver))]
    [XmlInclude(typeof(LimitPosition))]
    [XmlInclude(typeof(HomePosition))]
    [XmlInclude(typeof(SetPosition))]
    [XmlInclude(typeof(Position))]
    [XmlInclude(typeof(LimitSpeed))]
    [XmlInclude(typeof(SetSpeed))]
    [XmlInclude(typeof(Speed))]
    [XmlInclude(typeof(LimitContinuousCurrent))]
    [XmlInclude(typeof(LimitPeakCurrent))]
    [XmlInclude(typeof(EnableLimitPosition))]
    [Description("Filters register-specific messages reported by the LinearDrive device.")]
    public class FilterRegister : FilterRegisterBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterRegister"/> class.
        /// </summary>
        public FilterRegister()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name
        {
            get => $"{nameof(LinearDrive)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the LinearDrive device.
    /// </summary>
    /// <seealso cref="EnableMotorDriver"/>
    /// <seealso cref="LimitPosition"/>
    /// <seealso cref="HomePosition"/>
    /// <seealso cref="SetPosition"/>
    /// <seealso cref="Position"/>
    /// <seealso cref="LimitSpeed"/>
    /// <seealso cref="SetSpeed"/>
    /// <seealso cref="Speed"/>
    /// <seealso cref="LimitContinuousCurrent"/>
    /// <seealso cref="LimitPeakCurrent"/>
    /// <seealso cref="EnableLimitPosition"/>
    [XmlInclude(typeof(EnableMotorDriver))]
    [XmlInclude(typeof(LimitPosition))]
    [XmlInclude(typeof(HomePosition))]
    [XmlInclude(typeof(SetPosition))]
    [XmlInclude(typeof(Position))]
    [XmlInclude(typeof(LimitSpeed))]
    [XmlInclude(typeof(SetSpeed))]
    [XmlInclude(typeof(Speed))]
    [XmlInclude(typeof(LimitContinuousCurrent))]
    [XmlInclude(typeof(LimitPeakCurrent))]
    [XmlInclude(typeof(EnableLimitPosition))]
    [XmlInclude(typeof(TimestampedEnableMotorDriver))]
    [XmlInclude(typeof(TimestampedLimitPosition))]
    [XmlInclude(typeof(TimestampedHomePosition))]
    [XmlInclude(typeof(TimestampedSetPosition))]
    [XmlInclude(typeof(TimestampedPosition))]
    [XmlInclude(typeof(TimestampedLimitSpeed))]
    [XmlInclude(typeof(TimestampedSetSpeed))]
    [XmlInclude(typeof(TimestampedSpeed))]
    [XmlInclude(typeof(TimestampedLimitContinuousCurrent))]
    [XmlInclude(typeof(TimestampedLimitPeakCurrent))]
    [XmlInclude(typeof(TimestampedEnableLimitPosition))]
    [Description("Filters and selects specific messages reported by the LinearDrive device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name => $"{nameof(LinearDrive)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// LinearDrive register messages.
    /// </summary>
    /// <seealso cref="EnableMotorDriver"/>
    /// <seealso cref="LimitPosition"/>
    /// <seealso cref="HomePosition"/>
    /// <seealso cref="SetPosition"/>
    /// <seealso cref="Position"/>
    /// <seealso cref="LimitSpeed"/>
    /// <seealso cref="SetSpeed"/>
    /// <seealso cref="Speed"/>
    /// <seealso cref="LimitContinuousCurrent"/>
    /// <seealso cref="LimitPeakCurrent"/>
    /// <seealso cref="EnableLimitPosition"/>
    [XmlInclude(typeof(EnableMotorDriver))]
    [XmlInclude(typeof(LimitPosition))]
    [XmlInclude(typeof(HomePosition))]
    [XmlInclude(typeof(SetPosition))]
    [XmlInclude(typeof(Position))]
    [XmlInclude(typeof(LimitSpeed))]
    [XmlInclude(typeof(SetSpeed))]
    [XmlInclude(typeof(Speed))]
    [XmlInclude(typeof(LimitContinuousCurrent))]
    [XmlInclude(typeof(LimitPeakCurrent))]
    [XmlInclude(typeof(EnableLimitPosition))]
    [Description("Formats a sequence of values as specific LinearDrive register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name => $"{nameof(LinearDrive)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents a register that enables the motor driver.
    /// </summary>
    [Description("Enables the motor driver.")]
    public partial class EnableMotorDriver
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableMotorDriver"/> register. This field is constant.
        /// </summary>
        public const int Address = 40;

        /// <summary>
        /// Represents the payload type of the <see cref="EnableMotorDriver"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="EnableMotorDriver"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="EnableMotorDriver"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static EnableFlag GetPayload(HarpMessage message)
        {
            return (EnableFlag)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="EnableMotorDriver"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EnableFlag> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((EnableFlag)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="EnableMotorDriver"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableMotorDriver"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, EnableFlag value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="EnableMotorDriver"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableMotorDriver"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, EnableFlag value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// EnableMotorDriver register.
    /// </summary>
    /// <seealso cref="EnableMotorDriver"/>
    [Description("Filters and selects timestamped messages from the EnableMotorDriver register.")]
    public partial class TimestampedEnableMotorDriver
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableMotorDriver"/> register. This field is constant.
        /// </summary>
        public const int Address = EnableMotorDriver.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="EnableMotorDriver"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EnableFlag> GetPayload(HarpMessage message)
        {
            return EnableMotorDriver.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the position limits of the motor.
    /// </summary>
    [Description("Configures the position limits of the motor.")]
    public partial class LimitPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = 41;

        /// <summary>
        /// Represents the payload type of the <see cref="LimitPosition"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S32;

        /// <summary>
        /// Represents the length of the <see cref="LimitPosition"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 2;

        static LimitPositionPayload ParsePayload(int[] payload)
        {
            LimitPositionPayload result;
            result.Minimum = payload[0];
            result.Maximum = payload[1];
            return result;
        }

        static int[] FormatPayload(LimitPositionPayload value)
        {
            int[] result;
            result = new int[2];
            result[0] = value.Minimum;
            result[1] = value.Maximum;
            return result;
        }

        /// <summary>
        /// Returns the payload data for <see cref="LimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static LimitPositionPayload GetPayload(HarpMessage message)
        {
            return ParsePayload(message.GetPayloadArray<int>());
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<LimitPositionPayload> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadArray<int>();
            return Timestamped.Create(ParsePayload(payload.Value), payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="LimitPosition"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitPosition"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, LimitPositionPayload value)
        {
            return HarpMessage.FromInt32(Address, messageType, FormatPayload(value));
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="LimitPosition"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitPosition"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, LimitPositionPayload value)
        {
            return HarpMessage.FromInt32(Address, timestamp, messageType, FormatPayload(value));
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// LimitPosition register.
    /// </summary>
    /// <seealso cref="LimitPosition"/>
    [Description("Filters and selects timestamped messages from the LimitPosition register.")]
    public partial class TimestampedLimitPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = LimitPosition.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="LimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<LimitPositionPayload> GetPayload(HarpMessage message)
        {
            return LimitPosition.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the home position of the motor.
    /// </summary>
    [Description("Sets the home position of the motor.")]
    public partial class HomePosition
    {
        /// <summary>
        /// Represents the address of the <see cref="HomePosition"/> register. This field is constant.
        /// </summary>
        public const int Address = 42;

        /// <summary>
        /// Represents the payload type of the <see cref="HomePosition"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S32;

        /// <summary>
        /// Represents the length of the <see cref="HomePosition"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="HomePosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static int GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="HomePosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="HomePosition"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="HomePosition"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="HomePosition"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="HomePosition"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// HomePosition register.
    /// </summary>
    /// <seealso cref="HomePosition"/>
    [Description("Filters and selects timestamped messages from the HomePosition register.")]
    public partial class TimestampedHomePosition
    {
        /// <summary>
        /// Represents the address of the <see cref="HomePosition"/> register. This field is constant.
        /// </summary>
        public const int Address = HomePosition.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="HomePosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetPayload(HarpMessage message)
        {
            return HomePosition.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the current position of the motor. Reads return the last instruction.
    /// </summary>
    [Description("Sets the current position of the motor. Reads return the last instruction.")]
    public partial class SetPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="SetPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = 43;

        /// <summary>
        /// Represents the payload type of the <see cref="SetPosition"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S32;

        /// <summary>
        /// Represents the length of the <see cref="SetPosition"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="SetPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static int GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="SetPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="SetPosition"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="SetPosition"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="SetPosition"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="SetPosition"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// SetPosition register.
    /// </summary>
    /// <seealso cref="SetPosition"/>
    [Description("Filters and selects timestamped messages from the SetPosition register.")]
    public partial class TimestampedSetPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="SetPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = SetPosition.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="SetPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetPayload(HarpMessage message)
        {
            return SetPosition.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that returns a periodic event with the current position of the motor.
    /// </summary>
    [Description("Returns a periodic event with the current position of the motor.")]
    public partial class Position
    {
        /// <summary>
        /// Represents the address of the <see cref="Position"/> register. This field is constant.
        /// </summary>
        public const int Address = 44;

        /// <summary>
        /// Represents the payload type of the <see cref="Position"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S32;

        /// <summary>
        /// Represents the length of the <see cref="Position"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Position"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static int GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Position"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Position"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Position"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Position"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Position"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, int value)
        {
            return HarpMessage.FromInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Position register.
    /// </summary>
    /// <seealso cref="Position"/>
    [Description("Filters and selects timestamped messages from the Position register.")]
    public partial class TimestampedPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="Position"/> register. This field is constant.
        /// </summary>
        public const int Address = Position.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Position"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<int> GetPayload(HarpMessage message)
        {
            return Position.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the maximum speed of the motor.
    /// </summary>
    [Description("Sets the maximum speed of the motor.")]
    public partial class LimitSpeed
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitSpeed"/> register. This field is constant.
        /// </summary>
        public const int Address = 45;

        /// <summary>
        /// Represents the payload type of the <see cref="LimitSpeed"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="LimitSpeed"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="LimitSpeed"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitSpeed"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="LimitSpeed"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitSpeed"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// LimitSpeed register.
    /// </summary>
    /// <seealso cref="LimitSpeed"/>
    [Description("Filters and selects timestamped messages from the LimitSpeed register.")]
    public partial class TimestampedLimitSpeed
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitSpeed"/> register. This field is constant.
        /// </summary>
        public const int Address = LimitSpeed.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="LimitSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return LimitSpeed.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the current speed of the motor.
    /// </summary>
    [Description("Sets the current speed of the motor.")]
    public partial class SetSpeed
    {
        /// <summary>
        /// Represents the address of the <see cref="SetSpeed"/> register. This field is constant.
        /// </summary>
        public const int Address = 33;

        /// <summary>
        /// Represents the payload type of the <see cref="SetSpeed"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="SetSpeed"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="SetSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="SetSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="SetSpeed"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="SetSpeed"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="SetSpeed"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="SetSpeed"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// SetSpeed register.
    /// </summary>
    /// <seealso cref="SetSpeed"/>
    [Description("Filters and selects timestamped messages from the SetSpeed register.")]
    public partial class TimestampedSetSpeed
    {
        /// <summary>
        /// Represents the address of the <see cref="SetSpeed"/> register. This field is constant.
        /// </summary>
        public const int Address = SetSpeed.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="SetSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetPayload(HarpMessage message)
        {
            return SetSpeed.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that returns a periodic event with the current (mA) speed of the motor.
    /// </summary>
    [Description("Returns a periodic event with the current (mA) speed of the motor.")]
    public partial class Speed
    {
        /// <summary>
        /// Represents the address of the <see cref="Speed"/> register. This field is constant.
        /// </summary>
        public const int Address = 34;

        /// <summary>
        /// Represents the payload type of the <see cref="Speed"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="Speed"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Speed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Speed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Speed"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Speed"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Speed"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Speed"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Speed register.
    /// </summary>
    /// <seealso cref="Speed"/>
    [Description("Filters and selects timestamped messages from the Speed register.")]
    public partial class TimestampedSpeed
    {
        /// <summary>
        /// Represents the address of the <see cref="Speed"/> register. This field is constant.
        /// </summary>
        public const int Address = Speed.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Speed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetPayload(HarpMessage message)
        {
            return Speed.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the maximum continuous current (mA) limit the drive is able to supply.
    /// </summary>
    [Description("Sets the maximum continuous current (mA) limit the drive is able to supply.")]
    public partial class LimitContinuousCurrent
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const int Address = 46;

        /// <summary>
        /// Represents the payload type of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitContinuousCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitContinuousCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="LimitContinuousCurrent"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitContinuousCurrent"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="LimitContinuousCurrent"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitContinuousCurrent"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// LimitContinuousCurrent register.
    /// </summary>
    /// <seealso cref="LimitContinuousCurrent"/>
    [Description("Filters and selects timestamped messages from the LimitContinuousCurrent register.")]
    public partial class TimestampedLimitContinuousCurrent
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const int Address = LimitContinuousCurrent.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="LimitContinuousCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return LimitContinuousCurrent.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the maximum peak current limit the drive is able to supply.
    /// </summary>
    [Description("Sets the maximum peak current limit the drive is able to supply.")]
    public partial class LimitPeakCurrent
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitPeakCurrent"/> register. This field is constant.
        /// </summary>
        public const int Address = 47;

        /// <summary>
        /// Represents the payload type of the <see cref="LimitPeakCurrent"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="LimitPeakCurrent"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitPeakCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitPeakCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="LimitPeakCurrent"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitPeakCurrent"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="LimitPeakCurrent"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="LimitPeakCurrent"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// LimitPeakCurrent register.
    /// </summary>
    /// <seealso cref="LimitPeakCurrent"/>
    [Description("Filters and selects timestamped messages from the LimitPeakCurrent register.")]
    public partial class TimestampedLimitPeakCurrent
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitPeakCurrent"/> register. This field is constant.
        /// </summary>
        public const int Address = LimitPeakCurrent.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="LimitPeakCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return LimitPeakCurrent.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that enables the position limit.
    /// </summary>
    [Description("Enables the position limit.")]
    public partial class EnableLimitPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableLimitPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = 48;

        /// <summary>
        /// Represents the payload type of the <see cref="EnableLimitPosition"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="EnableLimitPosition"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="EnableLimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static EnableFlag GetPayload(HarpMessage message)
        {
            return (EnableFlag)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="EnableLimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EnableFlag> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((EnableFlag)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="EnableLimitPosition"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableLimitPosition"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, EnableFlag value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="EnableLimitPosition"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="EnableLimitPosition"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, EnableFlag value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// EnableLimitPosition register.
    /// </summary>
    /// <seealso cref="EnableLimitPosition"/>
    [Description("Filters and selects timestamped messages from the EnableLimitPosition register.")]
    public partial class TimestampedEnableLimitPosition
    {
        /// <summary>
        /// Represents the address of the <see cref="EnableLimitPosition"/> register. This field is constant.
        /// </summary>
        public const int Address = EnableLimitPosition.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="EnableLimitPosition"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EnableFlag> GetPayload(HarpMessage message)
        {
            return EnableLimitPosition.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents an operator which creates standard message payloads for the
    /// LinearDrive device.
    /// </summary>
    /// <seealso cref="CreateEnableMotorDriverPayload"/>
    /// <seealso cref="CreateLimitPositionPayload"/>
    /// <seealso cref="CreateHomePositionPayload"/>
    /// <seealso cref="CreateSetPositionPayload"/>
    /// <seealso cref="CreatePositionPayload"/>
    /// <seealso cref="CreateLimitSpeedPayload"/>
    /// <seealso cref="CreateSetSpeedPayload"/>
    /// <seealso cref="CreateSpeedPayload"/>
    /// <seealso cref="CreateLimitContinuousCurrentPayload"/>
    /// <seealso cref="CreateLimitPeakCurrentPayload"/>
    /// <seealso cref="CreateEnableLimitPositionPayload"/>
    [XmlInclude(typeof(CreateEnableMotorDriverPayload))]
    [XmlInclude(typeof(CreateLimitPositionPayload))]
    [XmlInclude(typeof(CreateHomePositionPayload))]
    [XmlInclude(typeof(CreateSetPositionPayload))]
    [XmlInclude(typeof(CreatePositionPayload))]
    [XmlInclude(typeof(CreateLimitSpeedPayload))]
    [XmlInclude(typeof(CreateSetSpeedPayload))]
    [XmlInclude(typeof(CreateSpeedPayload))]
    [XmlInclude(typeof(CreateLimitContinuousCurrentPayload))]
    [XmlInclude(typeof(CreateLimitPeakCurrentPayload))]
    [XmlInclude(typeof(CreateEnableLimitPositionPayload))]
    [XmlInclude(typeof(CreateTimestampedEnableMotorDriverPayload))]
    [XmlInclude(typeof(CreateTimestampedLimitPositionPayload))]
    [XmlInclude(typeof(CreateTimestampedHomePositionPayload))]
    [XmlInclude(typeof(CreateTimestampedSetPositionPayload))]
    [XmlInclude(typeof(CreateTimestampedPositionPayload))]
    [XmlInclude(typeof(CreateTimestampedLimitSpeedPayload))]
    [XmlInclude(typeof(CreateTimestampedSetSpeedPayload))]
    [XmlInclude(typeof(CreateTimestampedSpeedPayload))]
    [XmlInclude(typeof(CreateTimestampedLimitContinuousCurrentPayload))]
    [XmlInclude(typeof(CreateTimestampedLimitPeakCurrentPayload))]
    [XmlInclude(typeof(CreateTimestampedEnableLimitPositionPayload))]
    [Description("Creates standard message payloads for the LinearDrive device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreateEnableMotorDriverPayload();
        }

        string INamedElement.Name => $"{nameof(LinearDrive)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that enables the motor driver.
    /// </summary>
    [DisplayName("EnableMotorDriverPayload")]
    [Description("Creates a message payload that enables the motor driver.")]
    public partial class CreateEnableMotorDriverPayload
    {
        /// <summary>
        /// Gets or sets the value that enables the motor driver.
        /// </summary>
        [Description("The value that enables the motor driver.")]
        public EnableFlag EnableMotorDriver { get; set; }

        /// <summary>
        /// Creates a message payload for the EnableMotorDriver register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public EnableFlag GetPayload()
        {
            return EnableMotorDriver;
        }

        /// <summary>
        /// Creates a message that enables the motor driver.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the EnableMotorDriver register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.EnableMotorDriver.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that enables the motor driver.
    /// </summary>
    [DisplayName("TimestampedEnableMotorDriverPayload")]
    [Description("Creates a timestamped message payload that enables the motor driver.")]
    public partial class CreateTimestampedEnableMotorDriverPayload : CreateEnableMotorDriverPayload
    {
        /// <summary>
        /// Creates a timestamped message that enables the motor driver.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the EnableMotorDriver register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.EnableMotorDriver.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the position limits of the motor.
    /// </summary>
    [DisplayName("LimitPositionPayload")]
    [Description("Creates a message payload that configures the position limits of the motor.")]
    public partial class CreateLimitPositionPayload
    {
        /// <summary>
        /// Gets or sets a value that the minimum allowed position of the motor.
        /// </summary>
        [Description("The minimum allowed position of the motor")]
        public int Minimum { get; set; } = -1000;

        /// <summary>
        /// Gets or sets a value that the maximum allowed position of the motor.
        /// </summary>
        [Description("The maximum allowed position of the motor")]
        public int Maximum { get; set; } = 160000;

        /// <summary>
        /// Creates a message payload for the LimitPosition register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public LimitPositionPayload GetPayload()
        {
            LimitPositionPayload value;
            value.Minimum = Minimum;
            value.Maximum = Maximum;
            return value;
        }

        /// <summary>
        /// Creates a message that configures the position limits of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the LimitPosition register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.LimitPosition.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the position limits of the motor.
    /// </summary>
    [DisplayName("TimestampedLimitPositionPayload")]
    [Description("Creates a timestamped message payload that configures the position limits of the motor.")]
    public partial class CreateTimestampedLimitPositionPayload : CreateLimitPositionPayload
    {
        /// <summary>
        /// Creates a timestamped message that configures the position limits of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the LimitPosition register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.LimitPosition.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the home position of the motor.
    /// </summary>
    [DisplayName("HomePositionPayload")]
    [Description("Creates a message payload that sets the home position of the motor.")]
    public partial class CreateHomePositionPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the home position of the motor.
        /// </summary>
        [Description("The value that sets the home position of the motor.")]
        public int HomePosition { get; set; }

        /// <summary>
        /// Creates a message payload for the HomePosition register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public int GetPayload()
        {
            return HomePosition;
        }

        /// <summary>
        /// Creates a message that sets the home position of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the HomePosition register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.HomePosition.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the home position of the motor.
    /// </summary>
    [DisplayName("TimestampedHomePositionPayload")]
    [Description("Creates a timestamped message payload that sets the home position of the motor.")]
    public partial class CreateTimestampedHomePositionPayload : CreateHomePositionPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the home position of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the HomePosition register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.HomePosition.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the current position of the motor. Reads return the last instruction.
    /// </summary>
    [DisplayName("SetPositionPayload")]
    [Description("Creates a message payload that sets the current position of the motor. Reads return the last instruction.")]
    public partial class CreateSetPositionPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        [Description("The value that sets the current position of the motor. Reads return the last instruction.")]
        public int SetPosition { get; set; }

        /// <summary>
        /// Creates a message payload for the SetPosition register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public int GetPayload()
        {
            return SetPosition;
        }

        /// <summary>
        /// Creates a message that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the SetPosition register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.SetPosition.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the current position of the motor. Reads return the last instruction.
    /// </summary>
    [DisplayName("TimestampedSetPositionPayload")]
    [Description("Creates a timestamped message payload that sets the current position of the motor. Reads return the last instruction.")]
    public partial class CreateTimestampedSetPositionPayload : CreateSetPositionPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the SetPosition register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.SetPosition.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that returns a periodic event with the current position of the motor.
    /// </summary>
    [DisplayName("PositionPayload")]
    [Description("Creates a message payload that returns a periodic event with the current position of the motor.")]
    public partial class CreatePositionPayload
    {
        /// <summary>
        /// Gets or sets the value that returns a periodic event with the current position of the motor.
        /// </summary>
        [Description("The value that returns a periodic event with the current position of the motor.")]
        public int Position { get; set; }

        /// <summary>
        /// Creates a message payload for the Position register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public int GetPayload()
        {
            return Position;
        }

        /// <summary>
        /// Creates a message that returns a periodic event with the current position of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the Position register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.Position.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that returns a periodic event with the current position of the motor.
    /// </summary>
    [DisplayName("TimestampedPositionPayload")]
    [Description("Creates a timestamped message payload that returns a periodic event with the current position of the motor.")]
    public partial class CreateTimestampedPositionPayload : CreatePositionPayload
    {
        /// <summary>
        /// Creates a timestamped message that returns a periodic event with the current position of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the Position register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.Position.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the maximum speed of the motor.
    /// </summary>
    [DisplayName("LimitSpeedPayload")]
    [Description("Creates a message payload that sets the maximum speed of the motor.")]
    public partial class CreateLimitSpeedPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum speed of the motor.
        /// </summary>
        [Description("The value that sets the maximum speed of the motor.")]
        public ushort LimitSpeed { get; set; } = 7583;

        /// <summary>
        /// Creates a message payload for the LimitSpeed register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return LimitSpeed;
        }

        /// <summary>
        /// Creates a message that sets the maximum speed of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the LimitSpeed register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.LimitSpeed.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the maximum speed of the motor.
    /// </summary>
    [DisplayName("TimestampedLimitSpeedPayload")]
    [Description("Creates a timestamped message payload that sets the maximum speed of the motor.")]
    public partial class CreateTimestampedLimitSpeedPayload : CreateLimitSpeedPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the maximum speed of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the LimitSpeed register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.LimitSpeed.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the current speed of the motor.
    /// </summary>
    [DisplayName("SetSpeedPayload")]
    [Description("Creates a message payload that sets the current speed of the motor.")]
    public partial class CreateSetSpeedPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the current speed of the motor.
        /// </summary>
        [Description("The value that sets the current speed of the motor.")]
        public short SetSpeed { get; set; }

        /// <summary>
        /// Creates a message payload for the SetSpeed register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public short GetPayload()
        {
            return SetSpeed;
        }

        /// <summary>
        /// Creates a message that sets the current speed of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the SetSpeed register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.SetSpeed.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the current speed of the motor.
    /// </summary>
    [DisplayName("TimestampedSetSpeedPayload")]
    [Description("Creates a timestamped message payload that sets the current speed of the motor.")]
    public partial class CreateTimestampedSetSpeedPayload : CreateSetSpeedPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the current speed of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the SetSpeed register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.SetSpeed.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that returns a periodic event with the current (mA) speed of the motor.
    /// </summary>
    [DisplayName("SpeedPayload")]
    [Description("Creates a message payload that returns a periodic event with the current (mA) speed of the motor.")]
    public partial class CreateSpeedPayload
    {
        /// <summary>
        /// Gets or sets the value that returns a periodic event with the current (mA) speed of the motor.
        /// </summary>
        [Description("The value that returns a periodic event with the current (mA) speed of the motor.")]
        public short Speed { get; set; }

        /// <summary>
        /// Creates a message payload for the Speed register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public short GetPayload()
        {
            return Speed;
        }

        /// <summary>
        /// Creates a message that returns a periodic event with the current (mA) speed of the motor.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the Speed register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.Speed.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that returns a periodic event with the current (mA) speed of the motor.
    /// </summary>
    [DisplayName("TimestampedSpeedPayload")]
    [Description("Creates a timestamped message payload that returns a periodic event with the current (mA) speed of the motor.")]
    public partial class CreateTimestampedSpeedPayload : CreateSpeedPayload
    {
        /// <summary>
        /// Creates a timestamped message that returns a periodic event with the current (mA) speed of the motor.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the Speed register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.Speed.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the maximum continuous current (mA) limit the drive is able to supply.
    /// </summary>
    [DisplayName("LimitContinuousCurrentPayload")]
    [Description("Creates a message payload that sets the maximum continuous current (mA) limit the drive is able to supply.")]
    public partial class CreateLimitContinuousCurrentPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum continuous current (mA) limit the drive is able to supply.
        /// </summary>
        [Description("The value that sets the maximum continuous current (mA) limit the drive is able to supply.")]
        public ushort LimitContinuousCurrent { get; set; } = 900;

        /// <summary>
        /// Creates a message payload for the LimitContinuousCurrent register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return LimitContinuousCurrent;
        }

        /// <summary>
        /// Creates a message that sets the maximum continuous current (mA) limit the drive is able to supply.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the LimitContinuousCurrent register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.LimitContinuousCurrent.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the maximum continuous current (mA) limit the drive is able to supply.
    /// </summary>
    [DisplayName("TimestampedLimitContinuousCurrentPayload")]
    [Description("Creates a timestamped message payload that sets the maximum continuous current (mA) limit the drive is able to supply.")]
    public partial class CreateTimestampedLimitContinuousCurrentPayload : CreateLimitContinuousCurrentPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the maximum continuous current (mA) limit the drive is able to supply.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the LimitContinuousCurrent register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.LimitContinuousCurrent.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the maximum peak current limit the drive is able to supply.
    /// </summary>
    [DisplayName("LimitPeakCurrentPayload")]
    [Description("Creates a message payload that sets the maximum peak current limit the drive is able to supply.")]
    public partial class CreateLimitPeakCurrentPayload
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        [Description("The value that sets the maximum peak current limit the drive is able to supply.")]
        public ushort LimitPeakCurrent { get; set; } = 900;

        /// <summary>
        /// Creates a message payload for the LimitPeakCurrent register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return LimitPeakCurrent;
        }

        /// <summary>
        /// Creates a message that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the LimitPeakCurrent register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.LimitPeakCurrent.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the maximum peak current limit the drive is able to supply.
    /// </summary>
    [DisplayName("TimestampedLimitPeakCurrentPayload")]
    [Description("Creates a timestamped message payload that sets the maximum peak current limit the drive is able to supply.")]
    public partial class CreateTimestampedLimitPeakCurrentPayload : CreateLimitPeakCurrentPayload
    {
        /// <summary>
        /// Creates a timestamped message that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the LimitPeakCurrent register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.LimitPeakCurrent.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that enables the position limit.
    /// </summary>
    [DisplayName("EnableLimitPositionPayload")]
    [Description("Creates a message payload that enables the position limit.")]
    public partial class CreateEnableLimitPositionPayload
    {
        /// <summary>
        /// Gets or sets the value that enables the position limit.
        /// </summary>
        [Description("The value that enables the position limit.")]
        public EnableFlag EnableLimitPosition { get; set; }

        /// <summary>
        /// Creates a message payload for the EnableLimitPosition register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public EnableFlag GetPayload()
        {
            return EnableLimitPosition;
        }

        /// <summary>
        /// Creates a message that enables the position limit.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the EnableLimitPosition register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Aeon.LinearDrive.EnableLimitPosition.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that enables the position limit.
    /// </summary>
    [DisplayName("TimestampedEnableLimitPositionPayload")]
    [Description("Creates a timestamped message payload that enables the position limit.")]
    public partial class CreateTimestampedEnableLimitPositionPayload : CreateEnableLimitPositionPayload
    {
        /// <summary>
        /// Creates a timestamped message that enables the position limit.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the EnableLimitPosition register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Aeon.LinearDrive.EnableLimitPosition.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents the payload of the LimitPosition register.
    /// </summary>
    public struct LimitPositionPayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitPositionPayload"/> structure.
        /// </summary>
        /// <param name="minimum">The minimum allowed position of the motor</param>
        /// <param name="maximum">The maximum allowed position of the motor</param>
        public LimitPositionPayload(
            int minimum,
            int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// The minimum allowed position of the motor
        /// </summary>
        public int Minimum;

        /// <summary>
        /// The maximum allowed position of the motor
        /// </summary>
        public int Maximum;
    }
}

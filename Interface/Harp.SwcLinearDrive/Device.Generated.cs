using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.SwcLinearDrive
{
    /// <summary>
    /// Generates events and processes commands for the SwcLinearDrive device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the SwcLinearDrive device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="SwcLinearDrive"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(SwcLinearDrive);

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
    /// Represents an operator that groups the sequence of <see cref="SwcLinearDrive"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of SwcLinearDrive messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="SwcLinearDrive"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="SwcLinearDrive"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="SwcLinearDrive"/> device.
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
    [Description("Filters register-specific messages reported by the SwcLinearDrive device.")]
    public class FilterMessage : FilterMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterMessage"/> class.
        /// </summary>
        public FilterMessage()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name
        {
            get => $"{nameof(SwcLinearDrive)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the SwcLinearDrive device.
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
    [Description("Filters and selects specific messages reported by the SwcLinearDrive device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name => $"{nameof(SwcLinearDrive)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// SwcLinearDrive register messages.
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
    [Description("Formats a sequence of values as specific SwcLinearDrive register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new EnableMotorDriver();
        }

        string INamedElement.Name => $"{nameof(SwcLinearDrive)}.{GetElementDisplayName(Register)}";
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
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="LimitSpeed"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitSpeed"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt16();
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
        public static HarpMessage FromPayload(MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
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
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
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
        public static Timestamped<short> GetPayload(HarpMessage message)
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
    /// Represents a register that returns a periodic event with the current speed of the motor.
    /// </summary>
    [Description("Returns a periodic event with the current speed of the motor.")]
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
    /// Represents a register that sets the maximum continuous current limit the drive is able to supply.
    /// </summary>
    [Description("Sets the maximum continuous current limit the drive is able to supply.")]
    public partial class LimitContinuousCurrent
    {
        /// <summary>
        /// Represents the address of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const int Address = 46;

        /// <summary>
        /// Represents the payload type of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="LimitContinuousCurrent"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitContinuousCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitContinuousCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt16();
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
        public static HarpMessage FromPayload(MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
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
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
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
        public static Timestamped<short> GetPayload(HarpMessage message)
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
        public const PayloadType RegisterType = PayloadType.S16;

        /// <summary>
        /// Represents the length of the <see cref="LimitPeakCurrent"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="LimitPeakCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static short GetPayload(HarpMessage message)
        {
            return message.GetPayloadInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="LimitPeakCurrent"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<short> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadInt16();
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
        public static HarpMessage FromPayload(MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, messageType, value);
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
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, short value)
        {
            return HarpMessage.FromInt16(Address, timestamp, messageType, value);
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
        public static Timestamped<short> GetPayload(HarpMessage message)
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
    /// SwcLinearDrive device.
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
    [Description("Creates standard message payloads for the SwcLinearDrive device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreateEnableMotorDriverPayload();
        }

        string INamedElement.Name => $"{nameof(SwcLinearDrive)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that enables the motor driver.
    /// </summary>
    [DisplayName("EnableMotorDriverPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that enables the motor driver.")]
    public partial class CreateEnableMotorDriverPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that enables the motor driver.
        /// </summary>
        [Description("The value that enables the motor driver.")]
        public EnableFlag Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that enables the motor driver.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that enables the motor driver.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => EnableMotorDriver.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that configures the position limits of the motor.
    /// </summary>
    [DisplayName("LimitPositionPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that configures the position limits of the motor.")]
    public partial class CreateLimitPositionPayload : HarpCombinator
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
        /// Creates an observable sequence that contains a single message
        /// that configures the position limits of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that configures the position limits of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ =>
            {
                LimitPositionPayload value;
                value.Minimum = Minimum;
                value.Maximum = Maximum;
                return LimitPosition.FromPayload(MessageType, value);
            });
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the home position of the motor.
    /// </summary>
    [DisplayName("HomePositionPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the home position of the motor.")]
    public partial class CreateHomePositionPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the home position of the motor.
        /// </summary>
        [Description("The value that sets the home position of the motor.")]
        public int Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the home position of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the home position of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => HomePosition.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the current position of the motor. Reads return the last instruction.
    /// </summary>
    [DisplayName("SetPositionPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the current position of the motor. Reads return the last instruction.")]
    public partial class CreateSetPositionPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        [Description("The value that sets the current position of the motor. Reads return the last instruction.")]
        public int Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the current position of the motor. Reads return the last instruction.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => SetPosition.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that returns a periodic event with the current position of the motor.
    /// </summary>
    [DisplayName("PositionPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that returns a periodic event with the current position of the motor.")]
    public partial class CreatePositionPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that returns a periodic event with the current position of the motor.
        /// </summary>
        [Description("The value that returns a periodic event with the current position of the motor.")]
        public int Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that returns a periodic event with the current position of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that returns a periodic event with the current position of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Position.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the maximum speed of the motor.
    /// </summary>
    [DisplayName("LimitSpeedPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the maximum speed of the motor.")]
    public partial class CreateLimitSpeedPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum speed of the motor.
        /// </summary>
        [Description("The value that sets the maximum speed of the motor.")]
        public short Value { get; set; } = 7583;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the maximum speed of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the maximum speed of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => LimitSpeed.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the current speed of the motor.
    /// </summary>
    [DisplayName("SetSpeedPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the current speed of the motor.")]
    public partial class CreateSetSpeedPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the current speed of the motor.
        /// </summary>
        [Description("The value that sets the current speed of the motor.")]
        public short Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the current speed of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the current speed of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => SetSpeed.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that returns a periodic event with the current speed of the motor.
    /// </summary>
    [DisplayName("SpeedPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that returns a periodic event with the current speed of the motor.")]
    public partial class CreateSpeedPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that returns a periodic event with the current speed of the motor.
        /// </summary>
        [Description("The value that returns a periodic event with the current speed of the motor.")]
        public short Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that returns a periodic event with the current speed of the motor.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that returns a periodic event with the current speed of the motor.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Speed.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the maximum continuous current limit the drive is able to supply.
    /// </summary>
    [DisplayName("LimitContinuousCurrentPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the maximum continuous current limit the drive is able to supply.")]
    public partial class CreateLimitContinuousCurrentPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum continuous current limit the drive is able to supply.
        /// </summary>
        [Description("The value that sets the maximum continuous current limit the drive is able to supply.")]
        public short Value { get; set; } = 900;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the maximum continuous current limit the drive is able to supply.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the maximum continuous current limit the drive is able to supply.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => LimitContinuousCurrent.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that sets the maximum peak current limit the drive is able to supply.
    /// </summary>
    [DisplayName("LimitPeakCurrentPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that sets the maximum peak current limit the drive is able to supply.")]
    public partial class CreateLimitPeakCurrentPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        [Description("The value that sets the maximum peak current limit the drive is able to supply.")]
        public short Value { get; set; } = 900;

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that sets the maximum peak current limit the drive is able to supply.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => LimitPeakCurrent.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that enables the position limit.
    /// </summary>
    [DisplayName("EnableLimitPositionPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that enables the position limit.")]
    public partial class CreateEnableLimitPositionPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that enables the position limit.
        /// </summary>
        [Description("The value that enables the position limit.")]
        public EnableFlag Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that enables the position limit.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that enables the position limit.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => EnableLimitPosition.FromPayload(MessageType, Value));
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

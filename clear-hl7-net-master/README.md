# clear-hl7-net
![GitHub](https://img.shields.io/github/license/davebronson/clear-hl7-net)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/davebronson/clear-hl7-net)
![GitHub last commit](https://img.shields.io/github/last-commit/davebronson/clear-hl7-net?logo=github)
![Nuget](https://img.shields.io/nuget/dt/ClearHl7?logo=nuget)

.NET HL7&reg; message generation and parsing library for the version 2.x standard

Understanding and programmatically building HL7 messages can be difficult.  clear-hl7-net takes pain out of this process by exposing an object hierarchy that is well structured, clearly named, and (most importantly) strongly-typed.

HL7&reg; is the registered trademark of Health Level Seven International, and the use of this trademark does not constitute an endorsement by HL7.

## Important Notes About Version 2 of clear-hl7-net
Upgrading from Version 1.x to Version 2? Please read some important notes about [Version 2](Version2.md) first.

## Getting Started
### Building clear-hl7-net
1. Clone the source code: `git clone https://github.com/davebronson/clear-hl7-net.git`
2. Open ClearHl7.sln in Visual Studio for Windows or Mac, or build from the command line

### Download From NuGet
* https://www.nuget.org/packages/ClearHl7
* https://www.nuget.org/packages/ClearHl7.Codes

### Targets
* .NET Standard 2.0
* .NET Standard 2.1
* .NET 5
* .NET 6
* .NET 7

## Supported HL7 Versions
Several versions exist for the HL7 Version 2.x messaging standard.  clear-hl7-net supports the following:
* 2.3
* 2.31
* 2.4
* 2.5
* 2.51
* 2.6
* 2.7
* 2.71
* 2.8
* 2.81
* 2.82
* 2.9

Use the matching namespace to target your desired HL7 version:
```csharp
using ClearHl7.V282;
using ClearHl7.V282.Segments;
using ClearHl7.V282.Types;
```

## HL7 Messages, Conceptually
HL7 Version 2.x messages consist of a collection of segments, with the MSH segment being required and appearing first.  Each segment is presented as a string on a single line, as a series of field values that are delimited with special characters indicating the position and nesting of each value.  Conceptually simple enough, but not very human-readable, and confusing to build correctly without the right tool.  clear-hl7-net represents this composition using a hierarchical class structure that is easy to interact with.  Pseudo example:
* Message
    * MSH Segment
        * Type
        * Type
    * PID Segment
        * Type
        * Type Collection
        * Type
    * PV1 Segment
        * Type
        * Type Collection
        * Type
            * Sub-Type (just a nested Type)
        * Type
            * Sub-Type

## Example: Building a Message
Let's build a sample `Message` containing the standard MSH `Segment`, and accompanied by PID, PVI, and Zxx `Segment`s.
```csharp
using ClearHl7;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V282;
using ClearHl7.V282.Segments;
using ClearHl7.V282.Types;

// [...]

// Build a new HL7 message
var message = new Message
{
    Segments = new ISegment[]
    {
        // Add an MSH segment - Message Header
        new MshSegment
        {
            SendingApplication = new HierarchicDesignator { NamespaceId = "Company EHR" },
            SendingFacility = new HierarchicDesignator { NamespaceId = "Company ABC" },
            ReceivingApplication = new HierarchicDesignator { NamespaceId = "HIE Application" },
            ReceivingFacility = new HierarchicDesignator { NamespaceId = "State HIE" },
            DateTimeOfMessage = DateTime.UtcNow,
            MessageControlId = "1234567890",

            // ADT message, Admit/visit notification
            MessageType = new MessageType { MessageCode = "ADT", TriggerEvent = "A01", MessageStructure = "ADT_A01" },

            // Production, Current processing transmitted at intervals
            ProcessingId = new ProcessingType { ProcessingId = "P", ProcessingMode = "T" }
        },

        // Add a PID segment - Patient Identification
        new PidSegment
        {
            Ordinal = 1, // Set the ordinal in each segment to indicate the ordering within a message
            SetIdPid = 1,
            PatientIdentifierList = new ExtendedCompositeIdWithCheckDigit[]
            {
                // Patient internal identifier
                new ExtendedCompositeIdWithCheckDigit { IdNumber = "P12345", IdentifierTypeCode = "PI" },

                // Patient external identifier
                new ExtendedCompositeIdWithCheckDigit { IdNumber = "A98765", IdentifierTypeCode = "PT" }
            },
            PatientName = new ExtendedPersonName[]
            {
                new ExtendedPersonName
                {
                    FamilyName = new FamilyName { Surname = "Anderson" },
                    GivenName = "Andy"
                }
            },
            DateTimeOfBirth = DateTime.Parse("1/1/1950 4:52:00"),
            PatientAddress = new ExtendedAddress[]
            {
                // Home address
                new ExtendedAddress
                {
                    StreetAddress = new StreetAddress { StreetOrMailingAddress = "123 Main Street" },
                    City = "Anywhere",
                    StateOrProvince = "FL",
                    ZipOrPostalCode = "33333"
                },

                // Alternate address
                new ExtendedAddress
                {
                    StreetAddress = new StreetAddress { StreetOrMailingAddress = "987 1st Avenue" },
                    City = "Somewhere",
                    StateOrProvince = "FL",
                    ZipOrPostalCode = "33333"
                }
            },
            PatientDeathIndicator = "N", // No
            PatientTelecommunicationInformation = new ExtendedTelecommunicationNumber[]
            {
                // Telephone
                new ExtendedTelecommunicationNumber { TelephoneNumber = "777-888-9999", TelecommunicationEquipmentType = "PH" },

                // Cellular or Mobile Phone
                new ExtendedTelecommunicationNumber { TelephoneNumber = "333-444-5555", TelecommunicationEquipmentType = "CP" }
            }
        },

        // Add a PV1 segment - Patient Visit
        new Pv1Segment
        {
            Ordinal = 2,
            PatientClass = new CodedWithExceptions { Identifier = "I" }, // Inpatient
            AdmissionType = new CodedWithExceptions { Identifier = "E" }, // Emergency
            ReadmissionIndicator = new CodedWithExceptions { Identifier = "R" }, // Re-admission
            AmbulatoryStatus = new CodedWithExceptions[]
            {
                new CodedWithExceptions { Identifier = "A2" }, // Ambulates with assistive device
                new CodedWithExceptions { Identifier = "A5" }, // Vision impaired
                new CodedWithExceptions { Identifier = "A6" }, // Hearing impaired
                new CodedWithExceptions { Identifier = "B3" }, // Amputee
            },
            AdmitDateTime = DateTime.Parse("1/1/2020 13:35:12"),
            CurrentPatientBalance = 1432.87M
        },

        // Add a Zxx segment (custom segment -> "ZPD")
        new ZxxSegment
        {
            Ordinal = 3,
            SegmentSuffix = "PD", // Use PD suffix for 'Patient Details'
            SegmentItems = new IType[]
            {
                new CodedWithExceptions { Identifier = "GREEN" },
                new ExtendedTelecommunicationNumber { CommunicationAddress = "andy.anderson@somewhere.com" },
                new CodedWithExceptions { Identifier = "Code1234" },
                new Text { Value = StringHelper.Escape("Anderson & Sons ~ Piano & Drywall Repair") } // String input? -> Then escape HL7 delimiters
            }
        }
    }
};

// there are two ways that you can serialize the structure into HL7 'pipehat' format:

// 1) Call MessageSerializer.Serialize()
// **********************************
string output = MessageSerializer.Serialize(message);

// 2) Call ToDelimitedString() on the Message instance
// **********************************
string output = message.ToDelimitedString();

// Outputs the following:
//     MSH|^~\&|Company EHR|Company ABC|HIE Application|State HIE|20201209022616||ADT^A01^ADT_A01|1234567890|P^T|2.8.2
//     PID|1||P12345^^^^PI~A98765^^^^PT||Anderson^Andy||19500101045200||||123 Main Street^^Anywhere^FL^33333~987 1st Avenue^^Somewhere^FL^33333|||||||||||||||||||N||||||||||777-888-9999^^PH~333-444-5555^^CP
//     PV1||I||E|||||||||R||A2~A5~A6~B3|||||||||||||||||||||||||||||20200101133512||1432.87
//     ZPD|GREEN|^^^andy.anderson@somewhere.com|Code1234|Anderson \T\ Sons \R\ Piano \T\ Drywall Repair
```

## Example: Parsing an HL7 'pipehat' String into a ClearHl7 Message
We've received an HL7 message string.  Let's deserialize it into a `Message` instance for integration elsewhere.
```csharp
using ClearHl7;
using ClearHl7.Serialization;
using ClearHl7.V282;

// [...]

string messageString = YourApp.ReceiveMessage();

// There are two ways that you can deserialize:

// 1) Call MessageSerializer.Deserialize(), which returns
//    a new Message instance
// **********************************
//    I don't know the HL7 version:
IMessage message = MessageSerializer.Deserialize(messageString);
//    I do know the HL7 version, or want to force a specific version:
IMessage message = MessageSerializer.Deserialize<V282.Message>(messageString);

// 2) Call FromDelimitedString() on an existing Message
//    instance, which performs the conversion in-place
// **********************************
IMessage message = new Message();
message.FromDelimitedString(messageString);
```

## Example: Detecting the HL7 Version for a Message String
Let's detect the HL7 version that is being used in an HL7 message string.
```csharp
using ClearHl7;
using ClearHl7.Helpers;

// [...]

// Where messageString = "MSH|^~\&||||||||||2.3||[...]"
string messageString = YourApp.ReceiveMessage();

// Get the version
Hl7Version version = MessageHelper.DetectVersion(messageString);

// Returns:
//     The enumeration value Hl7Version.V230
```

## Example: Creating an Instance of a ClearHl7 Message for a Specific Version
Let's create a Message instance with a specific HL7 version.
```csharp
using ClearHl7;
using ClearHl7.Helpers;

// [...]

// Create a new Message instance for V2.8.1
IMessage message = MessageHelper.NewInstance(Hl7Version.V281);

// Returns:
//      An instance of ClearHl7.V281.Message
```

## Customizing
### Delimiter Characters
The HL7 specification calls out default delimiters to use for fields (pipe `|`), components (caret `^`), subcomponents (ampersand `&`), escaping (backslash `\`), and repetition (tilde `~`).  Most will use these defaults.  But if the consumer of your messages supports it, it is possible to define your own delimiters.
```csharp
using ClearHl7;

// [...]

Configuration.FieldRepeatSeparator = "%"; // Use percent symbol
Configuration.SubcomponentSeparator = "/"; // Use forward slash

// Reset the separator configuration properties to their
// default, recommended values
Configuration.ResetSeparators();
```

## Using the ClearHl7.Codes Component
There are code systems published as part of the HL7 specification, which are recommended for use in your messages.  You have flexibility, of course, to use any coded values that you and your message consumer might agree upon.  To easily access the defined codes you may utilize the `ClearHl7.Codes` component, which contains enumerations for each.
```csharp
using ClearHl7.Codes.V282;
using ClearHl7.Codes.V282.Helpers;

// [...]

var helper = new EnumHelper();

// Example using the MaritalStatus and YesNoIndicator codes
// You must call EnumHelper.EnumToCode() to receive the
// actual coded string for a given enum value
pidSegment.MaritalStatus = new CodedWithExceptions
{
    Identifier = helper.EnumToCode(CodeMaritalStatus.Married)
};
pidSegment.MultipleBirthIndicator = helper.EnumToCode(CodeYesNoIndicator.No);
```

## Anything Else?
* `Segment`s, `Type`s, and collections are __not__ automatically initialized for you.  You must manually instantiate each object that you're going to read/write to.  But be a good steward of machine resources, and only instantiate objects that you'll interact with.
* Collection properties are all implemented with the `IEnumerable` interface to provide you with wide flexibility in the type of collection that you pass into the class.  The example above shows usage of simple arrays, but you can use more complex types like `List`, etc.
* `Segment`s can be built and added to a `Message` in any order.  Just set the `Segment.Ordinal` property for each to specify the ordering in the final output.  And remember that the MSH `Segment` is required, and must appear first.
* The HL7 spec calls out that segments shall be terminated with a single carriage return (a.k.a. \r or (char)13). ClearHl7 supports only this charater.  If you receive messages that use alternate line terminators, you must perform a programmatic replace on those alternate terminators before attempting to deserialize with ClearHL7, so that you may receive the expected result.
* Any string input that may contain one of the utilized delimiter characters should be escaped with `ClearHl7.Helpers.StringHelper.Escape()`.  See the Zxx/ZPD segment in the example above.
* Any `Message`, `Segment`, or `Type` can be serialized to an HL7 pipehat string by calling `Serialize()` or `ToDelimitedString()`.  Utilize the `ClearHl7.Serialization` namespace.
* Any `Message`, `Segment`, or `Type` can be instantiated and populated using an HL7 pipehat string by calling `Deserialize()` or `FromDelimitedString()`.  Utilize the `ClearHl7.Serialization` namespace.

## Contributing
We welcome code and documentation contributions!
### Complex Changes
Please discuss with the repo owners before making the change.  We would like to talk about motivations for the change, and go over your design decisions.
### Simple Changes
Fork davebronson/clear-hl7-net.git and begin development from your own fork.

## License
clear-hl7-net is licensed under the [MIT License](https://github.com/davebronson/clear-hl7-net/blob/master/LICENSE).

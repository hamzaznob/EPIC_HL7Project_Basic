﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class ErrSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new ErrSegment
            {
                ErrorCodeAndLocation = "1",
                ErrorLocation = new MessageLocation[]
                {
                    new MessageLocation
                    {
                        SegmentId = "2"
                    }
                },
                Hl7ErrorCode = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                Severity = "4",
                ApplicationErrorCode = new CodedWithExceptions
                {
                    Identifier = "5"
                },
                ApplicationErrorParameter = new string[]
                {
                    "6"
                },
                DiagnosticInformation = new Text
                {
                    Value = "7"
                },
                UserMessage = new Text
                {
                    Value = "8"
                },
                InformPersonIndicator = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "9"
                    }
                },
                OverrideType = new CodedWithExceptions
                {
                    Identifier = "10"
                },
                OverrideReasonCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "11"
                    }
                },
                HelpDeskContactPoint = new ExtendedTelecommunicationNumber[]
                {
                    new ExtendedTelecommunicationNumber
                    {
                        TelephoneNumber = "12"
                    }
                }
            };

            ISegment actual = new ErrSegment();
            actual.FromDelimitedString("ERR|1|2|3|4|5|6|7|8|9|10|11|12");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that calling FromDelimitedString() with a string input containing an incorrect segment ID results in an ArgumentException being thrown.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithIncorrectSegmentId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ISegment hl7Segment = new ErrSegment();
                hl7Segment.FromDelimitedString("ERA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new ErrSegment
            {
                ErrorCodeAndLocation = "1",
                ErrorLocation = new MessageLocation[]
                {
                    new MessageLocation
                    {
                        SegmentId = "2"
                    }
                },
                Hl7ErrorCode = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                Severity = "4",
                ApplicationErrorCode = new CodedWithExceptions
                {
                    Identifier = "5"
                },
                ApplicationErrorParameter = new string[]
                {
                    "6"
                },
                DiagnosticInformation = new Text
                {
                    Value = "7"
                },
                UserMessage = new Text
                {
                    Value = "8"
                },
                InformPersonIndicator = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "9"
                    }
                },
                OverrideType = new CodedWithExceptions
                {
                    Identifier = "10"
                },
                OverrideReasonCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "11"
                    }
                },
                HelpDeskContactPoint = new ExtendedTelecommunicationNumber[]
                {
                    new ExtendedTelecommunicationNumber
                    {
                        TelephoneNumber = "12"
                    }
                }
            };

            string expected = "ERR|1|2|3|4|5|6|7|8|9|10|11|12";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

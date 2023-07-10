﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class RxcSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new RxcSegment
            {
                RxComponentType = "1",
                ComponentCode = new CodedWithExceptions
                {
                    Identifier = "2"
                },
                ComponentAmount = 3,
                ComponentUnits = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                ComponentStrength = 5,
                ComponentStrengthUnits = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                SupplementaryCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "7"
                    }
                },
                ComponentDrugStrengthVolume = 8,
                ComponentDrugStrengthVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "9"
                },
                DispenseAmount = 10,
                DispenseUnits = new CodedWithExceptions
                {
                    Identifier = "11"
                }
            };

            ISegment actual = new RxcSegment();
            actual.FromDelimitedString("RXC|1|2|3|4|5|6|7|8|9|10|11");

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
                ISegment hl7Segment = new RxcSegment();
                hl7Segment.FromDelimitedString("RXA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new RxcSegment
            {
                RxComponentType = "1",
                ComponentCode = new CodedWithExceptions
                {
                    Identifier = "2"
                },
                ComponentAmount = 3,
                ComponentUnits = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                ComponentStrength = 5,
                ComponentStrengthUnits = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                SupplementaryCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "7"
                    }
                },
                ComponentDrugStrengthVolume = 8,
                ComponentDrugStrengthVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "9"
                },
                DispenseAmount = 10,
                DispenseUnits = new CodedWithExceptions
                {
                    Identifier = "11"
                }
            };

            string expected = "RXC|1|2|3|4|5|6|7|8|9|10|11";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

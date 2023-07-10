﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class BuiSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new BuiSegment
            {
                SetIdBui = 1,
                BloodUnitIdentifier = new EntityIdentifier
                {
                    EntityId = "2"
                },
                BloodUnitType = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                BloodUnitWeight = 4,
                WeightUnits = new CodedWithNoExceptions
                {
                    Identifier = "5"
                },
                BloodUnitVolume = 6,
                VolumeUnits = new CodedWithNoExceptions
                {
                    Identifier = "7"
                },
                ContainerCatalogNumber = "8",
                ContainerLotNumber = "9",
                ContainerManufacturer = new ExtendedCompositeNameAndIdNumberForOrganizations
                {
                    OrganizationName = "10"
                },
                TransportTemperature = new NumericRange
                {
                    LowValue = 11
                },
                TransportTemperatureUnits = new CodedWithNoExceptions
                {
                    Identifier = "12"
                },
                ActionCode = "13"
            };

            ISegment actual = new BuiSegment();
            actual.FromDelimitedString("BUI|1|2|3|4|5|6|7|8|9|10|11|12|13");

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
                ISegment hl7Segment = new BuiSegment();
                hl7Segment.FromDelimitedString("BUA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new BuiSegment
            {
                SetIdBui = 1,
                BloodUnitIdentifier = new EntityIdentifier
                {
                    EntityId = "2"
                },
                BloodUnitType = new CodedWithExceptions
                {
                    Identifier = "3"
                },
                BloodUnitWeight = 4,
                WeightUnits = new CodedWithNoExceptions
                {
                    Identifier = "5"
                },
                BloodUnitVolume = 6,
                VolumeUnits = new CodedWithNoExceptions
                {
                    Identifier = "7"
                },
                ContainerCatalogNumber = "8",
                ContainerLotNumber = "9",
                ContainerManufacturer = new ExtendedCompositeNameAndIdNumberForOrganizations
                {
                    OrganizationName = "10"
                },
                TransportTemperature = new NumericRange
                {
                    LowValue = 11
                },
                TransportTemperatureUnits = new CodedWithNoExceptions
                {
                    Identifier = "12"
                },
                ActionCode = "13"
            };

            string expected = "BUI|1|2|3|4|5|6|7|8|9|10|11|12|13";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

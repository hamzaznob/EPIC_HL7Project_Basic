﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class RxvSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new RxvSegment
            {
                SetIdRxv = 1,
                BolusType = "2",
                BolusDoseAmount = 3,
                BolusDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                BolusDoseVolume = 5,
                BolusDoseVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                PcaType = "7",
                PcaDoseAmount = 8,
                PcaDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "9"
                },
                PcaDoseAmountVolume = 10,
                PcaDoseAmountVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "11"
                },
                MaxDoseAmount = 12,
                MaxDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "13"
                },
                MaxDoseAmountVolume = 14,
                MaxDoseAmountVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "15"
                },
                MaxDosePerTime = new CompositeQuantityWithUnits
                {
                    Quantity = 16
                },
                LockoutInterval = new CompositeQuantityWithUnits
                {
                    Quantity = 17
                },
                SyringeManufacturer = new CodedWithExceptions
                {
                    Identifier = "18"
                },
                SyringeModelNumber = new CodedWithExceptions
                {
                    Identifier = "19"
                },
                SyringeSize = 20,
                SyringeSizeUnits = new CodedWithExceptions
                {
                    Identifier = "21"
                },
                ActionCode = "22"
            };

            ISegment actual = new RxvSegment();
            actual.FromDelimitedString("RXV|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22");

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
                ISegment hl7Segment = new RxvSegment();
                hl7Segment.FromDelimitedString("RXA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new RxvSegment
            {
                SetIdRxv = 1,
                BolusType = "2",
                BolusDoseAmount = 3,
                BolusDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                BolusDoseVolume = 5,
                BolusDoseVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                PcaType = "7",
                PcaDoseAmount = 8,
                PcaDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "9"
                },
                PcaDoseAmountVolume = 10,
                PcaDoseAmountVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "11"
                },
                MaxDoseAmount = 12,
                MaxDoseAmountUnits = new CodedWithExceptions
                {
                    Identifier = "13"
                },
                MaxDoseAmountVolume = 14,
                MaxDoseAmountVolumeUnits = new CodedWithExceptions
                {
                    Identifier = "15"
                },
                MaxDosePerTime = new CompositeQuantityWithUnits
                {
                    Quantity = 16
                },
                LockoutInterval = new CompositeQuantityWithUnits
                {
                    Quantity = 17
                },
                SyringeManufacturer = new CodedWithExceptions
                {
                    Identifier = "18"
                },
                SyringeModelNumber = new CodedWithExceptions
                {
                    Identifier = "19"
                },
                SyringeSize = 20,
                SyringeSizeUnits = new CodedWithExceptions
                {
                    Identifier = "21"
                },
                ActionCode = "22"
            };

            string expected = "RXV|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

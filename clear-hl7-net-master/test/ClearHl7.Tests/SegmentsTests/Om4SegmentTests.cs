﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class Om4SegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new Om4Segment
            {
                SequenceNumberTestObservationMasterFile = 1,
                DerivedSpecimen = "2",
                ContainerDescription = new Text[]
                {
                    new Text
                    {
                        Value = "3"
                    }
                },
                ContainerVolume = new decimal[]
                {
                    4
                },
                ContainerUnits = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "5"
                    }
                },
                Specimen = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                Additive = new CodedWithExceptions
                {
                    Identifier = "7"
                },
                Preparation = new Text
                {
                    Value = "8"
                },
                SpecialHandlingRequirements = new Text
                {
                    Value = "9"
                },
                NormalCollectionVolume = new CompositeQuantityWithUnits
                {
                    Quantity = 10
                },
                MinimumCollectionVolume = new CompositeQuantityWithUnits
                {
                    Quantity = 11
                },
                SpecimenRequirements = new Text
                {
                    Value = "12"
                },
                SpecimenPriorities = new string[]
                {
                    "13"
                },
                SpecimenRetentionTime = new CompositeQuantityWithUnits
                {
                    Quantity = 14
                },
                SpecimenHandlingCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "15"
                    }
                },
                SpecimenPreference = "16",
                PreferredSpecimenAttribtureSequenceId = 17,
                TaxonomicClassificationCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "18"
                    }
                }
            };

            ISegment actual = new Om4Segment();
            actual.FromDelimitedString("OM4|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18");

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
                ISegment hl7Segment = new Om4Segment();
                hl7Segment.FromDelimitedString("OMA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new Om4Segment
            {
                SequenceNumberTestObservationMasterFile = 1,
                DerivedSpecimen = "2",
                ContainerDescription = new Text[]
                {
                    new Text
                    {
                        Value = "3"
                    }
                },
                ContainerVolume = new decimal[]
                {
                    4
                },
                ContainerUnits = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "5"
                    }
                },
                Specimen = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                Additive = new CodedWithExceptions
                {
                    Identifier = "7"
                },
                Preparation = new Text
                {
                    Value = "8"
                },
                SpecialHandlingRequirements = new Text
                {
                    Value = "9"
                },
                NormalCollectionVolume = new CompositeQuantityWithUnits
                {
                    Quantity = 10
                },
                MinimumCollectionVolume = new CompositeQuantityWithUnits
                {
                    Quantity = 11
                },
                SpecimenRequirements = new Text
                {
                    Value = "12"
                },
                SpecimenPriorities = new string[]
                {
                    "13"
                },
                SpecimenRetentionTime = new CompositeQuantityWithUnits
                {
                    Quantity = 14
                },
                SpecimenHandlingCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "15"
                    }
                },
                SpecimenPreference = "16",
                PreferredSpecimenAttribtureSequenceId = 17,
                TaxonomicClassificationCode = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "18"
                    }
                }
            };

            string expected = "OM4|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

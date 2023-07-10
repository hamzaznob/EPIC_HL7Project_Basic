﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class RmiSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new RmiSegment
            {
                RiskManagementIncidentCode = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                DateTimeIncident = new DateTime(2020, 2, 2, 0, 0, 2),
                IncidentTypeCode = new CodedWithExceptions
                {
                    Identifier = "3"
                }
            };

            ISegment actual = new RmiSegment();
            actual.FromDelimitedString("RMI|1|20200202000002|3");

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
                ISegment hl7Segment = new RmiSegment();
                hl7Segment.FromDelimitedString("RMA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new RmiSegment
            {
                RiskManagementIncidentCode = new CodedWithExceptions
                {
                    Identifier = "1"
                },
                DateTimeIncident = new DateTime(2020, 2, 2, 0, 0, 2),
                IncidentTypeCode = new CodedWithExceptions
                {
                    Identifier = "3"
                }
            };

            string expected = "RMI|1|20200202000002|3";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

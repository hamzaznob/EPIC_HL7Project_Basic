﻿using System;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.SegmentsTests
{
    public class OmcSegmentTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            ISegment expected = new OmcSegment
            {
                SequenceNumberTestObservationMasterFile = 1,
                SegmentActionCode = "2",
                SegmentUniqueKey = new EntityIdentifier
                {
                    EntityId = "3"
                },
                ClinicalInformationRequest = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                CollectionEventProcessStep = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "5"
                    }
                },
                CommunicationLocation = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                AnswerRequired = "7",
                HintHelpText = "8",
                TypeOfAnswer = "9",
                MultipleAnswersAllowed = "10",
                AnswerChoices = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "11"
                    }
                },
                CharacterLimit = 12,
                NumberOfDecimals = 13
            };

            ISegment actual = new OmcSegment();
            actual.FromDelimitedString("OMC|1|2|3|4|5|6|7|8|9|10|11|12|13");

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
                ISegment hl7Segment = new OmcSegment();
                hl7Segment.FromDelimitedString("OMA|^~&|3|4|5|6");
            });
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all properties populated and in the correct sequence.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithAllProperties_ReturnsCorrectlySequencedFields()
        {
            ISegment hl7Segment = new OmcSegment
            {
                SequenceNumberTestObservationMasterFile = 1,
                SegmentActionCode = "2",
                SegmentUniqueKey = new EntityIdentifier
                {
                    EntityId = "3"
                },
                ClinicalInformationRequest = new CodedWithExceptions
                {
                    Identifier = "4"
                },
                CollectionEventProcessStep = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "5"
                    }
                },
                CommunicationLocation = new CodedWithExceptions
                {
                    Identifier = "6"
                },
                AnswerRequired = "7",
                HintHelpText = "8",
                TypeOfAnswer = "9",
                MultipleAnswersAllowed = "10",
                AnswerChoices = new CodedWithExceptions[]
                {
                    new CodedWithExceptions
                    {
                        Identifier = "11"
                    }
                },
                CharacterLimit = 12,
                NumberOfDecimals = 13
            };

            string expected = "OMC|1|2|3|4|5|6|7|8|9|10|11|12|13";
            string actual = hl7Segment.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}

﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V280.Types;

namespace ClearHl7.V280.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment REL - Clinical Relationship Segment.
    /// </summary>
    public class RelSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelSegment"/> class.
        /// </summary>
        public RelSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public RelSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "REL";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// REL.1 - Set ID -REL.
        /// </summary>
        public uint? SetIdRel { get; set; }

        /// <summary>
        /// REL.2 - Relationship Type.
        /// </summary>
        public CodedWithExceptions RelationshipType { get; set; }

        /// <summary>
        /// REL.3 - This Relationship Instance Identifier.
        /// </summary>
        public EntityIdentifier ThisRelationshipInstanceIdentifier { get; set; }

        /// <summary>
        /// REL.4 - Source Information Instance Identifier.
        /// </summary>
        public EntityIdentifier SourceInformationInstanceIdentifier { get; set; }

        /// <summary>
        /// REL.5 - Target Information Instance Identifier.
        /// </summary>
        public EntityIdentifier TargetInformationInstanceIdentifier { get; set; }

        /// <summary>
        /// REL.6 - Asserting Entity Instance ID.
        /// </summary>
        public EntityIdentifier AssertingEntityInstanceId { get; set; }

        /// <summary>
        /// REL.7 - Asserting Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons AssertingPerson { get; set; }

        /// <summary>
        /// REL.8 - Asserting Organization.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations AssertingOrganization { get; set; }

        /// <summary>
        /// REL.9 - Assertor Address.
        /// </summary>
        public ExtendedAddress AssertorAddress { get; set; }

        /// <summary>
        /// REL.10 - Assertor Contact.
        /// </summary>
        public ExtendedTelecommunicationNumber AssertorContact { get; set; }

        /// <summary>
        /// REL.11 - Assertion Date Range.
        /// </summary>
        public DateTimeRange AssertionDateRange { get; set; }

        /// <summary>
        /// REL.12 - Negation Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V280.CodeYesNoIndicator</para>
        /// </summary>
        public string NegationIndicator { get; set; }

        /// <summary>
        /// REL.13 - Certainty of Relationship.
        /// </summary>
        public CodedWithExceptions CertaintyOfRelationship { get; set; }

        /// <summary>
        /// REL.14 - Priority No.
        /// </summary>
        public decimal? PriorityNo { get; set; }

        /// <summary>
        /// REL.15 - Priority  Sequence No (rel preference for consideration).
        /// </summary>
        public decimal? PrioritySequenceNoRelPreferenceForConsideration { get; set; }

        /// <summary>
        /// REL.16 - Separability Indicator.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V280.CodeYesNoIndicator</para>
        /// </summary>
        public string SeparabilityIndicator { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(seps.FieldSeparator, StringSplitOptions.None);

            if (segments.Length > 0)
            {
                if (!string.Equals(Id, segments[0], StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException($"{ nameof(delimitedString) } does not begin with the proper segment Id: '{ Id }{ seps.FieldSeparator }'.", nameof(delimitedString));
                }
            }

            SetIdRel = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            RelationshipType = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[2], false, seps) : null;
            ThisRelationshipInstanceIdentifier = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[3], false, seps) : null;
            SourceInformationInstanceIdentifier = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[4], false, seps) : null;
            TargetInformationInstanceIdentifier = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[5], false, seps) : null;
            AssertingEntityInstanceId = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[6], false, seps) : null;
            AssertingPerson = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[7], false, seps) : null;
            AssertingOrganization = segments.Length > 8 && segments[8].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[8], false, seps) : null;
            AssertorAddress = segments.Length > 9 && segments[9].Length > 0 ? TypeSerializer.Deserialize<ExtendedAddress>(segments[9], false, seps) : null;
            AssertorContact = segments.Length > 10 && segments[10].Length > 0 ? TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(segments[10], false, seps) : null;
            AssertionDateRange = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<DateTimeRange>(segments[11], false, seps) : null;
            NegationIndicator = segments.Length > 12 && segments[12].Length > 0 ? segments[12] : null;
            CertaintyOfRelationship = segments.Length > 13 && segments[13].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[13], false, seps) : null;
            PriorityNo = segments.Length > 14 && segments[14].Length > 0 ? segments[14].ToNullableDecimal() : null;
            PrioritySequenceNoRelPreferenceForConsideration = segments.Length > 15 && segments[15].Length > 0 ? segments[15].ToNullableDecimal() : null;
            SeparabilityIndicator = segments.Length > 16 && segments[16].Length > 0 ? segments[16] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 17, Configuration.FieldSeparator),
                                Id,
                                SetIdRel.HasValue ? SetIdRel.Value.ToString(culture) : null,
                                RelationshipType?.ToDelimitedString(),
                                ThisRelationshipInstanceIdentifier?.ToDelimitedString(),
                                SourceInformationInstanceIdentifier?.ToDelimitedString(),
                                TargetInformationInstanceIdentifier?.ToDelimitedString(),
                                AssertingEntityInstanceId?.ToDelimitedString(),
                                AssertingPerson?.ToDelimitedString(),
                                AssertingOrganization?.ToDelimitedString(),
                                AssertorAddress?.ToDelimitedString(),
                                AssertorContact?.ToDelimitedString(),
                                AssertionDateRange?.ToDelimitedString(),
                                NegationIndicator,
                                CertaintyOfRelationship?.ToDelimitedString(),
                                PriorityNo.HasValue ? PriorityNo.Value.ToString(Consts.NumericFormat, culture) : null,
                                PrioritySequenceNoRelPreferenceForConsideration.HasValue ? PrioritySequenceNoRelPreferenceForConsideration.Value.ToString(Consts.NumericFormat, culture) : null,
                                SeparabilityIndicator
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

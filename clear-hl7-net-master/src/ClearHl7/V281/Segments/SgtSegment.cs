﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V281.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SGT - Segment Group Trailer.
    /// </summary>
    public class SgtSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SgtSegment"/> class.
        /// </summary>
        public SgtSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SgtSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public SgtSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "SGT";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// SGT.1 - Set ID - SGT.
        /// </summary>
        public uint? SetIdSgt { get; set; }

        /// <summary>
        /// SGT.2 - Segment Group Name.
        /// </summary>
        public string SegmentGroupName { get; set; }

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

            SetIdSgt = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            SegmentGroupName = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 3, Configuration.FieldSeparator),
                                Id,
                                SetIdSgt.HasValue ? SetIdSgt.Value.ToString(culture) : null,
                                SegmentGroupName
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

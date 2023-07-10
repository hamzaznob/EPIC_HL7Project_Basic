﻿using System;
using System.Globalization;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V260.Types;

namespace ClearHl7.V260.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment STZ - Sterilization Parameter.
    /// </summary>
    public class StzSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StzSegment"/> class.
        /// </summary>
        public StzSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StzSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public StzSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "STZ";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// STZ.1 - Sterilization Type.
        /// <para>Suggested: 0806 Sterilization Type -&gt; ClearHl7.Codes.V260.CodeSterilizationType</para>
        /// </summary>
        public CodedWithExceptions SterilizationType { get; set; }

        /// <summary>
        /// STZ.2 - Sterilization Cycle.
        /// </summary>
        public CodedWithExceptions SterilizationCycle { get; set; }

        /// <summary>
        /// STZ.3 - Maintenance Cycle.
        /// <para>Suggested: 0809 Maintenance Cycle</para>
        /// </summary>
        public CodedWithExceptions MaintenanceCycle { get; set; }

        /// <summary>
        /// STZ.4 - Maintenance Type.
        /// <para>Suggested: 0811 Maintenance Type</para>
        /// </summary>
        public CodedWithExceptions MaintenanceType { get; set; }

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

            SterilizationType = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[1], false, seps) : null;
            SterilizationCycle = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[2], false, seps) : null;
            MaintenanceCycle = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[3], false, seps) : null;
            MaintenanceType = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[4], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 5, Configuration.FieldSeparator),
                                Id,
                                SterilizationType?.ToDelimitedString(),
                                SterilizationCycle?.ToDelimitedString(),
                                MaintenanceCycle?.ToDelimitedString(),
                                MaintenanceType?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

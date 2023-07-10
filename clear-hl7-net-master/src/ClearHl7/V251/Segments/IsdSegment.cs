﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V251.Types;

namespace ClearHl7.V251.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment ISD - Interaction Status Detail.
    /// </summary>
    public class IsdSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsdSegment"/> class.
        /// </summary>
        public IsdSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IsdSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public IsdSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "ISD";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// ISD.1 - Reference Interaction Number.
        /// </summary>
        public decimal? ReferenceInteractionNumber { get; set; }

        /// <summary>
        /// ISD.2 - Interaction Type Identifier.
        /// <para>Suggested: 0368 Remote Control Command -&gt; ClearHl7.Codes.V251.CodeRemoteControlCommand</para>
        /// </summary>
        public CodedElement InteractionTypeIdentifier { get; set; }

        /// <summary>
        /// ISD.3 - Interaction Active State.
        /// <para>Suggested: 0387 Command Response -&gt; ClearHl7.Codes.V251.CodeCommandResponse</para>
        /// </summary>
        public CodedElement InteractionActiveState { get; set; }

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

            ReferenceInteractionNumber = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDecimal() : null;
            InteractionTypeIdentifier = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[2], false, seps) : null;
            InteractionActiveState = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[3], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 4, Configuration.FieldSeparator),
                                Id,
                                ReferenceInteractionNumber.HasValue ? ReferenceInteractionNumber.Value.ToString(culture) : null,
                                InteractionTypeIdentifier?.ToDelimitedString(),
                                InteractionActiveState?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

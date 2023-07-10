﻿using System;
using System.Globalization;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V250.Types;

namespace ClearHl7.V250.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment RXR - Pharmacy Treatment Route.
    /// </summary>
    public class RxrSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RxrSegment"/> class.
        /// </summary>
        public RxrSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RxrSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public RxrSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "RXR";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// RXR.1 - Route.
        /// <para>Suggested: 0162 Route Of Administration -&gt; ClearHl7.Codes.V250.CodeRouteOfAdministration</para>
        /// </summary>
        public CodedElement Route { get; set; }

        /// <summary>
        /// RXR.2 - Administration Site.
        /// <para>Suggested: 0163 Body Site -&gt; ClearHl7.Codes.V250.CodeBodySite</para>
        /// </summary>
        public CodedWithExceptions AdministrationSite { get; set; }

        /// <summary>
        /// RXR.3 - Administration Device.
        /// <para>Suggested: 0164 Administration Device -&gt; ClearHl7.Codes.V250.CodeAdministrationDevice</para>
        /// </summary>
        public CodedElement AdministrationDevice { get; set; }

        /// <summary>
        /// RXR.4 - Administration Method.
        /// <para>Suggested: 0165 Administration Method -&gt; ClearHl7.Codes.V250.CodeAdministrationMethod</para>
        /// </summary>
        public CodedWithExceptions AdministrationMethod { get; set; }

        /// <summary>
        /// RXR.5 - Routing Instruction.
        /// </summary>
        public CodedElement RoutingInstruction { get; set; }

        /// <summary>
        /// RXR.6 - Administration Site Modifier.
        /// <para>Suggested: 0495 Body Site Modifier -&gt; ClearHl7.Codes.V250.CodeBodySiteModifier</para>
        /// </summary>
        public CodedWithExceptions AdministrationSiteModifier { get; set; }

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

            Route = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[1], false, seps) : null;
            AdministrationSite = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[2], false, seps) : null;
            AdministrationDevice = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[3], false, seps) : null;
            AdministrationMethod = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[4], false, seps) : null;
            RoutingInstruction = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[5], false, seps) : null;
            AdministrationSiteModifier = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[6], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 7, Configuration.FieldSeparator),
                                Id,
                                Route?.ToDelimitedString(),
                                AdministrationSite?.ToDelimitedString(),
                                AdministrationDevice?.ToDelimitedString(),
                                AdministrationMethod?.ToDelimitedString(),
                                RoutingInstruction?.ToDelimitedString(),
                                AdministrationSiteModifier?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

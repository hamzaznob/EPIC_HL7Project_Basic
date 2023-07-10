﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V280.Types;

namespace ClearHl7.V280.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment CTD - Contact Data.
    /// </summary>
    public class CtdSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtdSegment"/> class.
        /// </summary>
        public CtdSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtdSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public CtdSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "CTD";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// CTD.1 - Contact Role.
        /// <para>Suggested: 0131 Contact Role -&gt; ClearHl7.Codes.V280.CodeContactRole</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> ContactRole { get; set; }

        /// <summary>
        /// CTD.2 - Contact Name.
        /// </summary>
        public IEnumerable<ExtendedPersonName> ContactName { get; set; }

        /// <summary>
        /// CTD.3 - Contact Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> ContactAddress { get; set; }

        /// <summary>
        /// CTD.4 - Contact Location.
        /// </summary>
        public PersonLocation ContactLocation { get; set; }

        /// <summary>
        /// CTD.5 - Contact Communication Information.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> ContactCommunicationInformation { get; set; }

        /// <summary>
        /// CTD.6 - Preferred Method of Contact.
        /// <para>Suggested: 0185 Preferred Method Of Contact -&gt; ClearHl7.Codes.V280.CodePreferredMethodOfContact</para>
        /// </summary>
        public CodedWithExceptions PreferredMethodOfContact { get; set; }

        /// <summary>
        /// CTD.7 - Contact Identifiers.
        /// <para>Suggested: 0338 Practitioner ID Number Type -&gt; ClearHl7.Codes.V280.CodePractitionerIdNumberType</para>
        /// </summary>
        public IEnumerable<PractitionerLicenseOrOtherIdNumber> ContactIdentifiers { get; set; }

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

            ContactRole = segments.Length > 1 && segments[1].Length > 0 ? segments[1].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedWithExceptions>(x, false, seps)) : null;
            ContactName = segments.Length > 2 && segments[2].Length > 0 ? segments[2].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedPersonName>(x, false, seps)) : null;
            ContactAddress = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedAddress>(x, false, seps)) : null;
            ContactLocation = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[4], false, seps) : null;
            ContactCommunicationInformation = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(x, false, seps)) : null;
            PreferredMethodOfContact = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[6], false, seps) : null;
            ContactIdentifiers = segments.Length > 7 && segments[7].Length > 0 ? segments[7].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<PractitionerLicenseOrOtherIdNumber>(x, false, seps)) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 8, Configuration.FieldSeparator),
                                Id,
                                ContactRole != null ? string.Join(Configuration.FieldRepeatSeparator, ContactRole.Select(x => x.ToDelimitedString())) : null,
                                ContactName != null ? string.Join(Configuration.FieldRepeatSeparator, ContactName.Select(x => x.ToDelimitedString())) : null,
                                ContactAddress != null ? string.Join(Configuration.FieldRepeatSeparator, ContactAddress.Select(x => x.ToDelimitedString())) : null,
                                ContactLocation?.ToDelimitedString(),
                                ContactCommunicationInformation != null ? string.Join(Configuration.FieldRepeatSeparator, ContactCommunicationInformation.Select(x => x.ToDelimitedString())) : null,
                                PreferredMethodOfContact?.ToDelimitedString(),
                                ContactIdentifiers != null ? string.Join(Configuration.FieldRepeatSeparator, ContactIdentifiers.Select(x => x.ToDelimitedString())) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

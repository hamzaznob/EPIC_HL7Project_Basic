﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V231.Types;

namespace ClearHl7.V231.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment LDP - Location Department.
    /// </summary>
    public class LdpSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LdpSegment"/> class.
        /// </summary>
        public LdpSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LdpSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public LdpSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "LDP";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// LDP.1 - Primary Key Value - LDP.
        /// </summary>
        public PersonLocation PrimaryKeyValueLdp { get; set; }

        /// <summary>
        /// LDP.2 - Location Department.
        /// <para>Suggested: 0264 Location Department</para>
        /// </summary>
        public string LocationDepartment { get; set; }

        /// <summary>
        /// LDP.3 - Location Service.
        /// <para>Suggested: 0069 Hospital Service</para>
        /// </summary>
        public IEnumerable<string> LocationService { get; set; }

        /// <summary>
        /// LDP.4 - Specialty Type.
        /// <para>Suggested: 0265 Specialty Type -&gt; ClearHl7.Codes.V231.CodeSpecialtyType</para>
        /// </summary>
        public IEnumerable<CodedElement> SpecialtyType { get; set; }

        /// <summary>
        /// LDP.5 - Valid Patient Classes.
        /// <para>Suggested: 0004 Patient Class -&gt; ClearHl7.Codes.V231.CodePatientClass</para>
        /// </summary>
        public IEnumerable<string> ValidPatientClasses { get; set; }

        /// <summary>
        /// LDP.6 - Active/Inactive Flag.
        /// <para>Suggested: 0183 Active/Inactive -&gt; ClearHl7.Codes.V231.CodeActiveInactive</para>
        /// </summary>
        public string ActiveInactiveFlag { get; set; }

        /// <summary>
        /// LDP.7 - Activation Date - LDP.
        /// </summary>
        public DateTime? ActivationDateLdp { get; set; }

        /// <summary>
        /// LDP.8 - Inactivation Date - LDP.
        /// </summary>
        public DateTime? InactivationDateLdp { get; set; }

        /// <summary>
        /// LDP.9 - Inactivated Reason.
        /// </summary>
        public string InactivatedReason { get; set; }

        /// <summary>
        /// LDP.10 - Visiting Hours.
        /// <para>Suggested: 0267 Days Of The Week -&gt; ClearHl7.Codes.V231.CodeDaysOfTheWeek</para>
        /// </summary>
        public IEnumerable<VisitingHours> VisitingHours { get; set; }

        /// <summary>
        /// LDP.11 - Contact Phone.
        /// </summary>
        public ExtendedTelecommunicationNumber ContactPhone { get; set; }

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

            PrimaryKeyValueLdp = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[1], false, seps) : null;
            LocationDepartment = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            LocationService = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            SpecialtyType = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedElement>(x, false, seps)) : null;
            ValidPatientClasses = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            ActiveInactiveFlag = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            ActivationDateLdp = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDateTime() : null;
            InactivationDateLdp = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDateTime() : null;
            InactivatedReason = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            VisitingHours = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<VisitingHours>(x, false, seps)) : null;
            ContactPhone = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(segments[11], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 12, Configuration.FieldSeparator),
                                Id,
                                PrimaryKeyValueLdp?.ToDelimitedString(),
                                LocationDepartment,
                                LocationService != null ? string.Join(Configuration.FieldRepeatSeparator, LocationService) : null,
                                SpecialtyType != null ? string.Join(Configuration.FieldRepeatSeparator, SpecialtyType.Select(x => x.ToDelimitedString())) : null,
                                ValidPatientClasses != null ? string.Join(Configuration.FieldRepeatSeparator, ValidPatientClasses) : null,
                                ActiveInactiveFlag,
                                ActivationDateLdp.HasValue ? ActivationDateLdp.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                InactivationDateLdp.HasValue ? InactivationDateLdp.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                InactivatedReason,
                                VisitingHours != null ? string.Join(Configuration.FieldRepeatSeparator, VisitingHours.Select(x => x.ToDelimitedString())) : null,
                                ContactPhone?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

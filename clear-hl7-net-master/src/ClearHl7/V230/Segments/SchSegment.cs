﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V230.Types;

namespace ClearHl7.V230.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment SCH - Scheduling Activity Information.
    /// </summary>
    public class SchSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchSegment"/> class.
        /// </summary>
        public SchSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public SchSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "SCH";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// SCH.1 - Placer Appointment ID.
        /// </summary>
        public EntityIdentifier PlacerAppointmentId { get; set; }

        /// <summary>
        /// SCH.2 - Filler Appointment ID.
        /// </summary>
        public EntityIdentifier FillerAppointmentId { get; set; }

        /// <summary>
        /// SCH.3 - Occurrence Number.
        /// </summary>
        public decimal? OccurrenceNumber { get; set; }

        /// <summary>
        /// SCH.4 - Placer Group Number.
        /// </summary>
        public EntityIdentifier PlacerGroupNumber { get; set; }

        /// <summary>
        /// SCH.5 - Schedule ID.
        /// </summary>
        public CodedElement ScheduleId { get; set; }

        /// <summary>
        /// SCH.6 - Event Reason.
        /// </summary>
        public CodedElement EventReason { get; set; }

        /// <summary>
        /// SCH.7 - Appointment Reason.
        /// <para>Suggested: 0276 Appointment Reason Codes -&gt; ClearHl7.Codes.V230.CodeAppointmentReasonCodes</para>
        /// </summary>
        public CodedElement AppointmentReason { get; set; }

        /// <summary>
        /// SCH.8 - Appointment Type.
        /// <para>Suggested: 0277 Appointment Type Codes -&gt; ClearHl7.Codes.V230.CodeAppointmentTypeCodes</para>
        /// </summary>
        public CodedElement AppointmentType { get; set; }

        /// <summary>
        /// SCH.9 - Appointment Duration.
        /// </summary>
        public decimal? AppointmentDuration { get; set; }

        /// <summary>
        /// SCH.10 - Appointment Duration Units.
        /// </summary>
        public CodedElement AppointmentDurationUnits { get; set; }

        /// <summary>
        /// SCH.11 - Appointment Timing Quantity.
        /// </summary>
        public IEnumerable<TimingQuantity> AppointmentTimingQuantity { get; set; }

        /// <summary>
        /// SCH.12 - Placer Contact Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons PlacerContactPerson { get; set; }

        /// <summary>
        /// SCH.13 - Placer Contact Phone Number.
        /// </summary>
        public ExtendedTelecommunicationNumber PlacerContactPhoneNumber { get; set; }

        /// <summary>
        /// SCH.14 - Placer Contact Address.
        /// </summary>
        public ExtendedAddress PlacerContactAddress { get; set; }

        /// <summary>
        /// SCH.15 - Placer Contact Location.
        /// </summary>
        public PersonLocation PlacerContactLocation { get; set; }

        /// <summary>
        /// SCH.16 - Filler Contact Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons FillerContactPerson { get; set; }

        /// <summary>
        /// SCH.17 - Filler Contact Phone Number.
        /// </summary>
        public ExtendedTelecommunicationNumber FillerContactPhoneNumber { get; set; }

        /// <summary>
        /// SCH.18 - Filler Contact Address.
        /// </summary>
        public ExtendedAddress FillerContactAddress { get; set; }

        /// <summary>
        /// SCH.19 - Filler Contact Location.
        /// </summary>
        public PersonLocation FillerContactLocation { get; set; }

        /// <summary>
        /// SCH.20 - Entered By Person.
        /// </summary>
        public ExtendedCompositeIdNumberAndNameForPersons EnteredByPerson { get; set; }

        /// <summary>
        /// SCH.21 - Entered By Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> EnteredByPhoneNumber { get; set; }

        /// <summary>
        /// SCH.22 - Entered By Location.
        /// </summary>
        public PersonLocation EnteredByLocation { get; set; }

        /// <summary>
        /// SCH.23 - Parent Placer Appointment ID.
        /// </summary>
        public EntityIdentifier ParentPlacerAppointmentId { get; set; }

        /// <summary>
        /// SCH.24 - Parent Filler Appointment ID.
        /// </summary>
        public EntityIdentifier ParentFillerAppointmentId { get; set; }

        /// <summary>
        /// SCH.25 - Filler Status Code.
        /// <para>Suggested: 0278 Filler Status Codes -&gt; ClearHl7.Codes.V230.CodeFillerStatusCodes</para>
        /// </summary>
        public CodedElement FillerStatusCode { get; set; }

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

            PlacerAppointmentId = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[1], false, seps) : null;
            FillerAppointmentId = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[2], false, seps) : null;
            OccurrenceNumber = segments.Length > 3 && segments[3].Length > 0 ? segments[3].ToNullableDecimal() : null;
            PlacerGroupNumber = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[4], false, seps) : null;
            ScheduleId = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[5], false, seps) : null;
            EventReason = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[6], false, seps) : null;
            AppointmentReason = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[7], false, seps) : null;
            AppointmentType = segments.Length > 8 && segments[8].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[8], false, seps) : null;
            AppointmentDuration = segments.Length > 9 && segments[9].Length > 0 ? segments[9].ToNullableDecimal() : null;
            AppointmentDurationUnits = segments.Length > 10 && segments[10].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[10], false, seps) : null;
            AppointmentTimingQuantity = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<TimingQuantity>(x, false, seps)) : null;
            PlacerContactPerson = segments.Length > 12 && segments[12].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[12], false, seps) : null;
            PlacerContactPhoneNumber = segments.Length > 13 && segments[13].Length > 0 ? TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(segments[13], false, seps) : null;
            PlacerContactAddress = segments.Length > 14 && segments[14].Length > 0 ? TypeSerializer.Deserialize<ExtendedAddress>(segments[14], false, seps) : null;
            PlacerContactLocation = segments.Length > 15 && segments[15].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[15], false, seps) : null;
            FillerContactPerson = segments.Length > 16 && segments[16].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[16], false, seps) : null;
            FillerContactPhoneNumber = segments.Length > 17 && segments[17].Length > 0 ? TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(segments[17], false, seps) : null;
            FillerContactAddress = segments.Length > 18 && segments[18].Length > 0 ? TypeSerializer.Deserialize<ExtendedAddress>(segments[18], false, seps) : null;
            FillerContactLocation = segments.Length > 19 && segments[19].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[19], false, seps) : null;
            EnteredByPerson = segments.Length > 20 && segments[20].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(segments[20], false, seps) : null;
            EnteredByPhoneNumber = segments.Length > 21 && segments[21].Length > 0 ? segments[21].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(x, false, seps)) : null;
            EnteredByLocation = segments.Length > 22 && segments[22].Length > 0 ? TypeSerializer.Deserialize<PersonLocation>(segments[22], false, seps) : null;
            ParentPlacerAppointmentId = segments.Length > 23 && segments[23].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[23], false, seps) : null;
            ParentFillerAppointmentId = segments.Length > 24 && segments[24].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[24], false, seps) : null;
            FillerStatusCode = segments.Length > 25 && segments[25].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[25], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 26, Configuration.FieldSeparator),
                                Id,
                                PlacerAppointmentId?.ToDelimitedString(),
                                FillerAppointmentId?.ToDelimitedString(),
                                OccurrenceNumber.HasValue ? OccurrenceNumber.Value.ToString(Consts.NumericFormat, culture) : null,
                                PlacerGroupNumber?.ToDelimitedString(),
                                ScheduleId?.ToDelimitedString(),
                                EventReason?.ToDelimitedString(),
                                AppointmentReason?.ToDelimitedString(),
                                AppointmentType?.ToDelimitedString(),
                                AppointmentDuration.HasValue ? AppointmentDuration.Value.ToString(Consts.NumericFormat, culture) : null,
                                AppointmentDurationUnits?.ToDelimitedString(),
                                AppointmentTimingQuantity != null ? string.Join(Configuration.FieldRepeatSeparator, AppointmentTimingQuantity.Select(x => x.ToDelimitedString())) : null,
                                PlacerContactPerson?.ToDelimitedString(),
                                PlacerContactPhoneNumber?.ToDelimitedString(),
                                PlacerContactAddress?.ToDelimitedString(),
                                PlacerContactLocation?.ToDelimitedString(),
                                FillerContactPerson?.ToDelimitedString(),
                                FillerContactPhoneNumber?.ToDelimitedString(),
                                FillerContactAddress?.ToDelimitedString(),
                                FillerContactLocation?.ToDelimitedString(),
                                EnteredByPerson?.ToDelimitedString(),
                                EnteredByPhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, EnteredByPhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                EnteredByLocation?.ToDelimitedString(),
                                ParentPlacerAppointmentId?.ToDelimitedString(),
                                ParentFillerAppointmentId?.ToDelimitedString(),
                                FillerStatusCode?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V251.Types;

namespace ClearHl7.V251.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment UB2 - Uniform Billing Data.
    /// </summary>
    public class Ub2Segment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ub2Segment"/> class.
        /// </summary>
        public Ub2Segment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ub2Segment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public Ub2Segment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "UB2";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// UB2.1 - Set ID - UB2.
        /// </summary>
        public uint? SetIdUb2 { get; set; }

        /// <summary>
        /// UB2.2 - Co-Insurance Days (9).
        /// </summary>
        public string CoInsuranceDays9 { get; set; }

        /// <summary>
        /// UB2.3 - Condition Code (24-30).
        /// <para>Suggested: 0043 Condition Code -&gt; ClearHl7.Codes.V251.CodeConditionCode</para>
        /// </summary>
        public IEnumerable<string> ConditionCode24To30 { get; set; }

        /// <summary>
        /// UB2.4 - Covered Days (7).
        /// </summary>
        public string CoveredDays7 { get; set; }

        /// <summary>
        /// UB2.5 - Non-Covered Days (8).
        /// </summary>
        public string NonCoveredDays8 { get; set; }

        /// <summary>
        /// UB2.6 - Value Amount &amp; Code (39-41).
        /// </summary>
        public IEnumerable<ValueCodeAndAmount> ValueAmountCode39To41 { get; set; }

        /// <summary>
        /// UB2.7 - Occurrence Code &amp; Date (32-35).
        /// </summary>
        public IEnumerable<OccurrenceCodeAndDate> OccurrenceCodeDate32To35 { get; set; }

        /// <summary>
        /// UB2.8 - Occurrence Span Code/Dates (36).
        /// </summary>
        public IEnumerable<OccurrenceSpanCodeAndDate> OccurrenceSpanCodeDates36 { get; set; }

        /// <summary>
        /// UB2.9 - Uniform Billing Locator 2 (state).
        /// </summary>
        public IEnumerable<string> UniformBillingLocator2State { get; set; }

        /// <summary>
        /// UB2.10 - Uniform Billing Locator 11 (state).
        /// </summary>
        public IEnumerable<string> UniformBillingLocator11State { get; set; }

        /// <summary>
        /// UB2.11 - Uniform Billing Locator 31 (national).
        /// </summary>
        public string UniformBillingLocator31National { get; set; }

        /// <summary>
        /// UB2.12 - Document Control Number.
        /// </summary>
        public IEnumerable<string> DocumentControlNumber { get; set; }

        /// <summary>
        /// UB2.13 - Uniform Billing Locator 49 (national).
        /// </summary>
        public IEnumerable<string> UniformBillingLocator49National { get; set; }

        /// <summary>
        /// UB2.14 - Uniform Billing Locator 56 (state).
        /// </summary>
        public IEnumerable<string> UniformBillingLocator56State { get; set; }

        /// <summary>
        /// UB2.15 - Uniform Billing Locator 57 (sational).
        /// </summary>
        public string UniformBillingLocator57Sational { get; set; }

        /// <summary>
        /// UB2.16 - Uniform Billing Locator 78 (state).
        /// </summary>
        public IEnumerable<string> UniformBillingLocator78State { get; set; }

        /// <summary>
        /// UB2.17 - Special Visit Count.
        /// </summary>
        public decimal? SpecialVisitCount { get; set; }

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

            SetIdUb2 = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            CoInsuranceDays9 = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            ConditionCode24To30 = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            CoveredDays7 = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            NonCoveredDays8 = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            ValueAmountCode39To41 = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ValueCodeAndAmount>(x, false, seps)) : null;
            OccurrenceCodeDate32To35 = segments.Length > 7 && segments[7].Length > 0 ? segments[7].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<OccurrenceCodeAndDate>(x, false, seps)) : null;
            OccurrenceSpanCodeDates36 = segments.Length > 8 && segments[8].Length > 0 ? segments[8].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<OccurrenceSpanCodeAndDate>(x, false, seps)) : null;
            UniformBillingLocator2State = segments.Length > 9 && segments[9].Length > 0 ? segments[9].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            UniformBillingLocator11State = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            UniformBillingLocator31National = segments.Length > 11 && segments[11].Length > 0 ? segments[11] : null;
            DocumentControlNumber = segments.Length > 12 && segments[12].Length > 0 ? segments[12].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            UniformBillingLocator49National = segments.Length > 13 && segments[13].Length > 0 ? segments[13].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            UniformBillingLocator56State = segments.Length > 14 && segments[14].Length > 0 ? segments[14].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            UniformBillingLocator57Sational = segments.Length > 15 && segments[15].Length > 0 ? segments[15] : null;
            UniformBillingLocator78State = segments.Length > 16 && segments[16].Length > 0 ? segments[16].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            SpecialVisitCount = segments.Length > 17 && segments[17].Length > 0 ? segments[17].ToNullableDecimal() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 18, Configuration.FieldSeparator),
                                Id,
                                SetIdUb2.HasValue ? SetIdUb2.Value.ToString(culture) : null,
                                CoInsuranceDays9,
                                ConditionCode24To30 != null ? string.Join(Configuration.FieldRepeatSeparator, ConditionCode24To30) : null,
                                CoveredDays7,
                                NonCoveredDays8,
                                ValueAmountCode39To41 != null ? string.Join(Configuration.FieldRepeatSeparator, ValueAmountCode39To41.Select(x => x.ToDelimitedString())) : null,
                                OccurrenceCodeDate32To35 != null ? string.Join(Configuration.FieldRepeatSeparator, OccurrenceCodeDate32To35.Select(x => x.ToDelimitedString())) : null,
                                OccurrenceSpanCodeDates36 != null ? string.Join(Configuration.FieldRepeatSeparator, OccurrenceSpanCodeDates36.Select(x => x.ToDelimitedString())) : null,
                                UniformBillingLocator2State != null ? string.Join(Configuration.FieldRepeatSeparator, UniformBillingLocator2State) : null,
                                UniformBillingLocator11State != null ? string.Join(Configuration.FieldRepeatSeparator, UniformBillingLocator11State) : null,
                                UniformBillingLocator31National,
                                DocumentControlNumber != null ? string.Join(Configuration.FieldRepeatSeparator, DocumentControlNumber) : null,
                                UniformBillingLocator49National != null ? string.Join(Configuration.FieldRepeatSeparator, UniformBillingLocator49National) : null,
                                UniformBillingLocator56State != null ? string.Join(Configuration.FieldRepeatSeparator, UniformBillingLocator56State) : null,
                                UniformBillingLocator57Sational,
                                UniformBillingLocator78State != null ? string.Join(Configuration.FieldRepeatSeparator, UniformBillingLocator78State) : null,
                                SpecialVisitCount.HasValue ? SpecialVisitCount.Value.ToString(Consts.NumericFormat, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

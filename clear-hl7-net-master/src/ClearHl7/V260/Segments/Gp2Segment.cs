﻿using System;
using System.Collections.Generic;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V260.Types;

namespace ClearHl7.V260.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment GP2 - Grouping Reimbursement - Procedure Line Item.
    /// </summary>
    public class Gp2Segment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gp2Segment"/> class.
        /// </summary>
        public Gp2Segment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gp2Segment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public Gp2Segment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "GP2";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// GP2.1 - Revenue Code.
        /// <para>Suggested: 0456 Revenue Code -&gt; ClearHl7.Codes.V260.CodeRevenueCode</para>
        /// </summary>
        public string RevenueCode { get; set; }

        /// <summary>
        /// GP2.2 - Number of Service Units.
        /// </summary>
        public decimal? NumberOfServiceUnits { get; set; }

        /// <summary>
        /// GP2.3 - Charge.
        /// </summary>
        public CompositePrice Charge { get; set; }

        /// <summary>
        /// GP2.4 - Reimbursement Action Code.
        /// <para>Suggested: 0459 Reimbursement Action Code -&gt; ClearHl7.Codes.V260.CodeReimbursementActionCode</para>
        /// </summary>
        public string ReimbursementActionCode { get; set; }

        /// <summary>
        /// GP2.5 - Denial or Rejection Code.
        /// <para>Suggested: 0460 Denial Or Rejection Code -&gt; ClearHl7.Codes.V260.CodeDenialOrRejectionCode</para>
        /// </summary>
        public string DenialOrRejectionCode { get; set; }

        /// <summary>
        /// GP2.6 - OCE Edit Code.
        /// <para>Suggested: 0458 OCE Edit Code</para>
        /// </summary>
        public IEnumerable<string> OceEditCode { get; set; }

        /// <summary>
        /// GP2.7 - Ambulatory Payment Classification Code.
        /// <para>Suggested: 0466 Ambulatory Payment Classification Code -&gt; ClearHl7.Codes.V260.CodeAmbulatoryPaymentClassificationCode</para>
        /// </summary>
        public CodedWithExceptions AmbulatoryPaymentClassificationCode { get; set; }

        /// <summary>
        /// GP2.8 - Modifier Edit Code.
        /// <para>Suggested: 0467 Modifier Edit Code</para>
        /// </summary>
        public IEnumerable<string> ModifierEditCode { get; set; }

        /// <summary>
        /// GP2.9 - Payment Adjustment Code.
        /// <para>Suggested: 0468 Payment Adjustment Code -&gt; ClearHl7.Codes.V260.CodePaymentAdjustmentCode</para>
        /// </summary>
        public string PaymentAdjustmentCode { get; set; }

        /// <summary>
        /// GP2.10 - Packaging Status Code.
        /// <para>Suggested: 0469 Packaging Status Code -&gt; ClearHl7.Codes.V260.CodePackagingStatusCode</para>
        /// </summary>
        public string PackagingStatusCode { get; set; }

        /// <summary>
        /// GP2.11 - Expected CMS Payment Amount.
        /// </summary>
        public CompositePrice ExpectedCmsPaymentAmount { get; set; }

        /// <summary>
        /// GP2.12 - Reimbursement Type Code.
        /// <para>Suggested: 0470 Reimbursement Type Code -&gt; ClearHl7.Codes.V260.CodeReimbursementTypeCode</para>
        /// </summary>
        public string ReimbursementTypeCode { get; set; }

        /// <summary>
        /// GP2.13 - Co-Pay Amount.
        /// </summary>
        public CompositePrice CoPayAmount { get; set; }

        /// <summary>
        /// GP2.14 - Pay Rate per Service Unit.
        /// </summary>
        public decimal? PayRatePerServiceUnit { get; set; }

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

            RevenueCode = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            NumberOfServiceUnits = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDecimal() : null;
            Charge = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[3], false, seps) : null;
            ReimbursementActionCode = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            DenialOrRejectionCode = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            OceEditCode = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            AmbulatoryPaymentClassificationCode = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[7], false, seps) : null;
            ModifierEditCode = segments.Length > 8 && segments[8].Length > 0 ? segments[8].Split(seps.FieldRepeatSeparator, StringSplitOptions.None) : null;
            PaymentAdjustmentCode = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            PackagingStatusCode = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            ExpectedCmsPaymentAmount = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[11], false, seps) : null;
            ReimbursementTypeCode = segments.Length > 12 && segments[12].Length > 0 ? segments[12] : null;
            CoPayAmount = segments.Length > 13 && segments[13].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[13], false, seps) : null;
            PayRatePerServiceUnit = segments.Length > 14 && segments[14].Length > 0 ? segments[14].ToNullableDecimal() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 15, Configuration.FieldSeparator),
                                Id,
                                RevenueCode,
                                NumberOfServiceUnits.HasValue ? NumberOfServiceUnits.Value.ToString(Consts.NumericFormat, culture) : null,
                                Charge?.ToDelimitedString(),
                                ReimbursementActionCode,
                                DenialOrRejectionCode,
                                OceEditCode != null ? string.Join(Configuration.FieldRepeatSeparator, OceEditCode) : null,
                                AmbulatoryPaymentClassificationCode?.ToDelimitedString(),
                                ModifierEditCode != null ? string.Join(Configuration.FieldRepeatSeparator, ModifierEditCode) : null,
                                PaymentAdjustmentCode,
                                PackagingStatusCode,
                                ExpectedCmsPaymentAmount,
                                ReimbursementTypeCode,
                                CoPayAmount?.ToDelimitedString(),
                                PayRatePerServiceUnit.HasValue ? PayRatePerServiceUnit.Value.ToString(Consts.NumericFormat, culture) : null
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

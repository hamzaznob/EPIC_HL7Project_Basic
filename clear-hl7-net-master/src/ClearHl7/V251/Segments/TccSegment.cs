﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V251.Types;

namespace ClearHl7.V251.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment TCC - Test Code Configuration.
    /// </summary>
    public class TccSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TccSegment"/> class.
        /// </summary>
        public TccSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TccSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public TccSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "TCC";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// TCC.1 - Universal Service Identifier.
        /// </summary>
        public CodedElement UniversalServiceIdentifier { get; set; }

        /// <summary>
        /// TCC.2 - Equipment Test Application Identifier.
        /// </summary>
        public EntityIdentifier EquipmentTestApplicationIdentifier { get; set; }

        /// <summary>
        /// TCC.3 - Specimen Source.
        /// </summary>
        public SpecimenSource SpecimenSource { get; set; }

        /// <summary>
        /// TCC.4 - Auto-Dilution Factor Default.
        /// </summary>
        public StructuredNumeric AutoDilutionFactorDefault { get; set; }

        /// <summary>
        /// TCC.5 - Rerun Dilution Factor Default.
        /// </summary>
        public StructuredNumeric RerunDilutionFactorDefault { get; set; }

        /// <summary>
        /// TCC.6 - Pre-Dilution Factor Default.
        /// </summary>
        public StructuredNumeric PreDilutionFactorDefault { get; set; }

        /// <summary>
        /// TCC.7 - Endogenous Content of Pre-Dilution Diluent.
        /// </summary>
        public StructuredNumeric EndogenousContentOfPreDilutionDiluent { get; set; }

        /// <summary>
        /// TCC.8 - Inventory Limits Warning Level.
        /// </summary>
        public decimal? InventoryLimitsWarningLevel { get; set; }

        /// <summary>
        /// TCC.9 - Automatic Rerun Allowed.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V251.CodeYesNoIndicator</para>
        /// </summary>
        public string AutomaticRerunAllowed { get; set; }

        /// <summary>
        /// TCC.10 - Automatic Repeat Allowed.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V251.CodeYesNoIndicator</para>
        /// </summary>
        public string AutomaticRepeatAllowed { get; set; }

        /// <summary>
        /// TCC.11 - Automatic Reflex Allowed.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V251.CodeYesNoIndicator</para>
        /// </summary>
        public string AutomaticReflexAllowed { get; set; }

        /// <summary>
        /// TCC.12 - Equipment Dynamic Range.
        /// </summary>
        public StructuredNumeric EquipmentDynamicRange { get; set; }

        /// <summary>
        /// TCC.13 - Units.
        /// </summary>
        public CodedElement Units { get; set; }

        /// <summary>
        /// TCC.14 - Processing Type.
        /// <para>Suggested: 0388 Processing Type -&gt; ClearHl7.Codes.V251.CodeProcessingType</para>
        /// </summary>
        public CodedElement ProcessingType { get; set; }

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

            UniversalServiceIdentifier = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[1], false, seps) : null;
            EquipmentTestApplicationIdentifier = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[2], false, seps) : null;
            SpecimenSource = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<SpecimenSource>(segments[3], false, seps) : null;
            AutoDilutionFactorDefault = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<StructuredNumeric>(segments[4], false, seps) : null;
            RerunDilutionFactorDefault = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<StructuredNumeric>(segments[5], false, seps) : null;
            PreDilutionFactorDefault = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<StructuredNumeric>(segments[6], false, seps) : null;
            EndogenousContentOfPreDilutionDiluent = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<StructuredNumeric>(segments[7], false, seps) : null;
            InventoryLimitsWarningLevel = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDecimal() : null;
            AutomaticRerunAllowed = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            AutomaticRepeatAllowed = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            AutomaticReflexAllowed = segments.Length > 11 && segments[11].Length > 0 ? segments[11] : null;
            EquipmentDynamicRange = segments.Length > 12 && segments[12].Length > 0 ? TypeSerializer.Deserialize<StructuredNumeric>(segments[12], false, seps) : null;
            Units = segments.Length > 13 && segments[13].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[13], false, seps) : null;
            ProcessingType = segments.Length > 14 && segments[14].Length > 0 ? TypeSerializer.Deserialize<CodedElement>(segments[14], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 15, Configuration.FieldSeparator),
                                Id,
                                UniversalServiceIdentifier?.ToDelimitedString(),
                                EquipmentTestApplicationIdentifier?.ToDelimitedString(),
                                SpecimenSource?.ToDelimitedString(),
                                AutoDilutionFactorDefault?.ToDelimitedString(),
                                RerunDilutionFactorDefault?.ToDelimitedString(),
                                PreDilutionFactorDefault?.ToDelimitedString(),
                                EndogenousContentOfPreDilutionDiluent?.ToDelimitedString(),
                                InventoryLimitsWarningLevel.HasValue ? InventoryLimitsWarningLevel.Value.ToString(Consts.NumericFormat, culture) : null,
                                AutomaticRerunAllowed,
                                AutomaticRepeatAllowed,
                                AutomaticReflexAllowed,
                                EquipmentDynamicRange?.ToDelimitedString(),
                                Units?.ToDelimitedString(),
                                ProcessingType?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

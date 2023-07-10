﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V290.Types;

namespace ClearHl7.V290.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment BUI - Blood Unit Information.
    /// </summary>
    public class BuiSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuiSegment"/> class.
        /// </summary>
        public BuiSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuiSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public BuiSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "BUI";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// BUI.1 - Set ID - BUI.
        /// </summary>
        public uint? SetIdBui { get; set; }

        /// <summary>
        /// BUI.2 - Blood Unit Identifier.
        /// </summary>
        public EntityIdentifier BloodUnitIdentifier { get; set; }

        /// <summary>
        /// BUI.3 - Blood Unit Type.
        /// <para>Suggested: 0566 Blood Unit Type -&gt; ClearHl7.Codes.V290.CodeBloodUnitType</para>
        /// </summary>
        public CodedWithExceptions BloodUnitType { get; set; }

        /// <summary>
        /// BUI.4 - Blood Unit Weight.
        /// </summary>
        public decimal? BloodUnitWeight { get; set; }

        /// <summary>
        /// BUI.5 - Weight Units.
        /// <para>Suggested: 0929 Weight Units</para>
        /// </summary>
        public CodedWithNoExceptions WeightUnits { get; set; }

        /// <summary>
        /// BUI.6 - Blood Unit Volume.
        /// </summary>
        public decimal? BloodUnitVolume { get; set; }

        /// <summary>
        /// BUI.7 - Volume Units.
        /// <para>Suggested: 0930 Volume Units</para>
        /// </summary>
        public CodedWithNoExceptions VolumeUnits { get; set; }

        /// <summary>
        /// BUI.8 - Container Catalog Number.
        /// </summary>
        public string ContainerCatalogNumber { get; set; }

        /// <summary>
        /// BUI.9 - Container Lot Number.
        /// </summary>
        public string ContainerLotNumber { get; set; }

        /// <summary>
        /// BUI.10 - Container Manufacturer.
        /// </summary>
        public ExtendedCompositeNameAndIdNumberForOrganizations ContainerManufacturer { get; set; }

        /// <summary>
        /// BUI.11 - Transport Temperature.
        /// </summary>
        public NumericRange TransportTemperature { get; set; }

        /// <summary>
        /// BUI.12 - Transport Temperature Units.
        /// <para>Suggested: 0931 Transport Temperature Units</para>
        /// </summary>
        public CodedWithNoExceptions TransportTemperatureUnits { get; set; }

        /// <summary>
        /// BUI.13 - Action Code.
        /// </summary>
        public string ActionCode { get; set; }

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

            SetIdBui = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            BloodUnitIdentifier = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<EntityIdentifier>(segments[2], false, seps) : null;
            BloodUnitType = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[3], false, seps) : null;
            BloodUnitWeight = segments.Length > 4 && segments[4].Length > 0 ? segments[4].ToNullableDecimal() : null;
            WeightUnits = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<CodedWithNoExceptions>(segments[5], false, seps) : null;
            BloodUnitVolume = segments.Length > 6 && segments[6].Length > 0 ? segments[6].ToNullableDecimal() : null;
            VolumeUnits = segments.Length > 7 && segments[7].Length > 0 ? TypeSerializer.Deserialize<CodedWithNoExceptions>(segments[7], false, seps) : null;
            ContainerCatalogNumber = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            ContainerLotNumber = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            ContainerManufacturer = segments.Length > 10 && segments[10].Length > 0 ? TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(segments[10], false, seps) : null;
            TransportTemperature = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<NumericRange>(segments[11], false, seps) : null;
            TransportTemperatureUnits = segments.Length > 12 && segments[12].Length > 0 ? TypeSerializer.Deserialize<CodedWithNoExceptions>(segments[12], false, seps) : null;
            ActionCode = segments.Length > 13 && segments[13].Length > 0 ? segments[13] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 14, Configuration.FieldSeparator),
                                Id,
                                SetIdBui.HasValue ? SetIdBui.Value.ToString(culture) : null,
                                BloodUnitIdentifier?.ToDelimitedString(),
                                BloodUnitType?.ToDelimitedString(),
                                BloodUnitWeight.HasValue ? BloodUnitWeight.Value.ToString(Consts.NumericFormat, culture) : null,
                                WeightUnits?.ToDelimitedString(),
                                BloodUnitVolume.HasValue ? BloodUnitVolume.Value.ToString(Consts.NumericFormat, culture) : null,
                                VolumeUnits?.ToDelimitedString(),
                                ContainerCatalogNumber,
                                ContainerLotNumber,
                                ContainerManufacturer?.ToDelimitedString(),
                                TransportTemperature?.ToDelimitedString(),
                                TransportTemperatureUnits?.ToDelimitedString(),
                                ActionCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

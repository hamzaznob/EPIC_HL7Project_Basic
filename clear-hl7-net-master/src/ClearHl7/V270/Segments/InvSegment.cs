﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V270.Types;

namespace ClearHl7.V270.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment INV - Inventory Detail.
    /// </summary>
    public class InvSegment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvSegment"/> class.
        /// </summary>
        public InvSegment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvSegment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public InvSegment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "INV";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// INV.1 - Substance Identifier.
        /// <para>Suggested: 0451 Substance Identifier</para>
        /// </summary>
        public CodedWithExceptions SubstanceIdentifier { get; set; }

        /// <summary>
        /// INV.2 - Substance Status.
        /// <para>Suggested: 0383 Substance Status -&gt; ClearHl7.Codes.V270.CodeSubstanceStatus</para>
        /// </summary>
        public IEnumerable<CodedWithExceptions> SubstanceStatus { get; set; }

        /// <summary>
        /// INV.3 - Substance Type.
        /// <para>Suggested: 0384 Substance Type -&gt; ClearHl7.Codes.V270.CodeSubstanceType</para>
        /// </summary>
        public CodedWithExceptions SubstanceType { get; set; }

        /// <summary>
        /// INV.4 - Inventory Container Identifier.
        /// </summary>
        public CodedWithExceptions InventoryContainerIdentifier { get; set; }

        /// <summary>
        /// INV.5 - Container Carrier Identifier.
        /// </summary>
        public CodedWithExceptions ContainerCarrierIdentifier { get; set; }

        /// <summary>
        /// INV.6 - Position on Carrier.
        /// </summary>
        public CodedWithExceptions PositionOnCarrier { get; set; }

        /// <summary>
        /// INV.7 - Initial Quantity.
        /// </summary>
        public decimal? InitialQuantity { get; set; }

        /// <summary>
        /// INV.8 - Current Quantity.
        /// </summary>
        public decimal? CurrentQuantity { get; set; }

        /// <summary>
        /// INV.9 - Available Quantity.
        /// </summary>
        public decimal? AvailableQuantity { get; set; }

        /// <summary>
        /// INV.10 - Consumption Quantity.
        /// </summary>
        public decimal? ConsumptionQuantity { get; set; }

        /// <summary>
        /// INV.11 - Quantity Units.
        /// </summary>
        public CodedWithExceptions QuantityUnits { get; set; }

        /// <summary>
        /// INV.12 - Expiration Date/Time.
        /// </summary>
        public DateTime? ExpirationDateTime { get; set; }

        /// <summary>
        /// INV.13 - First Used Date/Time.
        /// </summary>
        public DateTime? FirstUsedDateTime { get; set; }

        /// <summary>
        /// INV.14 - On Board Stability Duration.
        /// </summary>
        public string OnBoardStabilityDuration { get; set; }

        /// <summary>
        /// INV.15 - Test/Fluid Identifier(s).
        /// </summary>
        public IEnumerable<CodedWithExceptions> TestFluidIdentifiers { get; set; }

        /// <summary>
        /// INV.16 - Manufacturer Lot Number.
        /// </summary>
        public string ManufacturerLotNumber { get; set; }

        /// <summary>
        /// INV.17 - Manufacturer Identifier.
        /// <para>Suggested: 0385 Manufacturer Identifier</para>
        /// </summary>
        public CodedWithExceptions ManufacturerIdentifier { get; set; }

        /// <summary>
        /// INV.18 - Supplier Identifier.
        /// <para>Suggested: 0386 Supplier Identifier</para>
        /// </summary>
        public CodedWithExceptions SupplierIdentifier { get; set; }

        /// <summary>
        /// INV.19 - On Board Stability Time.
        /// </summary>
        public CompositeQuantityWithUnits OnBoardStabilityTime { get; set; }

        /// <summary>
        /// INV.20 - Target Value.
        /// </summary>
        public CompositeQuantityWithUnits TargetValue { get; set; }

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

            SubstanceIdentifier = segments.Length > 1 && segments[1].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[1], false, seps) : null;
            SubstanceStatus = segments.Length > 2 && segments[2].Length > 0 ? segments[2].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedWithExceptions>(x, false, seps)) : null;
            SubstanceType = segments.Length > 3 && segments[3].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[3], false, seps) : null;
            InventoryContainerIdentifier = segments.Length > 4 && segments[4].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[4], false, seps) : null;
            ContainerCarrierIdentifier = segments.Length > 5 && segments[5].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[5], false, seps) : null;
            PositionOnCarrier = segments.Length > 6 && segments[6].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[6], false, seps) : null;
            InitialQuantity = segments.Length > 7 && segments[7].Length > 0 ? segments[7].ToNullableDecimal() : null;
            CurrentQuantity = segments.Length > 8 && segments[8].Length > 0 ? segments[8].ToNullableDecimal() : null;
            AvailableQuantity = segments.Length > 9 && segments[9].Length > 0 ? segments[9].ToNullableDecimal() : null;
            ConsumptionQuantity = segments.Length > 10 && segments[10].Length > 0 ? segments[10].ToNullableDecimal() : null;
            QuantityUnits = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[11], false, seps) : null;
            ExpirationDateTime = segments.Length > 12 && segments[12].Length > 0 ? segments[12].ToNullableDateTime() : null;
            FirstUsedDateTime = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
            OnBoardStabilityDuration = segments.Length > 14 && segments[14].Length > 0 ? segments[14] : null;
            TestFluidIdentifiers = segments.Length > 15 && segments[15].Length > 0 ? segments[15].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<CodedWithExceptions>(x, false, seps)) : null;
            ManufacturerLotNumber = segments.Length > 16 && segments[16].Length > 0 ? segments[16] : null;
            ManufacturerIdentifier = segments.Length > 17 && segments[17].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[17], false, seps) : null;
            SupplierIdentifier = segments.Length > 18 && segments[18].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[18], false, seps) : null;
            OnBoardStabilityTime = segments.Length > 19 && segments[19].Length > 0 ? TypeSerializer.Deserialize<CompositeQuantityWithUnits>(segments[19], false, seps) : null;
            TargetValue = segments.Length > 20 && segments[20].Length > 0 ? TypeSerializer.Deserialize<CompositeQuantityWithUnits>(segments[20], false, seps) : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 21, Configuration.FieldSeparator),
                                Id,
                                SubstanceIdentifier?.ToDelimitedString(),
                                SubstanceStatus != null ? string.Join(Configuration.FieldRepeatSeparator, SubstanceStatus.Select(x => x.ToDelimitedString())) : null,
                                SubstanceType?.ToDelimitedString(),
                                InventoryContainerIdentifier?.ToDelimitedString(),
                                ContainerCarrierIdentifier?.ToDelimitedString(),
                                PositionOnCarrier?.ToDelimitedString(),
                                InitialQuantity.HasValue ? InitialQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                CurrentQuantity.HasValue ? CurrentQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                AvailableQuantity.HasValue ? AvailableQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                ConsumptionQuantity.HasValue ? ConsumptionQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                QuantityUnits?.ToDelimitedString(),
                                ExpirationDateTime.HasValue ? ExpirationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                FirstUsedDateTime.HasValue ? FirstUsedDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                OnBoardStabilityDuration,
                                TestFluidIdentifiers != null ? string.Join(Configuration.FieldRepeatSeparator, TestFluidIdentifiers.Select(x => x.ToDelimitedString())) : null,
                                ManufacturerLotNumber,
                                ManufacturerIdentifier?.ToDelimitedString(),
                                SupplierIdentifier?.ToDelimitedString(),
                                OnBoardStabilityTime?.ToDelimitedString(),
                                TargetValue?.ToDelimitedString()
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V270.Types
{
    /// <summary>
    /// HL7 Version 2 MOP - Money Or Percentage.
    /// </summary>
    public class MoneyOrPercentage : IType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyOrPercentage"/> class.
        /// </summary>
        public MoneyOrPercentage()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyOrPercentage"/> class.
        /// </summary>
        /// <param name="moneyOrPercentageIndicator">MOP.1 - Money or Percentage Indicator.</param>
        /// <param name="moneyOrPercentageQuantity">MOP.2 - Money or Percentage Quantity.</param>
        public MoneyOrPercentage(string moneyOrPercentageIndicator, decimal moneyOrPercentageQuantity)
        {
            MoneyOrPercentageIndicator = moneyOrPercentageIndicator;
            MoneyOrPercentageQuantity = moneyOrPercentageQuantity;
        }

        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// MOP.1 - Money or Percentage Indicator.
        /// <para>Suggested: 0148 Money Or Percentage Indicator -&gt; ClearHl7.Codes.V270.CodeMoneyOrPercentageIndicator</para>
        /// </summary>
        public string MoneyOrPercentageIndicator { get; set; }

        /// <summary>
        /// MOP.2 - Money or Percentage Quantity.
        /// </summary>
        public decimal? MoneyOrPercentageQuantity { get; set; }

        /// <summary>
        /// MOP.3 - Monetary Denomination.
        /// <para>Suggested: 0913 Denomination</para>
        /// </summary>
        public string MonetaryDenomination { get; set; }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString)
        {
            FromDelimitedString(delimitedString, null);
        }

        /// <inheritdoc/>
        public void FromDelimitedString(string delimitedString, Separators separators)
        {
            Separators seps = separators ?? new Separators().UsingConfigurationValues();
            string[] separator = IsSubcomponent ? seps.SubcomponentSeparator : seps.ComponentSeparator;
            string[] segments = delimitedString == null
                ? Array.Empty<string>()
                : delimitedString.Split(separator, StringSplitOptions.None);

            MoneyOrPercentageIndicator = segments.Length > 0 && segments[0].Length > 0 ? segments[0] : null;
            MoneyOrPercentageQuantity = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableDecimal() : null;
            MonetaryDenomination = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 3, separator),
                                MoneyOrPercentageIndicator,
                                MoneyOrPercentageQuantity.HasValue ? MoneyOrPercentageQuantity.Value.ToString(Consts.NumericFormat, culture) : null,
                                MonetaryDenomination
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}

﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;

namespace ClearHl7.V251.Types
{
    /// <summary>
    /// HL7 Version 2 XAD - Extended Address.
    /// </summary>
    public class ExtendedAddress : IType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedAddress"/> class.
        /// </summary>
        public ExtendedAddress()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedAddress"/> class.
        /// </summary>
        /// <param name="streetAddress">XAD.1 - Street Address.</param>
        /// <param name="city">XAD.3 - City.</param>
        /// <param name="stateOrProvince">XAD.4 - State or Province.</param>
        /// <param name="zipOrPostalCode">XAD.5 - Zip or Postal Code.</param>
        public ExtendedAddress(StreetAddress streetAddress, string city, string stateOrProvince, string zipOrPostalCode)
        {
            StreetAddress = streetAddress;
            City = city;
            StateOrProvince = stateOrProvince;
            ZipOrPostalCode = zipOrPostalCode;
        }

        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// XAD.1 - Street Address.
        /// </summary>
        public StreetAddress StreetAddress { get; set; }

        /// <summary>
        /// XAD.2 - Other Designation.
        /// </summary>
        public string OtherDesignation { get; set; }

        /// <summary>
        /// XAD.3 - City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// XAD.4 - State or Province.
        /// </summary>
        public string StateOrProvince { get; set; }

        /// <summary>
        /// XAD.5 - Zip or Postal Code.
        /// </summary>
        public string ZipOrPostalCode { get; set; }

        /// <summary>
        /// XAD.6 - Country.
        /// <para>Suggested: 0399 Country Code -&gt; https://www.iso.org/iso-3166-country-codes.html</para>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// XAD.7 - Address Type.
        /// <para>Suggested: 0190 Address Type -&gt; ClearHl7.Codes.V251.CodeAddressType</para>
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// XAD.8 - Other Geographic Designation.
        /// </summary>
        public string OtherGeographicDesignation { get; set; }

        /// <summary>
        /// XAD.9 - County/Parish Code.
        /// <para>Suggested: 0289 County/Parish Code</para>
        /// </summary>
        public string CountyParishCode { get; set; }

        /// <summary>
        /// XAD.10 - Census Tract.
        /// <para>Suggested: 0288 Census Tract</para>
        /// </summary>
        public string CensusTract { get; set; }

        /// <summary>
        /// XAD.11 - Address Representation Code.
        /// <para>Suggested: 0465 Name/Address Representation -&gt; ClearHl7.Codes.V251.CodeNameAddressRepresentation</para>
        /// </summary>
        public string AddressRepresentationCode { get; set; }

        /// <summary>
        /// XAD.12 - Address Validity Range.
        /// </summary>
        public DateTimeRange AddressValidityRange { get; set; }

        /// <summary>
        /// XAD.13 - Effective Date.
        /// </summary>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// XAD.14 - Expiration Date.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

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

            StreetAddress = segments.Length > 0 && segments[0].Length > 0 ? TypeSerializer.Deserialize<StreetAddress>(segments[0], true, seps) : null;
            OtherDesignation = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            City = segments.Length > 2 && segments[2].Length > 0 ? segments[2] : null;
            StateOrProvince = segments.Length > 3 && segments[3].Length > 0 ? segments[3] : null;
            ZipOrPostalCode = segments.Length > 4 && segments[4].Length > 0 ? segments[4] : null;
            Country = segments.Length > 5 && segments[5].Length > 0 ? segments[5] : null;
            AddressType = segments.Length > 6 && segments[6].Length > 0 ? segments[6] : null;
            OtherGeographicDesignation = segments.Length > 7 && segments[7].Length > 0 ? segments[7] : null;
            CountyParishCode = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            CensusTract = segments.Length > 9 && segments[9].Length > 0 ? segments[9] : null;
            AddressRepresentationCode = segments.Length > 10 && segments[10].Length > 0 ? segments[10] : null;
            AddressValidityRange = segments.Length > 11 && segments[11].Length > 0 ? TypeSerializer.Deserialize<DateTimeRange>(segments[11], true, seps) : null;
            EffectiveDate = segments.Length > 12 && segments[12].Length > 0 ? segments[12].ToNullableDateTime() : null;
            ExpirationDate = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 14, separator),
                                StreetAddress?.ToDelimitedString(),
                                OtherDesignation,
                                City,
                                StateOrProvince,
                                ZipOrPostalCode,
                                Country,
                                AddressType,
                                OtherGeographicDesignation,
                                CountyParishCode,
                                CensusTract,
                                AddressRepresentationCode,
                                AddressValidityRange?.ToDelimitedString(),
                                EffectiveDate.HasValue ? EffectiveDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}

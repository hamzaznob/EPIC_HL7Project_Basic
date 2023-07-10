﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V231.Types
{
    /// <summary>
    /// HL7 Version 2 DLN - Drivers License Number.
    /// </summary>
    public class DriversLicenseNumber : IType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriversLicenseNumber"/> class.
        /// </summary>
        public DriversLicenseNumber()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversLicenseNumber"/> class.
        /// </summary>
        /// <param name="licenseNumber">DLN.1 - License Number.</param>
        public DriversLicenseNumber(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversLicenseNumber"/> class.
        /// </summary>
        /// <param name="licenseNumber">DLN.1 - License Number.</param>
        /// <param name="issuingStateProvinceCountry">DLN.2 - Issuing State, Province, Country.</param>
        public DriversLicenseNumber(string licenseNumber, string issuingStateProvinceCountry)
        {
            LicenseNumber = licenseNumber;
            IssuingStateProvinceCountry = issuingStateProvinceCountry;
        }

        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// DLN.1 - License Number.
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// DLN.2 - Issuing State, Province, Country.
        /// </summary>
        public string IssuingStateProvinceCountry { get; set; }

        /// <summary>
        /// DLN.3 - Expiration Date.
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

            LicenseNumber = segments.Length > 0 && segments[0].Length > 0 ? segments[0] : null;
            IssuingStateProvinceCountry = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            ExpirationDate = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 3, separator),
                                LicenseNumber,
                                IssuingStateProvinceCountry,
                                ExpirationDate.HasValue ? ExpirationDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}

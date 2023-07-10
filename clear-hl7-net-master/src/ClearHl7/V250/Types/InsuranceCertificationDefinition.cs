﻿using System;
using System.Globalization;
using ClearHl7.Extensions;
using ClearHl7.Helpers;

namespace ClearHl7.V250.Types
{
    /// <summary>
    /// HL7 Version 2 ICD - Insurance Certification Definition.
    /// </summary>
    public class InsuranceCertificationDefinition : IType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceCertificationDefinition"/> class.
        /// </summary>
        public InsuranceCertificationDefinition()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceCertificationDefinition"/> class.
        /// </summary>
        /// <param name="certificationPatientType">ICD.1 - Certification Patient Type.</param>
        public InsuranceCertificationDefinition(string certificationPatientType)
        {
            CertificationPatientType = certificationPatientType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceCertificationDefinition"/> class.
        /// </summary>
        /// <param name="certificationPatientType">ICD.1 - Certification Patient Type.</param>
        /// <param name="certificationRequired">ICD.2 - Certification Required.</param>
        public InsuranceCertificationDefinition(string certificationPatientType, string certificationRequired)
        {
            CertificationPatientType = certificationPatientType;
            CertificationRequired = certificationRequired;
        }

        /// <inheritdoc/>
        public bool IsSubcomponent { get; set; }

        /// <summary>
        /// ICD.1 - Certification Patient Type.
        /// <para>Suggested: 0150 Certification Patient Type -&gt; ClearHl7.Codes.V250.CodeCertificationPatientType</para>
        /// </summary>
        public string CertificationPatientType { get; set; }

        /// <summary>
        /// ICD.2 - Certification Required.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V250.CodeYesNoIndicator</para>
        /// </summary>
        public string CertificationRequired { get; set; }

        /// <summary>
        /// ICD.3 - Date/Time Certification Required.
        /// </summary>
        public DateTime? DateTimeCertificationRequired { get; set; }

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

            CertificationPatientType = segments.Length > 0 && segments[0].Length > 0 ? segments[0] : null;
            CertificationRequired = segments.Length > 1 && segments[1].Length > 0 ? segments[1] : null;
            DateTimeCertificationRequired = segments.Length > 2 && segments[2].Length > 0 ? segments[2].ToNullableDateTime() : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string separator = IsSubcomponent ? Configuration.SubcomponentSeparator : Configuration.ComponentSeparator;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 3, separator),
                                CertificationPatientType,
                                CertificationRequired,
                                DateTimeCertificationRequired.HasValue ? DateTimeCertificationRequired.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null
                                ).TrimEnd(separator.ToCharArray());
        }
    }
}

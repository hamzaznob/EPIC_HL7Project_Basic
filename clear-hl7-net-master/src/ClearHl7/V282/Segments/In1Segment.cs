﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClearHl7.Extensions;
using ClearHl7.Helpers;
using ClearHl7.Serialization;
using ClearHl7.V282.Types;

namespace ClearHl7.V282.Segments
{
    /// <summary>
    /// HL7 Version 2 Segment IN1 - Insurance.
    /// </summary>
    public class In1Segment : ISegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="In1Segment"/> class.
        /// </summary>
        public In1Segment()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="In1Segment"/> class.
        /// </summary>
        /// <param name="ordinal">The rank, or ordinal, which describes the place that this Segment resides in an ordered list of Segments.</param>
        public In1Segment(int ordinal)
        {
            Ordinal = ordinal;
        }

        /// <inheritdoc/>
        public string Id => "IN1";

        /// <inheritdoc/>
        public int Ordinal { get; set; }

        /// <summary>
        /// IN1.1 - Set ID - IN1.
        /// </summary>
        public uint? SetIdIn1 { get; set; }

        /// <summary>
        /// IN1.2 - Health Plan ID.
        /// <para>Suggested: 0072 Insurance Plan ID</para>
        /// </summary>
        public CodedWithExceptions HealthPlanId { get; set; }

        /// <summary>
        /// IN1.3 - Insurance Company ID.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> InsuranceCompanyId { get; set; }

        /// <summary>
        /// IN1.4 - Insurance Company Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> InsuranceCompanyName { get; set; }

        /// <summary>
        /// IN1.5 - Insurance Company Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> InsuranceCompanyAddress { get; set; }

        /// <summary>
        /// IN1.6 - Insurance Co Contact Person.
        /// </summary>
        public IEnumerable<ExtendedPersonName> InsuranceCoContactPerson { get; set; }

        /// <summary>
        /// IN1.7 - Insurance Co Phone Number.
        /// </summary>
        public IEnumerable<ExtendedTelecommunicationNumber> InsuranceCoPhoneNumber { get; set; }

        /// <summary>
        /// IN1.8 - Group Number.
        /// </summary>
        public string GroupNumber { get; set; }

        /// <summary>
        /// IN1.9 - Group Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> GroupName { get; set; }

        /// <summary>
        /// IN1.10 - Insured's Group Emp ID.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> InsuredsGroupEmpId { get; set; }

        /// <summary>
        /// IN1.11 - Insured's Group Emp Name.
        /// </summary>
        public IEnumerable<ExtendedCompositeNameAndIdNumberForOrganizations> InsuredsGroupEmpName { get; set; }

        /// <summary>
        /// IN1.12 - Plan Effective Date.
        /// </summary>
        public DateTime? PlanEffectiveDate { get; set; }

        /// <summary>
        /// IN1.13 - Plan Expiration Date.
        /// </summary>
        public DateTime? PlanExpirationDate { get; set; }

        /// <summary>
        /// IN1.14 - Authorization Information.
        /// </summary>
        public AuthorizationInformation AuthorizationInformation { get; set; }

        /// <summary>
        /// IN1.15 - Plan Type.
        /// <para>Suggested: 0086 Plan ID</para>
        /// </summary>
        public CodedWithExceptions PlanType { get; set; }

        /// <summary>
        /// IN1.16 - Name Of Insured.
        /// </summary>
        public IEnumerable<ExtendedPersonName> NameOfInsured { get; set; }

        /// <summary>
        /// IN1.17 - Insured's Relationship To Patient.
        /// <para>Suggested: 0063 Relationship -&gt; ClearHl7.Codes.V282.CodeRelationship</para>
        /// </summary>
        public CodedWithExceptions InsuredsRelationshipToPatient { get; set; }

        /// <summary>
        /// IN1.18 - Insured's Date Of Birth.
        /// </summary>
        public DateTime? InsuredsDateOfBirth { get; set; }

        /// <summary>
        /// IN1.19 - Insured's Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> InsuredsAddress { get; set; }

        /// <summary>
        /// IN1.20 - Assignment Of Benefits.
        /// <para>Suggested: 0135 Assignment Of Benefits -&gt; ClearHl7.Codes.V282.CodeAssignmentOfBenefits</para>
        /// </summary>
        public CodedWithExceptions AssignmentOfBenefits { get; set; }

        /// <summary>
        /// IN1.21 - Coordination Of Benefits.
        /// <para>Suggested: 0173 Coordination Of Benefits -&gt; ClearHl7.Codes.V282.CodeCoordinationOfBenefits</para>
        /// </summary>
        public CodedWithExceptions CoordinationOfBenefits { get; set; }

        /// <summary>
        /// IN1.22 - Coord Of Ben. Priority.
        /// </summary>
        public string CoordOfBenPriority { get; set; }

        /// <summary>
        /// IN1.23 - Notice Of Admission Flag.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V282.CodeYesNoIndicator</para>
        /// </summary>
        public string NoticeOfAdmissionFlag { get; set; }

        /// <summary>
        /// IN1.24 - Notice Of Admission Date.
        /// </summary>
        public DateTime? NoticeOfAdmissionDate { get; set; }

        /// <summary>
        /// IN1.25 - Report Of Eligibility Flag.
        /// <para>Suggested: 0136 Yes/No Indicator -&gt; ClearHl7.Codes.V282.CodeYesNoIndicator</para>
        /// </summary>
        public string ReportOfEligibilityFlag { get; set; }

        /// <summary>
        /// IN1.26 - Report Of Eligibility Date.
        /// </summary>
        public DateTime? ReportOfEligibilityDate { get; set; }

        /// <summary>
        /// IN1.27 - Release Information Code.
        /// <para>Suggested: 0093 Release Information</para>
        /// </summary>
        public CodedWithExceptions ReleaseInformationCode { get; set; }

        /// <summary>
        /// IN1.28 - Pre-Admit Cert (PAC).
        /// </summary>
        public string PreAdmitCertPac { get; set; }

        /// <summary>
        /// IN1.29 - Verification Date/Time.
        /// </summary>
        public DateTime? VerificationDateTime { get; set; }

        /// <summary>
        /// IN1.30 - Verification By.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdNumberAndNameForPersons> VerificationBy { get; set; }

        /// <summary>
        /// IN1.31 - Type Of Agreement Code.
        /// <para>Suggested: 0098 Type Of Agreement -&gt; ClearHl7.Codes.V282.CodeTypeOfAgreement</para>
        /// </summary>
        public CodedWithExceptions TypeOfAgreementCode { get; set; }

        /// <summary>
        /// IN1.32 - Billing Status.
        /// <para>Suggested: 0022 Billing Status</para>
        /// </summary>
        public CodedWithExceptions BillingStatus { get; set; }

        /// <summary>
        /// IN1.33 - Lifetime Reserve Days.
        /// </summary>
        public decimal? LifetimeReserveDays { get; set; }

        /// <summary>
        /// IN1.34 - Delay Before L.R. Day.
        /// </summary>
        public decimal? DelayBeforeLRDay { get; set; }

        /// <summary>
        /// IN1.35 - Company Plan Code.
        /// <para>Suggested: 0042 Company Plan Code</para>
        /// </summary>
        public CodedWithExceptions CompanyPlanCode { get; set; }

        /// <summary>
        /// IN1.36 - Policy Number.
        /// </summary>
        public string PolicyNumber { get; set; }

        /// <summary>
        /// IN1.37 - Policy Deductible.
        /// </summary>
        public CompositePrice PolicyDeductible { get; set; }

        /// <summary>
        /// IN1.38 - Policy Limit - Amount.
        /// </summary>
        public string PolicyLimitAmount { get; set; }

        /// <summary>
        /// IN1.39 - Policy Limit - Days.
        /// </summary>
        public decimal? PolicyLimitDays { get; set; }

        /// <summary>
        /// IN1.40 - Room Rate - Semi-Private.
        /// </summary>
        public string RoomRateSemiPrivate { get; set; }

        /// <summary>
        /// IN1.41 - Room Rate - Private.
        /// </summary>
        public string RoomRatePrivate { get; set; }

        /// <summary>
        /// IN1.42 - Insured's Employment Status.
        /// <para>Suggested: 0066 Employment Status -&gt; ClearHl7.Codes.V282.CodeEmploymentStatus</para>
        /// </summary>
        public CodedWithExceptions InsuredsEmploymentStatus { get; set; }

        /// <summary>
        /// IN1.43 - Insured's Administrative Sex.
        /// <para>Suggested: 0001 Administrative Sex -&gt; ClearHl7.Codes.V282.CodeAdministrativeSex</para>
        /// </summary>
        public CodedWithExceptions InsuredsAdministrativeSex { get; set; }

        /// <summary>
        /// IN1.44 - Insured's Employer's Address.
        /// </summary>
        public IEnumerable<ExtendedAddress> InsuredsEmployersAddress { get; set; }

        /// <summary>
        /// IN1.45 - Verification Status.
        /// </summary>
        public string VerificationStatus { get; set; }

        /// <summary>
        /// IN1.46 - Prior Insurance Plan ID.
        /// <para>Suggested: 0072 Insurance Plan ID</para>
        /// </summary>
        public CodedWithExceptions PriorInsurancePlanId { get; set; }

        /// <summary>
        /// IN1.47 - Coverage Type.
        /// <para>Suggested: 0309 Coverage Type -&gt; ClearHl7.Codes.V282.CodeCoverageType</para>
        /// </summary>
        public CodedWithExceptions CoverageType { get; set; }

        /// <summary>
        /// IN1.48 - Handicap.
        /// <para>Suggested: 0295 Handicap</para>
        /// </summary>
        public CodedWithExceptions Handicap { get; set; }

        /// <summary>
        /// IN1.49 - Insured's ID Number.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> InsuredsIdNumber { get; set; }

        /// <summary>
        /// IN1.50 - Signature Code.
        /// <para>Suggested: 0535 Signature Code -&gt; ClearHl7.Codes.V282.CodeSignatureCode</para>
        /// </summary>
        public CodedWithExceptions SignatureCode { get; set; }

        /// <summary>
        /// IN1.51 - Signature Code Date.
        /// </summary>
        public DateTime? SignatureCodeDate { get; set; }

        /// <summary>
        /// IN1.52 - Insured's Birth Place.
        /// </summary>
        public string InsuredsBirthPlace { get; set; }

        /// <summary>
        /// IN1.53 - VIP Indicator.
        /// <para>Suggested: 0099 VIP Indicator</para>
        /// </summary>
        public CodedWithExceptions VipIndicator { get; set; }

        /// <summary>
        /// IN1.54 - External Health Plan Identifiers.
        /// </summary>
        public IEnumerable<ExtendedCompositeIdWithCheckDigit> ExternalHealthPlanIdentifiers { get; set; }

        /// <summary>
        /// IN1.55 - Insurance Action Code.
        /// <para>Suggested: 0206 Segment Action Code -&gt; ClearHl7.Codes.V282.CodeSegmentActionCode</para>
        /// </summary>
        public string InsuranceActionCode { get; set; }

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

            SetIdIn1 = segments.Length > 1 && segments[1].Length > 0 ? segments[1].ToNullableUInt() : null;
            HealthPlanId = segments.Length > 2 && segments[2].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[2], false, seps) : null;
            InsuranceCompanyId = segments.Length > 3 && segments[3].Length > 0 ? segments[3].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false, seps)) : null;
            InsuranceCompanyName = segments.Length > 4 && segments[4].Length > 0 ? segments[4].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(x, false, seps)) : null;
            InsuranceCompanyAddress = segments.Length > 5 && segments[5].Length > 0 ? segments[5].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedAddress>(x, false, seps)) : null;
            InsuranceCoContactPerson = segments.Length > 6 && segments[6].Length > 0 ? segments[6].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedPersonName>(x, false, seps)) : null;
            InsuranceCoPhoneNumber = segments.Length > 7 && segments[7].Length > 0 ? segments[7].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedTelecommunicationNumber>(x, false, seps)) : null;
            GroupNumber = segments.Length > 8 && segments[8].Length > 0 ? segments[8] : null;
            GroupName = segments.Length > 9 && segments[9].Length > 0 ? segments[9].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(x, false, seps)) : null;
            InsuredsGroupEmpId = segments.Length > 10 && segments[10].Length > 0 ? segments[10].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false, seps)) : null;
            InsuredsGroupEmpName = segments.Length > 11 && segments[11].Length > 0 ? segments[11].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeNameAndIdNumberForOrganizations>(x, false, seps)) : null;
            PlanEffectiveDate = segments.Length > 12 && segments[12].Length > 0 ? segments[12].ToNullableDateTime() : null;
            PlanExpirationDate = segments.Length > 13 && segments[13].Length > 0 ? segments[13].ToNullableDateTime() : null;
            AuthorizationInformation = segments.Length > 14 && segments[14].Length > 0 ? TypeSerializer.Deserialize<AuthorizationInformation>(segments[14], false, seps) : null;
            PlanType = segments.Length > 15 && segments[15].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[15], false, seps) : null;
            NameOfInsured = segments.Length > 16 && segments[16].Length > 0 ? segments[16].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedPersonName>(x, false, seps)) : null;
            InsuredsRelationshipToPatient = segments.Length > 17 && segments[17].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[17], false, seps) : null;
            InsuredsDateOfBirth = segments.Length > 18 && segments[18].Length > 0 ? segments[18].ToNullableDateTime() : null;
            InsuredsAddress = segments.Length > 19 && segments[19].Length > 0 ? segments[19].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedAddress>(x, false, seps)) : null;
            AssignmentOfBenefits = segments.Length > 20 && segments[20].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[20], false, seps) : null;
            CoordinationOfBenefits = segments.Length > 21 && segments[21].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[21], false, seps) : null;
            CoordOfBenPriority = segments.Length > 22 && segments[22].Length > 0 ? segments[22] : null;
            NoticeOfAdmissionFlag = segments.Length > 23 && segments[23].Length > 0 ? segments[23] : null;
            NoticeOfAdmissionDate = segments.Length > 24 && segments[24].Length > 0 ? segments[24].ToNullableDateTime() : null;
            ReportOfEligibilityFlag = segments.Length > 25 && segments[25].Length > 0 ? segments[25] : null;
            ReportOfEligibilityDate = segments.Length > 26 && segments[26].Length > 0 ? segments[26].ToNullableDateTime() : null;
            ReleaseInformationCode = segments.Length > 27 && segments[27].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[27], false, seps) : null;
            PreAdmitCertPac = segments.Length > 28 && segments[28].Length > 0 ? segments[28] : null;
            VerificationDateTime = segments.Length > 29 && segments[29].Length > 0 ? segments[29].ToNullableDateTime() : null;
            VerificationBy = segments.Length > 30 && segments[30].Length > 0 ? segments[30].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdNumberAndNameForPersons>(x, false, seps)) : null;
            TypeOfAgreementCode = segments.Length > 31 && segments[31].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[31], false, seps) : null;
            BillingStatus = segments.Length > 32 && segments[32].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[32], false, seps) : null;
            LifetimeReserveDays = segments.Length > 33 && segments[33].Length > 0 ? segments[33].ToNullableDecimal() : null;
            DelayBeforeLRDay = segments.Length > 34 && segments[34].Length > 0 ? segments[34].ToNullableDecimal() : null;
            CompanyPlanCode = segments.Length > 35 && segments[35].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[35], false, seps) : null;
            PolicyNumber = segments.Length > 36 && segments[36].Length > 0 ? segments[36] : null;
            PolicyDeductible = segments.Length > 37 && segments[37].Length > 0 ? TypeSerializer.Deserialize<CompositePrice>(segments[37], false, seps) : null;
            PolicyLimitAmount = segments.Length > 38 && segments[38].Length > 0 ? segments[38] : null;
            PolicyLimitDays = segments.Length > 39 && segments[39].Length > 0 ? segments[39].ToNullableDecimal() : null;
            RoomRateSemiPrivate = segments.Length > 40 && segments[40].Length > 0 ? segments[40] : null;
            RoomRatePrivate = segments.Length > 41 && segments[41].Length > 0 ? segments[41] : null;
            InsuredsEmploymentStatus = segments.Length > 42 && segments[42].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[42], false, seps) : null;
            InsuredsAdministrativeSex = segments.Length > 43 && segments[43].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[43], false, seps) : null;
            InsuredsEmployersAddress = segments.Length > 44 && segments[44].Length > 0 ? segments[44].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedAddress>(x, false, seps)) : null;
            VerificationStatus = segments.Length > 45 && segments[45].Length > 0 ? segments[45] : null;
            PriorInsurancePlanId = segments.Length > 46 && segments[46].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[46], false, seps) : null;
            CoverageType = segments.Length > 47 && segments[47].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[47], false, seps) : null;
            Handicap = segments.Length > 48 && segments[48].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[48], false, seps) : null;
            InsuredsIdNumber = segments.Length > 49 && segments[49].Length > 0 ? segments[49].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false, seps)) : null;
            SignatureCode = segments.Length > 50 && segments[50].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[50], false, seps) : null;
            SignatureCodeDate = segments.Length > 51 && segments[51].Length > 0 ? segments[51].ToNullableDateTime() : null;
            InsuredsBirthPlace = segments.Length > 52 && segments[52].Length > 0 ? segments[52] : null;
            VipIndicator = segments.Length > 53 && segments[53].Length > 0 ? TypeSerializer.Deserialize<CodedWithExceptions>(segments[53], false, seps) : null;
            ExternalHealthPlanIdentifiers = segments.Length > 54 && segments[54].Length > 0 ? segments[54].Split(seps.FieldRepeatSeparator, StringSplitOptions.None).Select(x => TypeSerializer.Deserialize<ExtendedCompositeIdWithCheckDigit>(x, false, seps)) : null;
            InsuranceActionCode = segments.Length > 55 && segments[55].Length > 0 ? segments[55] : null;
        }

        /// <inheritdoc/>
        public string ToDelimitedString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            return string.Format(
                                culture,
                                StringHelper.StringFormatSequence(0, 56, Configuration.FieldSeparator),
                                Id,
                                SetIdIn1.HasValue ? SetIdIn1.Value.ToString(culture) : null,
                                HealthPlanId?.ToDelimitedString(),
                                InsuranceCompanyId != null ? string.Join(Configuration.FieldRepeatSeparator, InsuranceCompanyId.Select(x => x.ToDelimitedString())) : null,
                                InsuranceCompanyName != null ? string.Join(Configuration.FieldRepeatSeparator, InsuranceCompanyName.Select(x => x.ToDelimitedString())) : null,
                                InsuranceCompanyAddress != null ? string.Join(Configuration.FieldRepeatSeparator, InsuranceCompanyAddress.Select(x => x.ToDelimitedString())) : null,
                                InsuranceCoContactPerson != null ? string.Join(Configuration.FieldRepeatSeparator, InsuranceCoContactPerson.Select(x => x.ToDelimitedString())) : null,
                                InsuranceCoPhoneNumber != null ? string.Join(Configuration.FieldRepeatSeparator, InsuranceCoPhoneNumber.Select(x => x.ToDelimitedString())) : null,
                                GroupNumber,
                                GroupName != null ? string.Join(Configuration.FieldRepeatSeparator, GroupName.Select(x => x.ToDelimitedString())) : null,
                                InsuredsGroupEmpId != null ? string.Join(Configuration.FieldRepeatSeparator, InsuredsGroupEmpId.Select(x => x.ToDelimitedString())) : null,
                                InsuredsGroupEmpName != null ? string.Join(Configuration.FieldRepeatSeparator, InsuredsGroupEmpName.Select(x => x.ToDelimitedString())) : null,
                                PlanEffectiveDate.HasValue ? PlanEffectiveDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                PlanExpirationDate.HasValue ? PlanExpirationDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                AuthorizationInformation?.ToDelimitedString(),
                                PlanType?.ToDelimitedString(),
                                NameOfInsured != null ? string.Join(Configuration.FieldRepeatSeparator, NameOfInsured.Select(x => x.ToDelimitedString())) : null,
                                InsuredsRelationshipToPatient?.ToDelimitedString(),
                                InsuredsDateOfBirth.HasValue ? InsuredsDateOfBirth.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                InsuredsAddress != null ? string.Join(Configuration.FieldRepeatSeparator, InsuredsAddress.Select(x => x.ToDelimitedString())) : null,
                                AssignmentOfBenefits?.ToDelimitedString(),
                                CoordinationOfBenefits?.ToDelimitedString(),
                                CoordOfBenPriority,
                                NoticeOfAdmissionFlag,
                                NoticeOfAdmissionDate.HasValue ? NoticeOfAdmissionDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReportOfEligibilityFlag,
                                ReportOfEligibilityDate.HasValue ? ReportOfEligibilityDate.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                ReleaseInformationCode?.ToDelimitedString(),
                                PreAdmitCertPac,
                                VerificationDateTime.HasValue ? VerificationDateTime.Value.ToString(Consts.DateTimeFormatPrecisionSecond, culture) : null,
                                VerificationBy != null ? string.Join(Configuration.FieldRepeatSeparator, VerificationBy.Select(x => x.ToDelimitedString())) : null,
                                TypeOfAgreementCode?.ToDelimitedString(),
                                BillingStatus?.ToDelimitedString(),
                                LifetimeReserveDays.HasValue ? LifetimeReserveDays.Value.ToString(Consts.NumericFormat, culture) : null,
                                DelayBeforeLRDay.HasValue ? DelayBeforeLRDay.Value.ToString(Consts.NumericFormat, culture) : null,
                                CompanyPlanCode?.ToDelimitedString(),
                                PolicyNumber,
                                PolicyDeductible?.ToDelimitedString(),
                                PolicyLimitAmount,
                                PolicyLimitDays.HasValue ? PolicyLimitDays.Value.ToString(Consts.NumericFormat, culture) : null,
                                RoomRateSemiPrivate,
                                RoomRatePrivate,
                                InsuredsEmploymentStatus?.ToDelimitedString(),
                                InsuredsAdministrativeSex?.ToDelimitedString(),
                                InsuredsEmployersAddress != null ? string.Join(Configuration.FieldRepeatSeparator, InsuredsEmployersAddress.Select(x => x.ToDelimitedString())) : null,
                                VerificationStatus,
                                PriorInsurancePlanId?.ToDelimitedString(),
                                CoverageType?.ToDelimitedString(),
                                Handicap?.ToDelimitedString(),
                                InsuredsIdNumber != null ? string.Join(Configuration.FieldRepeatSeparator, InsuredsIdNumber.Select(x => x.ToDelimitedString())) : null,
                                SignatureCode?.ToDelimitedString(),
                                SignatureCodeDate.HasValue ? SignatureCodeDate.Value.ToString(Consts.DateFormatPrecisionDay, culture) : null,
                                InsuredsBirthPlace,
                                VipIndicator?.ToDelimitedString(),
                                ExternalHealthPlanIdentifiers != null ? string.Join(Configuration.FieldRepeatSeparator, ExternalHealthPlanIdentifiers.Select(x => x.ToDelimitedString())) : null,
                                InsuranceActionCode
                                ).TrimEnd(Configuration.FieldSeparator.ToCharArray());
        }
    }
}

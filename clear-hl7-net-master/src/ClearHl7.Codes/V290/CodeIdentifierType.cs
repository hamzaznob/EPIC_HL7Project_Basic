﻿namespace ClearHl7.Codes.V290
{
    /// <summary>
    /// HL7 Version 2 Table 0203 - Identifier Type.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0203</remarks>
    public enum CodeIdentifierType
    {
        /// <summary>
        /// AC - Accreditation/Certification Identifier.
        /// </summary>
        AccreditationCertificationIdentifier,

        /// <summary>
        /// ACSN - Accession ID.
        /// </summary>
        AccessionId,

        /// <summary>
        /// AM - American Express.
        /// </summary>
        AmericanExpress,

        /// <summary>
        /// AMA - American Medical Association Number.
        /// </summary>
        AmericanMedicalAssociationNumber,

        /// <summary>
        /// AN - Account number.
        /// </summary>
        AccountNumber,

        /// <summary>
        /// ANC - Account number Creditor.
        /// </summary>
        AccountNumberCreditor,

        /// <summary>
        /// AND - Account number debitor.
        /// </summary>
        AccountNumberDebitor,

        /// <summary>
        /// ANON - Anonymous identifier.
        /// </summary>
        AnonymousIdentifier,

        /// <summary>
        /// ANT - Temporary Account Number.
        /// </summary>
        TemporaryAccountNumber,

        /// <summary>
        /// APRN - Advanced Practice Registered Nurse number.
        /// </summary>
        AdvancedPracticeRegisteredNurseNumber,

        /// <summary>
        /// ASID - Ancestor Specimen ID.
        /// </summary>
        AncestorSpecimenId,

        /// <summary>
        /// BA - Bank Account Number.
        /// </summary>
        BankAccountNumber,

        /// <summary>
        /// BC - Bank Card Number.
        /// </summary>
        BankCardNumber,

        /// <summary>
        /// BCFN - Birth Certificate File Number.
        /// </summary>
        BirthCertificateFileNumber,

        /// <summary>
        /// BCT - Birth Certificate.
        /// </summary>
        BirthCertificate,

        /// <summary>
        /// BR - Birth registry number.
        /// </summary>
        BirthRegistryNumber,

        /// <summary>
        /// BRN - Breed Registry Number.
        /// </summary>
        BreedRegistryNumber,

        /// <summary>
        /// BSNR - Primary physician office number.
        /// </summary>
        PrimaryPhysicianOfficeNumber,

        /// <summary>
        /// CC - Cost Center number.
        /// </summary>
        CostCenterNumber,

        /// <summary>
        /// CONM - Change of Name Document.
        /// </summary>
        ChangeOfNameDocument,

        /// <summary>
        /// CY - County number.
        /// </summary>
        CountyNumber,

        /// <summary>
        /// CZ - Citizenship Card.
        /// </summary>
        CitizenshipCard,

        /// <summary>
        /// DC - Death Certificate ID.
        /// </summary>
        DeathCertificateId,

        /// <summary>
        /// DCFN - Death Certificate File Number.
        /// </summary>
        DeathCertificateFileNumber,

        /// <summary>
        /// DDS - Dentist license number.
        /// </summary>
        DentistLicenseNumber,

        /// <summary>
        /// DEA - Drug Enforcement Administration registration number.
        /// </summary>
        DrugEnforceAdminRegistrationNumber,

        /// <summary>
        /// DFN - Drug Furnishing or prescriptive authority Number.
        /// </summary>
        DrugFurnishingOrPrescriptiveAuthorityNumber,

        /// <summary>
        /// DI - Diner's Club card.
        /// </summary>
        DinersClubCard,

        /// <summary>
        /// DL - Driver's license number.
        /// </summary>
        DriversLicenseNumber,

        /// <summary>
        /// DN - Doctor number.
        /// </summary>
        DoctorNumber,

        /// <summary>
        /// DO - Osteopathic License number.
        /// </summary>
        OsteopathicLicenseNumber,

        /// <summary>
        /// DP - Diplomatic Passport.
        /// </summary>
        DiplomaticPassport,

        /// <summary>
        /// DPM - Podiatrist license number.
        /// </summary>
        PodiatristLicenseNumber,

        /// <summary>
        /// DR - Donor Registration Number.
        /// </summary>
        DonorRegistrationNumber,

        /// <summary>
        /// DS - Discover Card.
        /// </summary>
        DiscoverCard,

        /// <summary>
        /// EI - Employee number.
        /// </summary>
        EmployeeNumber,

        /// <summary>
        /// EN - Employer number.
        /// </summary>
        EmployerNumber,

        /// <summary>
        /// ESN - Staff Enterprise Number.
        /// </summary>
        StaffEnterpriseNumber,

        /// <summary>
        /// FDR - Fetal Death Report ID.
        /// </summary>
        FetalDeathReportId,

        /// <summary>
        /// FDRFN - Fetal Death Report File Number.
        /// </summary>
        FetalDeathReportFileNumber,

        /// <summary>
        /// FI - Facility ID.
        /// </summary>
        FacilityId,

        /// <summary>
        /// FILL - Filler Identifier.
        /// </summary>
        FillerIdentifier,

        /// <summary>
        /// GI - Guarantor internal identifier.
        /// </summary>
        GuarantorInternalIdentifier,

        /// <summary>
        /// GL - General ledger number.
        /// </summary>
        GeneralLedgerNumber,

        /// <summary>
        /// GN - Guarantor external  identifier.
        /// </summary>
        GuarantorExternalIdentifier,

        /// <summary>
        /// HC - Health Card Number.
        /// </summary>
        HealthCardNumber,

        /// <summary>
        /// IND - Indigenous/Aboriginal.
        /// </summary>
        IndigenousAboriginal,

        /// <summary>
        /// JHN - Jurisdictional health number (Canada).
        /// </summary>
        JurisdictionalHealthNumberCanada,

        /// <summary>
        /// LACSN - Laboratory Accession ID.
        /// </summary>
        LaboratoryAccessionId,

        /// <summary>
        /// LANR - Lifelong physician number.
        /// </summary>
        LifelongPhysicianNumber,

        /// <summary>
        /// LI - Labor and industries number.
        /// </summary>
        LaborAndIndustriesNumber,

        /// <summary>
        /// LN - License number.
        /// </summary>
        LicenseNumber,

        /// <summary>
        /// LR - Local Registry ID.
        /// </summary>
        LocalRegistryId,

        /// <summary>
        /// MA - Patient Medicaid number.
        /// </summary>
        PatientMedicaidNumber,

        /// <summary>
        /// MB - Member Number.
        /// </summary>
        MemberNumber,

        /// <summary>
        /// MC - Patient's Medicare number.
        /// </summary>
        PatientsMedicareNumber,

        /// <summary>
        /// MCD - Practitioner Medicaid number.
        /// </summary>
        PractitionerMedicaidNumber,

        /// <summary>
        /// MCN - Microchip Number.
        /// </summary>
        MicrochipNumber,

        /// <summary>
        /// MCR - Practitioner Medicare number.
        /// </summary>
        PractitionerMedicareNumber,

        /// <summary>
        /// MCT - Marriage Certificate.
        /// </summary>
        MarriageCertificate,

        /// <summary>
        /// MD - Medical License number.
        /// </summary>
        MedicalLicenseNumber,

        /// <summary>
        /// MI - Military ID number.
        /// </summary>
        MilitaryIdNumber,

        /// <summary>
        /// MR - Medical record number.
        /// </summary>
        MedicalRecordNumber,

        /// <summary>
        /// MRT - Temporary Medical Record Number.
        /// </summary>
        TemporaryMedicalRecordNumber,

        /// <summary>
        /// MS - MasterCard.
        /// </summary>
        Mastercard,

        /// <summary>
        /// NBSNR - Secondary physician office number.
        /// </summary>
        SecondaryPhysicianOfficeNumber,

        /// <summary>
        /// NCT - Naturalization Certificate.
        /// </summary>
        NaturalizationCertificate,

        /// <summary>
        /// NE - National employer identifier.
        /// </summary>
        NationalEmployerId,

        /// <summary>
        /// NH - National Health Plan Identifier.
        /// </summary>
        NationalHealthPlanId,

        /// <summary>
        /// NI - National unique individual identifier.
        /// </summary>
        NationalUniqueIndividualId,

        /// <summary>
        /// NII - National Insurance Organization Identifier.
        /// </summary>
        NationalInsuranceOrganizationId,

        /// <summary>
        /// NIIP - National Insurance Payor Identifier (Payor).
        /// </summary>
        NationalInsurancePayorId,

        /// <summary>
        /// NNxxx - National Person Identifier where the xxx is the ISO table 3166 3-character (alphabetic) country code.
        /// </summary>
        NationalPersonIdentifier,

        /// <summary>
        /// NP - Nurse practitioner number.
        /// </summary>
        NursePractitionerNumber,

        /// <summary>
        /// NPI - National provider identifier.
        /// </summary>
        NationalProviderIdentifier,

        /// <summary>
        /// OBI - Observation Instance Identifier.
        /// </summary>
        ObservationInstanceIdentifier,

        /// <summary>
        /// OD - Optometrist license number.
        /// </summary>
        OptometristLicenseNumber,

        /// <summary>
        /// PA - Physician Assistant number.
        /// </summary>
        PhysicianAssistantNumber,

        /// <summary>
        /// PC - Parole Card.
        /// </summary>
        ParoleCard,

        /// <summary>
        /// PCN - Penitentiary/correctional institution Number.
        /// </summary>
        PenitentiaryCorrectionalInstitutionNumber,

        /// <summary>
        /// PE - Living Subject Enterprise Number.
        /// </summary>
        LivingSubjectEnterpriseNumber,

        /// <summary>
        /// PEN - Pension Number.
        /// </summary>
        PensionNumber,

        /// <summary>
        /// PHC - Public Health Case Identifier.
        /// </summary>
        PublicHealthCaseIdentifier,

        /// <summary>
        /// PHE - Public Health Event Identifier.
        /// </summary>
        PublicHealthEventIdentifier,

        /// <summary>
        /// PHO - Public Health Official ID.
        /// </summary>
        PublicHealthOfficialId,

        /// <summary>
        /// PI - Patient internal identifier.
        /// </summary>
        PatientInternalIdentifier,

        /// <summary>
        /// PLAC - Placer Identifier.
        /// </summary>
        PlacerIdentifier,

        /// <summary>
        /// PN - Person number.
        /// </summary>
        PersonNumber,

        /// <summary>
        /// PNT - Temporary Living Subject Number.
        /// </summary>
        TemporaryLivingSubjectNumber,

        /// <summary>
        /// PPIN - Medicare/CMS Performing Provider Identification Number.
        /// </summary>
        MedicareCmsPerformingProviderIdNumber,

        /// <summary>
        /// PPN - Passport number.
        /// </summary>
        PassportNumber,

        /// <summary>
        /// PRC - Permanent Resident Card Number.
        /// </summary>
        PermanentResidentCardNumber,

        /// <summary>
        /// PRN - Provider number.
        /// </summary>
        ProviderNumber,

        /// <summary>
        /// PT - Patient external identifier.
        /// </summary>
        PatientExternalIdentifier,

        /// <summary>
        /// QA - QA number.
        /// </summary>
        QaNumber,

        /// <summary>
        /// RI - Resource identifier.
        /// </summary>
        ResourceIdentifier,

        /// <summary>
        /// RN - Registered Nurse Number.
        /// </summary>
        RegisteredNurseNumber,

        /// <summary>
        /// RPH - Pharmacist license number.
        /// </summary>
        PharmacistLicenseNumber,

        /// <summary>
        /// RR - Railroad Retirement number.
        /// </summary>
        RailroadRetirementNumber,

        /// <summary>
        /// RRI - Regional registry ID.
        /// </summary>
        RegionalRegistryId,

        /// <summary>
        /// RRP - Railroad Retirement Provider.
        /// </summary>
        RailroadRetirementProvider,

        /// <summary>
        /// SB - Social Beneficiary Identifier.
        /// </summary>
        SocialBeneficiaryIdentifier,

        /// <summary>
        /// SID - Specimen ID.
        /// </summary>
        SpecimenId,

        /// <summary>
        /// SL - State license.
        /// </summary>
        StateLicense,

        /// <summary>
        /// SN - Subscriber Number.
        /// </summary>
        SubscriberNumber,

        /// <summary>
        /// SNBSN - State assigned NDBS card Identifier.
        /// </summary>
        StateAssignedNdbsCardIdentifier,

        /// <summary>
        /// SNO - Serial Number.
        /// </summary>
        SerialNumber,

        /// <summary>
        /// SP - Study Permit.
        /// </summary>
        StudyPermit,

        /// <summary>
        /// SR - State registry ID.
        /// </summary>
        StateRegistryId,

        /// <summary>
        /// SS - Social Security number.
        /// </summary>
        SocialSecurityNumber,

        /// <summary>
        /// STN - Shipment Tracking Number.
        /// </summary>
        ShipmentTrackingNumber,

        /// <summary>
        /// TAX - Tax ID number.
        /// </summary>
        TaxIdNumber,

        /// <summary>
        /// TN - Treaty Number/ (Canada).
        /// </summary>
        TreatyNumberCanada,

        /// <summary>
        /// TPR - Temporary Permanent Resident (Canada).
        /// </summary>
        TemporaryPermanentResidentCanada,

        /// <summary>
        /// TRL - Training License Number.
        /// </summary>
        TrainingLicenseNumber,

        /// <summary>
        /// U - Unspecified identifier.
        /// </summary>
        UnspecifiedIdentifier,

        /// <summary>
        /// UDI - Universal Device Identifier.
        /// </summary>
        UniversalDeviceIdentifier,

        /// <summary>
        /// UPIN - Medicare/CMS (formerly HCFA)'s Universal Physician Identification numbers.
        /// </summary>
        MedicareCmsUniversalPhysicianId,

        /// <summary>
        /// USID - Unique Specimen ID.
        /// </summary>
        UniqueSpecimenId,

        /// <summary>
        /// VN - Visit number.
        /// </summary>
        VisitNumber,

        /// <summary>
        /// VP - Visitor Permit.
        /// </summary>
        VisitorPermit,

        /// <summary>
        /// VS - VISA.
        /// </summary>
        Visa,

        /// <summary>
        /// WC - WIC identifier.
        /// </summary>
        WicIdentifier,

        /// <summary>
        /// WCN - Workers' Comp Number.
        /// </summary>
        WorkersCompNumber,

        /// <summary>
        /// WP - Work Permit.
        /// </summary>
        WorkPermit,

        /// <summary>
        /// XV - Health Plan Identifier.
        /// </summary>
        HealthPlanIdentifier,

        /// <summary>
        /// XX - Organization identifier.
        /// </summary>
        OrganizationIdentifier
    }
}

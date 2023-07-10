﻿namespace ClearHl7.Codes.V281
{
    /// <summary>
    /// HL7 Version 2 Table 0309 - Coverage Type.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0309</remarks>
    public enum CodeCoverageType
    {
        /// <summary>
        /// B - Both hospital and physician.
        /// </summary>
        BothHospitalAndPhysician,

        /// <summary>
        /// H - Hospital/institutional.
        /// </summary>
        HospitalInstitutional,

        /// <summary>
        /// P - Physician/professional.
        /// </summary>
        PhysicianProfessional,

        /// <summary>
        /// RX - Pharmacy.
        /// </summary>
        Pharmacy
    }
}

﻿namespace ClearHl7.Codes.V240
{
    /// <summary>
    /// HL7 Version 2 Table 0066 - Employment Status.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0066</remarks>
    public enum CodeEmploymentStatus
    {
        /// <summary>
        /// 1 - Full time employed.
        /// </summary>
        FullTimeEmployed,

        /// <summary>
        /// 2 - Part time employed.
        /// </summary>
        PartTimeEmployed,

        /// <summary>
        /// 3 - Unemployed.
        /// </summary>
        Unemployed,

        /// <summary>
        /// 4 - Self-employed.
        /// </summary>
        SelfEmployed,

        /// <summary>
        /// 5 - Retired.
        /// </summary>
        Retired,

        /// <summary>
        /// 6 - On active military duty.
        /// </summary>
        OnActiveMilitaryDuty,

        /// <summary>
        /// 9 - Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// C - Contract, per diem.
        /// </summary>
        ContractPerDiem,

        /// <summary>
        /// D - Per Diem.
        /// </summary>
        PerDiem,

        /// <summary>
        /// F - Full Time.
        /// </summary>
        FullTime,

        /// <summary>
        /// L - Leave of absence (e.g., family leave, sabbatical, etc.).
        /// </summary>
        LeaveOfAbsence,

        /// <summary>
        /// O - Other.
        /// </summary>
        Other,

        /// <summary>
        /// P - Part Time.
        /// </summary>
        PartTime,

        /// <summary>
        /// T - Temporarily unemployed.
        /// </summary>
        TemporarilyUnemployed
    }
}

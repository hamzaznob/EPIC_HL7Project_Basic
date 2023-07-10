﻿namespace ClearHl7.Codes.V290
{
    /// <summary>
    /// HL7 Version 2 Table 0206 - Segment Action Code.
    /// </summary>
    /// <remarks>https://www.hl7.org/fhir/v2/0206</remarks>
    public enum CodeSegmentActionCode
    {
        /// <summary>
        /// A - Add/Insert.
        /// </summary>
        AddInsert,

        /// <summary>
        /// D - Delete.
        /// </summary>
        Delete,

        /// <summary>
        /// S - Used in Snapshot mode.
        /// </summary>
        UsedInSnapshotMode,

        /// <summary>
        /// U - Update.
        /// </summary>
        Update,

        /// <summary>
        /// X - No Change.
        /// </summary>
        NoChange
    }
}

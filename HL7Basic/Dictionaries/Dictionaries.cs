using System.Collections.Generic;

namespace HL7Basic.Dictionaries
{
  
        public class MshFieldMappingDictionary
        {
            public Dictionary<int, string> Msh_FieldMapping_Dictionary { get; set; }

            public MshFieldMappingDictionary()
            {
            Msh_FieldMapping_Dictionary = new Dictionary<int, string>()
        {
            { 1, "FieldSeparator" },
            { 2, "EncodingCharacters" },
            { 3, "SendingApplication" },
            { 4, "SendingFacility" },
            { 5, "ReceivingApplication" },
            { 6, "ReceivingFacility" },
            { 7, "DateTimeOfMessage" },
            { 8, "Security" },
            { 9, "MessageType" },
            { 10, "MessageControlID" },
            { 11, "ProcessingID" },
            { 12, "VersionID" },
            { 13, "SequenceNumber" },
            { 14, "ContinuationPointer" },
            { 15, "AcceptAcknowledgmentType" },
            { 16, "ApplicationAcknowledgmentType" },
            { 17, "CountryCode" },
            { 18, "CharacterSet" }
        };
            }
        }

    
}

using System.Collections.Generic;

namespace HL7Basic.Models
{
    public class MSHSegmentFields
    {
        public string FieldSeparator { get; set; }
        public string EncodingCharacters { get; set; }
        public List<SendingApplication> SendingApplication { get; set; }
   //     public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
       // public string ReceivingApplication { get; set; }
        public List<ReceivingApplication> ReceivingApplication { get; set; }

        public string ReceivingFacility { get; set; }
        public string DateTimeOfMessage { get; set; }
        public string Security { get; set; }
//        public string MessageType { get; set; }
        public List<MessageType> MessageType { get; set; }
        public string MessageControlID { get; set; }
        public string ProcessingID { get; set; }
        public string VersionID { get; set; }
        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgmentType { get; set; }
        public string ApplicationAcknowledgmentType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
    }

    public class SendingApplication {
        public string SendingApplication_Namespace_ID { get; set; }
        public string SendingApplication_Universal_ID { get; set; }
        public string SendingApplication_Universal_ID_Type { get; set; }
    }
    public class ReceivingApplication
    {
        public string ReceivingApplication_Namespace_ID { get; set; }
        public string ReceivingApplication_Universal_ID { get; set; }
        public string ReceivingApplication_Universal_ID_Type { get; set; }  
    }

    public class MessageType
    {
        public string Message_Code { get; set; }
        public string Trigger_Event { get; set; }
        public string Message_Structure { get; set; }
    }
}

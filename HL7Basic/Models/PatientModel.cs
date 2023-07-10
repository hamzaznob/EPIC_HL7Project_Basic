using Hl7.Fhir.Model;
using System.Collections.Generic;




public class PatientModel:Patient
    {
        public string Id { get; set; }
        public List<IdentifierModel> Identifier { get; set; }
        public string Active { get; set; }
        public List<HumanNameModel> Name { get; set; }
        public List<ContactPointModel> Telecom { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public List<AddressModel> Address { get; set; }
        public List<AttachmentModel> Photo { get; set; }
        public List<ReferenceModel> Contact { get; set; }
        public ReferenceModel ManagingOrganization { get; set; }
        public List<ReferenceModel> Link { get; set; }
    }

    public class IdentifierModel
    {
        public string System { get; set; }
        public string Value { get; set; }
    }

    public class HumanNameModel
    {
        public string Use { get; set; }
        public string Text { get; set; }
        public string Family { get; set; }
        public List<string> Given { get; set; }
        public List<string> Prefix { get; set; }
        public List<string> Suffix { get; set; }
    }

    public class ContactPointModel
    {
        public string System { get; set; }
        public string Value { get; set; }
        public string Use { get; set; }
    }

    public class AddressModel
    {
        public string Use { get; set; }
        public string Line { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class AttachmentModel
    {
        public string ContentType { get; set; }
        public string Language { get; set; }
        public string Data { get; set; }
    }

    public class ReferenceModel
    {
        public string Reference { get; set; }
        public string Display { get; set; }
    }

















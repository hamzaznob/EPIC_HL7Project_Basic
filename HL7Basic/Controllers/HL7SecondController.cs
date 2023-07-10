using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Hl7.Fhir.Serialization;
using HL7Basic.Models;
using System.IO;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using NHapi.Base.Parser;
using Microsoft.AspNetCore.SignalR.Protocol;
using NHapi.Model.V24.Message;







namespace HL7Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HL7SecondController : ControllerBase
    {




        [NonAction]
        public PatientModel ParseHl7Message(string hl7Message)
        {
            var parser = new FhirJsonParser();
            var patient = parser.Parse<PatientModel>(hl7Message);

            return patient;
        }

        [NonAction]
        public string ConvertToFhirJson(PatientModel patient)
        {
            var serializer = new FhirJsonSerializer();
            var json = serializer.SerializeToString(patient);

            return json;
        }


        [HttpPost]
        public IActionResult ParseHl7(IFormFile hl7File)
        {

            if (hl7File == null || hl7File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            // Save the file to a temporary location on the server
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                 hl7File.CopyToAsync(stream);
            }

            // Parse the HL7 ADT message
            var parser = new PipeParser();
            ADT_A01 message = null;     
            try
            {
                message = parser.Parse(filePath) as ADT_A01;



                using (var reader = new StreamReader(hl7File.OpenReadStream()))
                {
                    string hl7Content = reader.ReadToEnd();


                   // string hl7Message = "<HL7 Message>"; // Replace with your HL7 message

                   // var patient = ParseHl7ToPatient(hl7Content);






                    ////////////////////////////////////////////////////////
                    //    var patient2 = ParseHl7ToPatient(hl7Content);

                    //  var serializer = new FhirJsonSerializer();
                    //   var json2 = serializer.SerializeToString(patient2);
                    ///////////////////////////////////////////////////////

                    // string hl7Message = "<HL7 Message>"; // Replace with your HL7 message

                    //   var patient = ParseHl7Message(hl7Content);
                    //   var json = ConvertToFhirJson(patient);

                    // Do something with the JSON representation of the FHIR resource

                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error processing HL7 message: " + ex.Message);
            }



        }





        [NonAction]
        public Patient ParseHl7ToPatient(string hl7Message)
        {
            var parser = new PipeParser();
            var message = parser.Parse(hl7Message) as ADT_A01;

            var patient = new Patient();

            // Extract data from HL7 message and map it to the Patient resource
            var pidSegment = message.PID;
            var name = pidSegment.GetPatientName(0);

            var humanName = new HumanName();
            humanName.Given = new[] { name.GivenName.Value };
//            humanName.Family = name.FamilyName.Value.ToString();

            patient.Name = new List<HumanName> { humanName };
          //  patient.Gender = EnumUtility.ParseLiteral<AdministrativeGender>(pidSegment.AdministrativeSex.Value)?.Value;
            patient.BirthDate = new FhirDateTime(pidSegment.DateTimeOfBirth.TimeOfAnEvent.Value)?.Value;

            // ... Map other properties as needed

            return patient;
        }







        [NonAction]
        public Patient ParseHl7ToPatient2(string hl7Message)
        {
            // Parsing HL7 message code...

            var patient = new Patient
            {
                // Set other properties as needed
                Name = new List<HumanName>(new[] { new HumanName { Family = "Doe", Given = new[] { "John" } } }),
                Gender = AdministrativeGender.Male,
                BirthDate = "1980-01-01"
            };

            return patient;
        }


        [NonAction]
        public Patient ParseHl7ToPatient1(string hl7Message)
        {
            var parser = new PipeParser();
            var message = parser.Parse(hl7Message) as ADT_A01;

            var patient = new Patient();

            // Extract data from HL7 message and map it to the Patient resource
            var pidSegment = message.PID;
            var name = pidSegment.GetPatientName(0);
            var address = pidSegment.GetPatientAddress(0);



            var patient2 = ParseHl7ToPatient(hl7Message);

      //      patient.Name.Add(new HumanName().WithGiven(name.GivenName.Value).AndFamily(name.FamilyName.Value));
//            patient.BirthDate = new FhirDateTime(pidSegment.DateTimeOfBirth.TimeOfAnEvent.Value);
            patient.BirthDate = new FhirDateTime(pidSegment.DateTimeOfBirth.TimeOfAnEvent.Value).ToString();


       //     patient.Gender = EnumUtility.ParseLiteral<AdministrativeGender>(pidSegment.AdministrativeSex.Value).Value;

            // ... Map other properties as needed

            return patient;
        }






    }
}

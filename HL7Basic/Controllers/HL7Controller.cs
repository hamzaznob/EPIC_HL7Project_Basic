using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using System.Text;
using NHapi.Base.Parser;
using NHapi.Model.V251.Message;
using NHapi.Model.V251.Segment;
using Xunit;
using Microsoft.AspNetCore.SignalR.Protocol;
using HL7;
//using Hl7.Fhir.Utility;

using ClearHl7;
using ClearHl7.Serialization;
using ClearHl7.V282;
using ClearHl7;
using ClearHl7.Helpers;

namespace HL7Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HL7Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessHL7Message(IFormFile hl7File)
        {
            return ReadHL7Message(hl7File);
        }
        [NonAction]
        public IActionResult ReadHL7Message(IFormFile hl7File)
        {
        
            try
            {
                if (hl7File == null || hl7File.Length == 0)
                    return BadRequest("No file uploaded or the file is empty.");

                using (var reader = new StreamReader(hl7File.OpenReadStream()))
                {
                    string hl7Content = reader.ReadToEnd();

                    Hl7Version version = MessageHelper.DetectVersion(hl7Content);



                    IMessage message = MessageSerializer.Deserialize(hl7Content);




                    HL7V2 obj = new HL7V2(hl7Content);

                    string[] part_PID0 = obj.GetSegment("PID[0][1]");
                    string[] part_PID1 = obj.GetSegment("PID[1]");
                    string[] part_PID2 = obj.GetSegment("MSH");
                    string[] part_PID3 = obj.GetSegment("PID[3]");
                    string[] part_PID4 = obj.GetSegment("PID[4]");



                    Encoding encoding = Encoding.ASCII; // Replace with your desired encoding

                    // Create an instance of the CustomPipeParser with the specified encoding
                    CustomPipeParser parser = new CustomPipeParser(encoding);


                    // Parse the HL7 message
                    var message2 = parser.Parse(hl7Content);


                    return Ok("HL7 message processed successfully");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error processing HL7 message: " + ex.Message);
            }
        }
        // Custom PipeParser subclass
        private class CustomPipeParser : PipeParser
        {
            // Empty implementation
            private readonly Encoding encoding;

            public CustomPipeParser(Encoding encoding)
            {
                this.encoding = encoding;
            }

            public override string DefaultEncoding => encoding.WebName;
        }

      

    }



}

using ClearHl7.Serialization;
using ClearHl7;
using HL7;
using HL7Basic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using HL7.Dotnetcore;
using System;
using System.Collections.Generic;
using HL7Basic.Dictionaries;
using System.Collections;

namespace HL7Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HL7_dotnetcore_masterController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessHL7Message(IFormFile hl7File)
        {
            return ReadHL7Message(hl7File);
        }
        [NonAction]
        public IActionResult ReadHL7Message(IFormFile hl7File)
        {
            //https://github.com/Efferent-Health/HL7-dotnetcore
            try
            {
                if (hl7File == null || hl7File.Length == 0)
                    return BadRequest("No file uploaded or the file is empty.");

                using (var reader = new StreamReader(hl7File.OpenReadStream()))
                {
                    string hl7Content = reader.ReadToEnd();


                    Message message = new Message(hl7Content);

                    //bypass validation
                    message.ParseMessage(true);


                    List<Segment> segList = message.Segments();

                    MSHSegmentFields _MSHSegmentFields = new MSHSegmentFields();

                    MshFieldMappingDictionary _MshFieldMappingDictionary = new MshFieldMappingDictionary();


                    // Access the field mappings from the mshFieldMapping object
                    Dictionary<int, string> MSH_fieldMapping = _MshFieldMappingDictionary.Msh_FieldMapping_Dictionary;


                    for (int i=0;i<segList.Count;i++)
                    {
                        List<Field> fields = segList[i].GetAllFields();

                        // Check the first three characters of the sending application
                        string firstThreeChars = segList[i].Value.Substring(0, 3);

                        //for (int j = 0; j < fields.Count; j++)
                        //{
                            

                            if (firstThreeChars == "MSH")
                            {
                                //bool isComponentized = message.Segments("MSH")[0].Fields(j + 1).IsComponentized;
                                //if(isComponentized)
                                //{ 
                                // List<Component> list =  message.Segments("MSH")[0].Fields(j + 1).Components();
                                //}
                                foreach (var mapping in MSH_fieldMapping)
                                {

                                    int fieldIndex = mapping.Key;
                                    string propertyName = mapping.Value;

                                    if(fieldIndex<= fields.Count) { 

                                    bool isComponentized2 = message.Segments("MSH")[0].Fields(fieldIndex).IsComponentized;
                                    if (isComponentized2)
                                    {
                                        try {
                                            List<Component> componentList = message.Segments("MSH")[0].Fields(fieldIndex).Components();
                                            Type propertyType = _MSHSegmentFields.GetType().GetProperty(propertyName)?.PropertyType;

                                            if (propertyType != null && propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                                            {
                                                Type listItemType = propertyType.GetGenericArguments()[0];
                                                IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listItemType));

                                                //foreach (Component component in componentList)
                                                //{
                                                //    object listItem = Activator.CreateInstance(listItemType);
                                                //    // Assuming the listItemType has properties to assign the component values, you can modify this part accordingly
                                                //    // For example: listItem.GetType().GetProperty("PropertyName")?.SetValue(listItem, component.Value);
                                                //    // Example: Assigning component values to properties of the list item
                                                //    listItem.GetType().GetProperty("MessageType")?.SetValue(listItem, component.Value);
                                                //    listItem.GetType().GetProperty("MssageID")?.SetValue(listItem, component.Value);
                                                //    listItem.GetType().GetProperty("SendingApplicationName")?.SetValue(listItem, component.Value);

                                                //    list.Add(listItem);
                                                //}

                                                //_MSHSegmentFields.GetType().GetProperty(propertyName)?.SetValue(_MSHSegmentFields, list);


                                                object listItem = Activator.CreateInstance(listItemType);
                                                int componentIndex = 0;

                                                foreach (var property in listItemType.GetProperties())
                                                {
                                                    // Check if the component index is within the range
                                                    if (componentIndex < componentList.Count)
                                                    {
                                                        property.SetValue(listItem, componentList[componentIndex].Value);
                                                        componentIndex++;
                                                    }
                                                }

                                                list.Add(listItem);
                                                _MSHSegmentFields.GetType().GetProperty(propertyName)?.SetValue(_MSHSegmentFields, list);



                                            }
                                        }
                                        catch (System.Exception ex)
                                        {
                                            return BadRequest("Error handling SubComponents: " + ex.Message);
                                        }
                                      

                                    }

                                    else { 
                                    // Check if the field index is within the range
                                    if (fieldIndex >= 1 && fieldIndex <= fields.Count)

                                    {
                                        string fieldValue = fields[fieldIndex - 1].Value;

                                        // Use reflection to set the property value dynamically
                                        _MSHSegmentFields.GetType().GetProperty(propertyName)?.SetValue(_MSHSegmentFields, fieldValue);
                                    }
                                    }

                                }
                                }




                            }
                            else if (firstThreeChars == "EVN")
                            {

                            }
                            else if (firstThreeChars == "PID")
                            {

                            }
                            else if (firstThreeChars == "NK1")
                            {

                            }
                            else if (firstThreeChars == "PV1")
                            {
                            }

                     //   }


                    }



                    //string SendingFacility1 = message.GetValue("MSH.4");
                    //string SendingFacility2 = message.DefaultSegment("MSH").Fields(4).Value;
                    //string PatientName = message.DefaultSegment("PID").Fields(5).Value;
                    //string SendingFacility3 = message.Segments("MSH")[0].Fields(4).Value;





                    return Ok(_MSHSegmentFields);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error processing HL7 message: " + ex.Message);
            }
        }




    }
}

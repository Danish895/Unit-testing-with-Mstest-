using Microsoft.AspNetCore.Mvc;
using StructureOfProject.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StructureOfProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class XmlDeserializerProperty : ControllerBase
    {
        [Route("XmlDeserializerRequest")]
        [HttpPost]
        public string getXmlRequestDeserialized([FromBody] XElement xml)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ListOfXmlRequestClass), new XmlRootAttribute("INFORMATION"));
            ListOfXmlRequestClass obj;
            string xmlString = xml.ToString();
            //string xmlString = xml.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("ADDITIONAL_FIELDS")).ToString();

            using (StringReader reader = new StringReader(xmlString))
            {
                obj = (ListOfXmlRequestClass)serializer.Deserialize(reader);
            }
            var jsonFile = new XmlRequestClass();
            //jsonFile = obj.Items.ToString();
            string jsonString = JsonSerializer.Serialize(obj);
            Console.Write(obj);
            Console.Write(jsonFile);
            Console.Write(jsonString);
            return jsonString;
        }

        [Route("TextDeserializerRequest")]
        [HttpPost]
        public async Task<string> getTextRequestDeserialized()
        {
            string jsonString;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                jsonString = await reader.ReadToEndAsync();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(ListOfXmlRequestClass));
            ListOfXmlRequestClass obj;
            //string xmlString = xml.ToString();
            //string xmlString = xml.Descendants().FirstOrDefault(d => d.Name.LocalName.Equals("ADDITIONAL_FIELDS")).ToString();

            using (StringReader reader = new StringReader(jsonString))
            {
                obj = (ListOfXmlRequestClass)serializer.Deserialize(reader);
            }
            var jsonFile = new XmlRequestClass();
            //jsonFile = obj.Items.ToString();
            string jsonString2 = JsonSerializer.Serialize(obj);
            Console.Write(obj);
            Console.Write(jsonFile);
            Console.Write(jsonString2);
            return jsonString2;
        }
    }
}

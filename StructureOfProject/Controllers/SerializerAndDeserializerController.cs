using Microsoft.AspNetCore.Mvc;
using StructureOfProject.Models;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace StructureOfProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SerializerAndDeserializerController : ControllerBase
    {
        [HttpGet]
        [Route("JsonSerializer")]
        public string getSerialized()
        {

            var People = new People()
            {
                Id = 1,
                Name = "Md Danish "
            };

             string jsonString = JsonSerializer.Serialize(People);
            return jsonString;
        }

        [HttpGet]
        [Route("JsonDeserializer")]
        public string getDeSerialized()
        {

            string serializedString = @"{ ""Id"":1,""Name"":"" Md Danish""}";
            //string serializedString = "{"Id":1,"Name":"Hot"}";

            //var fileName = new JsonContent(){
            //    Id = 1,
            //    Name = "Hot"
            //};
           // string jsonString = File.ReadAllText(fileName);

            //string jsonString = JsonSerializer.Deserialize(serializedString);
            People people = JsonSerializer.Deserialize<People>(serializedString);

            Console.WriteLine(people);
            Console.WriteLine($"{people.Name}");
           // Console.WriteLine(People);
            return "Deserializtion Done";
        }

        [HttpGet]
        [Route("XmlSerializer")]
        public void getXmlSerialized()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(People));
            //People i = new People();
            //i.Id = 2;
            //i.Name = "Regular Danish";

            var people = new People()
            {
                Id = 1,
                Name = "Danish Khan"
            };

            string filename = "xmlSerializer.xml";
            FileStream fs = new FileStream(filename, FileMode.Create);
            TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
            
            serializer.Serialize(writer, people);
            writer.Close();
        }

        [Route("XmlDeserializer")]
        [HttpGet]
        public void getXmlDesrialized()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(People));
            People people;
            string filename = "xmlSerializer.xml";

            using (FileStream reader = new FileStream(filename, FileMode.Open))
            {
                people = (People)serializer.Deserialize(reader);
            }
            Console.Write("Id :" + people.Id +"\n" +"Name :"+ people.Name);
        }
    }
}

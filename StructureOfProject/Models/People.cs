using System.Xml.Serialization;

namespace StructureOfProject.Models
{
    [Serializable()]
    [XmlRoot(ElementName ="People")]
    public class People
    {
        [XmlElement("IdValue")]
        public int Id { get; set; }

        [XmlElement("NameValue")]
        public string Name { get; set; }
    }
}

using System.Xml.Serialization;

namespace StructureOfProject.Models
{
    [XmlRoot(ElementName = "INFORMATION")]
    public class ListOfXmlRequestClass
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        public List<XmlRequestClass> Items { get; set; }
    }
}

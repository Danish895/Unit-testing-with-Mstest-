using System.Xml.Serialization;

namespace StructureOfProject.Models
{
    [Serializable()]
    [XmlRoot(ElementName = "INFORMATION")]
    public class ListOfXmlRequestClass
    {
        public ListOfXmlRequestClass() { Items = new List<XmlRequestClass>(); }



        [XmlElement("ADDITIONAL_FIELDS")]
        public List<XmlRequestClass> Items { get; set; }
    }
}

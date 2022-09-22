using System.Xml.Serialization;

namespace StructureOfProject.Models
{
    
    public class XmlRequestClass
    {
        [XmlElement("ZPRDTYP")]
        public string ZPRDTYP { get; set; }

        [XmlElement("RSTERM")]
        public int RSTERM { get; set; }

        [XmlElement("PMTERM")]
        public int PMTERM { get; set; }

        [XmlElement("PAYMMETH")]
        public string PAYMMETH { get; set; }

        [XmlElement("PAYFREQ")]
        public int PAYFREQ { get; set; }

        [XmlElement("RCDDATE")]
        public int RCDDATE { get; set; }

        [XmlElement("LASEX")]
        public string LASEX { get; set; }

        [XmlElement("LADOB")]
        public int LADOB { get; set; }

        [XmlElement("LACRTBL")]
        public string LACRTBL { get; set; }

        [XmlElement("LAINSPR")]
        public int LAINSPR { get; set; }
        
    }
}

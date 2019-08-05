using System;
using System.Xml.Serialization;

namespace TestExercise
{/// <summary>
/// класс для хранени полученных данных
/// </summary>
    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "rise")]
        public DateTime Rise { get; set; }
        [XmlAttribute(AttributeName = "set")]
        public DateTime Set { get; set; }
    }
    [XmlRoot(ElementName = "city")]
    public class City
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }
    }
    [XmlRoot(ElementName = "temperature")]
    public class Temperature
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set;}
    }
    [XmlRoot(ElementName = "humidity")]
    public class Humidity
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "lastupdate")]
    public class Lastupdate
    {
        [XmlAttribute(AttributeName = "value")]
        public DateTime Value { get; set; }
    }

    [XmlRoot(ElementName = "current")]
    public class Current
    {
        [XmlElement(ElementName = "city")]
        public City city { get; set; }
        [XmlElement(ElementName = "temperature")]
        public Temperature temperature { get; set; }
        [XmlElement(ElementName = "humidity")]
        public Humidity humidity { get; set; }
        [XmlElement(ElementName = "lastupdate")]
        public Lastupdate Lastupdate { get; set; }
    }
}
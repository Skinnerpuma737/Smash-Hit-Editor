using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[System.Serializable]
public class Segment { 
    [XmlIgnore]
    public string Name;

    [XmlElement("")]
    public List<Box> box = new List<Box>();

    [XmlAttribute("Size")]
    public string size;
}

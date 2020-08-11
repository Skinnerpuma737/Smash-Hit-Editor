using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[System.Serializable]
public class Segment { 
    [XmlIgnore]
    public string Name;

    [XmlElement("")]
    public Box[] box;

    [XmlAttribute("Size")]
    public string size;
}

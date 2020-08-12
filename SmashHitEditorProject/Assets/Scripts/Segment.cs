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

    [XmlIgnore]
    public Vector3 s;

    [XmlAttribute("Size")]
    public string size;
}

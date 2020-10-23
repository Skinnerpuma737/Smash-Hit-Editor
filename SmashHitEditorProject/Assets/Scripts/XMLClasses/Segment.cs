using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[System.Serializable]
public class segment { 
    /* This class name needs to be lower case otherwise the XML searializer
     * thinks that Segment should be capitialized, which doesn't work. */
    [XmlIgnore]
    public string Name;

    [XmlElement("")]
    public List<Box> box = new List<Box>();

    [XmlElement("")]
    public List<Obstacle> obstacle = new List<Obstacle>();

    [XmlIgnore]
    public Vector3 s;

    [XmlAttribute("size")]
    public string size;
}

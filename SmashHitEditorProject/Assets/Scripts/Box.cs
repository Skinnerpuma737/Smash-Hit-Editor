using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Box
{
    [XmlIgnore]
    public GameObject visual;

    [XmlIgnore]
    public Vector3 s;

    [XmlIgnore]
    public Vector3 p;

    [XmlAttribute("Size")]
    public string size;

    [XmlAttribute("Pos")]
    public string pos;

}

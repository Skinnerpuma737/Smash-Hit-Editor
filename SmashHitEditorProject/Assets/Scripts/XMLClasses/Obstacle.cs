using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Obstacle
{

    [XmlIgnore]
    public GameObject visual;

    [XmlIgnore]
    public Vector3 p;

    [XmlAttribute("pos")]
    public string pos;

    [XmlAttribute("type")]
    public string type = "";

    [XmlIgnore]
    public string[] parameters = new string[4];

    [XmlAttribute("param1")]
    public string param1;

    [XmlAttribute("param2")]
    public string param2;

    [XmlAttribute("param3")]
    public string param3;

    [XmlAttribute("param4")]
    public string param4;
}

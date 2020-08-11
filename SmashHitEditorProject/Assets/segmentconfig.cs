using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentconfig : MonoBehaviour
{
    public Vector3 size;
    public string Name;
    Data d;
    private void Start()
    {
        d = FindObjectOfType<Data>();
    }
    private void Update()
    {
        d.seg.Name = Name;
        d.seg.size = size.x + " " + size.y + " " + size.z;
    }

}

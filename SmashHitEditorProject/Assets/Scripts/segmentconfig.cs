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
        #region stop negative size
        if (size.x < 0)
        {
            size = new Vector3(1, size.y, size.z);
        }
        if (size.y < 0)
        {
            size = new Vector3(size.x, 1, size.z);
        }
        if (size.z < 0)
        {
            size = new Vector3(size.x, size.y, 1);
        }
        #endregion
        d.seg.Name = Name;
        #region format
        string x, y, z;
        if (size.x == Mathf.RoundToInt(size.x))
        {
            x = size.x + ".0";
        }
        else
        {
            x = size.x + "";
        }
        if (size.y == Mathf.RoundToInt(size.y))
        {
            y = size.y + ".0";
        }
        else
        {
            y = size.y + "";
        }
        if (size.z == Mathf.RoundToInt(size.z))
        {
            z = size.z + ".0";
        }
        else
        {
            z = size.z + "";
        }
        #endregion
        d.seg.size = x + " " + y + " " + z;
    }

}

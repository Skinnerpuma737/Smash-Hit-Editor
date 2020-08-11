using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public Data d;
    public GameObject grid;
    public Material gridmat;
    public segmentconfig s;

    public Vector2 gridSize;
    Material g;

    public GameObject cube;
    private void Start()
    {
        g = new Material(gridmat);
        
    }
    private void Update()
    {
        #region grid
        gridSize = new Vector2(s.size.x, s.size.z);
        grid.transform.localScale = new Vector3(gridSize.x, 0.01f, gridSize.y);
        grid.transform.position = new Vector3(0.5f, 0, 0.5f) + new Vector3(gridSize.x / 2,-0.5f,gridSize.y / 2);
        g.mainTextureScale = gridSize;
        grid.GetComponent<Renderer>().material = g;
        #endregion
    }

    public void CreateCube()
    {
        GameObject obj = Instantiate(cube);
        obj.transform.position = new Vector3(1, 0, 1);
        Box b = new Box();
        b.size = "1.0 1.0 1.0";
        float xpos = s.size.x / 2;
        float ypos = s.size.y / 2;
        string x;
        string y;
        #region format
        if (s.size.x % 2 == 0)
        {
            x = -xpos + ".0";
        }
        else
        {
            x = -xpos + "";
        }
        if (s.size.y % 2 == 0)
        {
            y = -ypos + ".0";
        }
        else
        {
            y = -ypos + "";
        }
        #endregion

        b.pos = x + " " + y + " " + "0.0";
        d.seg.box.Add(b);
    }
}

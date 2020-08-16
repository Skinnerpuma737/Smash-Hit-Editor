using System;
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
    public Camera maincamera;

    public Vector2 gridSize;
    Material g;

    public GameObject cube;
    Material Selectmat = null;
    
    Box selectedBox;
    private void Start()
    {
        g = new Material(gridmat);
        
    }
    private void Update()
    {
        #region grid
        gridSize = new Vector2(s.size.x, s.size.z);
        grid.transform.localScale = new Vector3(gridSize.x, 0.01f, gridSize.y);
        grid.transform.position = new Vector3(0, 0, 0) + new Vector3(gridSize.x / 2,-0.5f,gridSize.y / 2);
        g.mainTextureScale = gridSize;
        grid.GetComponent<Renderer>().material = g;
        #endregion

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(maincamera.transform.position, ray.direction * 100f,Color.red,2);
            Box b = null;
            
            if (Physics.Raycast(ray,out hit,1000f))
            {
                
                

                Transform objectHit = hit.transform;
                
                
                for (int i = 0; i < d.seg.box.Count; i++)
                {
                    if (d.seg.box[i].visual == objectHit.transform.gameObject)
                    {
                        b = d.seg.box[i];
                    }
                }
                
                Selectmat.color = Color.yellow;
                objectHit.GetComponent<Renderer>().material = Selectmat;
                selectedBox = b;
                
            }
            
        }
    }

    public void CreateCube()
    {
        GameObject obj = Instantiate(cube);
        obj.transform.position = new Vector3(0.5f, 0, 0.5f);
        Box b = new Box();
        b.s = new Vector3(1, 1, 1);
        b.visual = obj;
        float xpos = s.size.x / 2;
        float ypos = s.size.y / 2;


        b.p = new Vector3(-xpos, -ypos, 0);
        d.seg.box.Add(b);
        
    }
}

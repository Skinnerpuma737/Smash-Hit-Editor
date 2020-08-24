using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Editor : MonoBehaviour
{
    
    public Data d;
    public GameObject grid;
    public Material gridmat;
    public segmentconfig s;
    public Camera maincamera;

    public Vector2 gridSize;
    Material g;

    public GameObject selectionBox;

    public InputField snapA;
    public InputField snapB;

    /// <summary>
    /// Scale UI
    /// </summary>
    public GameObject scaleUI;
    public InputField scaleUIX;
    public InputField scaleUIY;
    public InputField scaleUIZ;
    public RectTransform scalePointOne;
    public RectTransform scalePointTwo;


    /// <summary>
    /// In Editor
    /// </summary>
    public float snapPrecision = 1.0f;

    public GameObject cube;


    Box selectedBox = null;
    private void Start()
    {
        g = new Material(gridmat);
        
    }
    private void Update()
    {
        #region grid
        gridSize = new Vector2(s.size.x, s.size.z);
        grid.transform.localScale = new Vector3(gridSize.x, 0.01f, gridSize.y);
        grid.transform.position = new Vector3(0, 0, 0) + new Vector3(gridSize.x / 2,-0f,gridSize.y / 2);
        g.mainTextureScale = gridSize;
        grid.GetComponent<Renderer>().material = g;
        #endregion

        if (snapA.text == "")
        {
            snapA.text = "1";
        }
        if (snapB.text == "")
        {
            snapB.text = "1";
        }
        if (snapA.interactable == true)
        {
            snapPrecision = float.Parse(snapA.text);
        }
        else if (snapB.interactable == true)
        {
            snapPrecision = float.Parse(snapB.text);
        }


        if (selectedBox != null)
        {
            MoveCubeInput();
            SetScale();
        }


        SelectCube();
        if (selectedBox != null)
        {
            selectionBox.transform.position = selectedBox.visual.transform.position + 
                new Vector3(selectedBox.visual.transform.localScale.x / 2, selectedBox.visual.transform.localScale.y / 2, -(selectedBox.visual.transform.localScale.z / 2));
            selectionBox.transform.localScale = selectedBox.s + new Vector3(0.1f,0.1f,0.1f);
        }

        

        if (selectedBox != null)
        {
            scaleUI.transform.position = Vector3.MoveTowards(scaleUI.transform.position, new Vector3(scaleUI.transform.position.x, scalePointTwo.transform.position.y, scaleUI.transform.position.z), 2);
        }
        else
        {
            
            scaleUI.transform.position = Vector3.MoveTowards(scaleUI.transform.position, new Vector3(scaleUI.transform.position.x, scalePointOne.transform.position.y, scaleUI.transform.position.z), 2);

        }
    }

    public void CreateCube()
    {
        GameObject obj = Instantiate(cube);
        obj.transform.position = new Vector3(0.0f, 0, 0f);
        obj.transform.localScale = new Vector3(1, 1, -1f);
        Box b = new Box();
        b.s = new Vector3(1, 1, 1);
        b.visual = obj;
        float xpos = s.size.x / 2;
        float ypos = s.size.y / 2;


        b.p = new Vector3(-xpos, -ypos, 0);
        d.seg.box.Add(b);
        
    }

    public void SelectCube()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(maincamera.transform.position, ray.direction * 100f, Color.red, 2);
            Box b = null;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                Transform objectHit = hit.transform;

                for (int i = 0; i < d.seg.box.Count; i++)
                {
                    if (d.seg.box[i].visual == objectHit.gameObject)
                    {
                        b = d.seg.box[i];
                    }
                }
            }
            Debug.Log(b);
            selectedBox = b;
            if (selectedBox != null)
            {
                scaleUIX.text = b.s.x + "";
                scaleUIY.text = b.s.y + "";
                scaleUIZ.text = b.s.z + "";
            }
            if (b == null)
            {
                selectionBox.transform.position = new Vector3(-1000, 0, -1000);
            }
        }
    }

    public void MoveCubeInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
        {
            MoveCube(new Vector3(0, snapPrecision, 0));
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            MoveCube(new Vector3(0, -snapPrecision, 0));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            MoveCube(new Vector3(0, 0, snapPrecision));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveCube(new Vector3(0, 0, -snapPrecision));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveCube(new Vector3(-snapPrecision, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveCube(new Vector3(snapPrecision, 0, 0));
        }
        
    }

    public void MoveCube(Vector3 offset)
    {
        selectedBox.visual.transform.position += offset;
        selectedBox.p += offset;
    }

    public void SetScale()
    {
        if (scaleUIX.text == "" || scaleUIY.text == "" || scaleUIZ.text == "")
        {
            return;
        }
        selectedBox.s = new Vector3(float.Parse(scaleUIX.text), float.Parse(scaleUIY.text), float.Parse(scaleUIZ.text));
        selectedBox.visual.transform.localScale = new Vector3(float.Parse(scaleUIX.text), float.Parse(scaleUIY.text), -float.Parse(scaleUIZ.text));
    }
}

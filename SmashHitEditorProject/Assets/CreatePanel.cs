using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePanel : MonoBehaviour
{
    bool up = true;
    Vector2 movePos = new Vector2(200,10);
    public RectTransform panel;
    public void Move()
    {
        if (up == true)
        {
            movePos = new Vector2(panel.position.x, panel.position.y + 330);
            up = false;
        }
        else if (up == false)
        {
            movePos = new Vector2(panel.position.x, panel.position.y - 330);
            up = true;
        }
    }
    private void Update()
    {
        panel.position = Vector3.MoveTowards(panel.position, new Vector3(movePos.x, movePos.y, 0),2);
    }
}

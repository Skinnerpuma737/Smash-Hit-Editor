using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceIcon : MonoBehaviour
{
    public GameObject icon;
    public Transform lookAt;

    private void FixedUpdate()
    {
        icon.transform.LookAt(-lookAt.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public void Attach()
    {
        GameObject mockCamera = GameObject.Find("MouseProvider Camera");
        this.transform.SetParent(mockCamera.transform);
    }

}

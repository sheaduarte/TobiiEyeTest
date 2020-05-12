using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputController : MonoBehaviour
{
    public GameObject rightCube;
    public GameObject leftCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            rightCube.SetActive(false);
        }
        if (Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            rightCube.SetActive(true);
        }
        if (Input.GetButtonDown("XRI_Left_TriggerButton"))
        {
            leftCube.SetActive(false);
        }
        if (Input.GetButtonUp("XRI_Left_TriggerButton"))
        {
            leftCube.SetActive(true);
        }
    }
}

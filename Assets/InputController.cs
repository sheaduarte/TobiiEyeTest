using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class InputController : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean onGUIOff;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    public UIController uiController;

    //public GameObject rightCube;
    //public GameObject leftCube;
    // Start is called before the first frame update
   void Start() {
        onGUIOff.AddOnStateDownListener(GuiOff, handType);
}
public void GuiOff(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        uiController.Hide();
        Debug.Log("Trigger Down");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetButtonDown("XRI_Right_TriggerButton"))
    //    {
    //        rightCube.SetActive(false);
    //    }
    //    if (Input.GetButtonUp("XRI_Right_TriggerButton"))
    //    {
    //        rightCube.SetActive(true);
    //    }
    //    if (Input.GetButtonDown("XRI_Left_TriggerButton"))
    //    {
    //        leftCube.SetActive(false);
    //    }
    //    if (Input.GetButtonUp("XRI_Left_TriggerButton"))
    //    {
    //        leftCube.SetActive(true);
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class SteamActionController : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean onGUIOff;
    public SteamVR_Action_Boolean onTrackClick;
    public SteamVR_Action_Boolean onTrackTouch;
    public SteamVR_Action_Vector2 onTrackPosition;
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

    public void GetTrackPadAxis(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        Debug.Log("trackpad " + axis.x);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class ViveGUIController : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean onGUIOff;
    public SteamVR_Action_Boolean onTrackClick;
    public SteamVR_Action_Boolean onTrackTouch;
    public SteamVR_Action_Vector2 onTrackPosition;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    public UIController uiController;

    public SliderController sliderController;

    public float trackPadSensitivity;

    public TaskEvent decreaseSliderDistance;
    public TaskEvent increaseSliderDistance;

    private bool _isTrackPadPressed = false;
    //public GameObject rightCube;
    //public GameObject leftCube;
    // Start is called before the first frame update
    void Start()
    {
        onGUIOff.AddOnStateDownListener(GuiOff, handType);

        onTrackClick.AddOnStateDownListener(TrackPadDown, handType);
        onTrackClick.AddOnStateUpListener(TrackPadUp, handType);

        onTrackTouch.AddOnStateDownListener(TrackPadTouch, handType);
    }

    public void GuiOff(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        uiController.Hide();
        Debug.Log("Trigger Down");
    }

    public void TrackPadDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("TrackPad Down");

        //Vector2 trackPosition = onTrackPosition.GetAxis(SteamVR_Input_Sources.Any);

        //if (trackPosition.x < 0)
        //{
        //    decreaseSliderDistance.Raise();
        //}
        //else if (trackPosition.x > 0)
        //{
        //    increaseSliderDistance.Raise();
        //}

        if (!_isTrackPadPressed)
        {
            StartCoroutine(StartSliderController());
        }
    }

    public void TrackPadUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("TrackPad Up");

       // _isTrackPadPressed = false;
        StopCoroutine(StartSliderController());
    }

    public void TrackPadTouch(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("TrackPad Touch");
    }

    float period = .5f;

   

            //Vector2 trackPosition = GetTouchPadValue();
            //sliderController.ChangeDistance(trackPosition.x * trackPadSensitivity);
      

        IEnumerator StartSliderController()
        {

            float nextActionTime = Time.time + period;
           // _isTrackPadPressed = true;

            Debug.Log("Start time: " + Time.time);

            while (true)
            {
                Debug.Log("Current: " + Time.time);
                Debug.Log("Next: " + nextActionTime);
                if (Time.time > nextActionTime)
                {
                    Debug.Log("Action triggered");

                    nextActionTime += period;

                    Vector2 trackPosition = onTrackPosition.GetAxis(SteamVR_Input_Sources.Any);

                    if (trackPosition.x < 0)
                    {
                        decreaseSliderDistance.Raise();
                    }
                    else if (trackPosition.x > 0)
                    {
                        increaseSliderDistance.Raise();
                    }
                }

                //if (Time.time > endTime)
                //{
                //    _isTrackPadPressed = false;
                //    break;
                //}
                yield return null;
            }

        }
}

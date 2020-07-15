using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

namespace EyeTest
{
    public class ViveController : MonoBehaviour
    {
        public SteamVR_Action_Boolean onGUIOff;
        public SteamVR_Action_Boolean onTrackClick;
        public SteamVR_Action_Boolean onTrackTouch;
        public SteamVR_Action_Vector2 onTrackPosition;
        public SteamVR_Input_Sources handType;

        public float trackPadSensitivity;

        public TaskEvent decreaseSliderDistance;
        public TaskEvent increaseSliderDistance;
        public TaskEvent startSlider;
        public TaskEvent stopSlider;

        float period = .5f;
        private bool _isTrackPadPressed = false;


        void Start()
        {
            onGUIOff.AddOnStateDownListener(GuiOff, handType);
            onTrackClick.AddOnStateDownListener(TrackPadDown, handType);
            onTrackClick.AddOnStateUpListener(TrackPadUp, handType);
            onTrackTouch.AddOnStateDownListener(TrackPadTouch, handType);
        }


        void RaiseStartSlider()
        {
            startSlider.Raise();
        }

        void RaiseStopSlider()
        {
            stopSlider.Raise();
        }


        public void GuiOff(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Debug.Log("Trigger Down");
        }

        public void TrackPadDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            RaiseStartSlider();
            Debug.Log("TrackPad Down");

        }

        public void TrackPadUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            RaiseStopSlider();
            Debug.Log("TrackPad Up");
        }

        public void TrackPadTouch(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Debug.Log("TrackPad Touch");
        }

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
                yield return null;
            }

        }
    } 
}

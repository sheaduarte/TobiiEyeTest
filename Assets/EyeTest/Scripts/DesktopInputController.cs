using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EyeTest
{
    public class DesktopInputController : MonoBehaviour
    {
        public TaskEvent decreaseSliderDistance;
        public TaskEvent increaseSliderDistance;
        public TaskEvent setSliderValue;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                increaseSliderDistance.Raise();

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                decreaseSliderDistance.Raise();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                setSliderValue.Raise();
            }

        }
    } 
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EyeTest
{
    public class SliderController : MonoBehaviour
    {
        public float distance;
        public float sensitivity;
        public GuiTextController guiTextController;
        public TaskEvent decreaseSliderDistance;
        public TaskEvent increaseSliderDistance;
        public TaskEvent setSliderValue;

        public int minValue, maxValue;
        public Slider slider;


        private void OnEnable()
        {
            decreaseSliderDistance.Register(DecreaseDistance);
            increaseSliderDistance.Register(IncreaseDistance);
            setSliderValue.Register(SliderValueSet);
        }

        private void OnDisable()
        {
            decreaseSliderDistance.Deregister(DecreaseDistance);
            increaseSliderDistance.Deregister(IncreaseDistance);
        }
        // Start is called before the first frame update
        void Start()
        {
            guiTextController.SetText(distance.ToString());
            guiTextController.Show();
        }

        public float GetSliderValue()
        {
            return slider.value;
        }

        public void DecreaseDistance()
        {
            Debug.Log("slider decrease distance");
            distance = distance - (1 * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            slider.value = distance;
        }

        public void IncreaseDistance()
        {
            Debug.Log("slider increase distance");
            distance = distance + (1 * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            slider.value = distance;
        }

        public void ChangeDistance(float inputDistance)
        {
            Debug.Log("slider decrease distance");
            distance = distance + (inputDistance * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            slider.value = distance;
        }

        public void SliderValueSet()
        {

        }

    }
}

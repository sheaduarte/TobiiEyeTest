using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EyeTest
{
    public class SliderHandler : Singleton<SliderHandler>
    {
        public float distance;
        public float sensitivity;
        public GuiTextController guiTextController;
        public TaskEvent decreaseSliderDistance;
        public TaskEvent increaseSliderDistance;
        public TaskEvent setSliderValue;

        public int minValue, maxValue;
        public GuiSliderController guiSliderController;


        private void OnEnable()
        {
            guiTextController.Show();
            guiSliderController.Show();

            guiTextController.SetText(distance.ToString());

            decreaseSliderDistance.Register(DecreaseDistance);
            increaseSliderDistance.Register(IncreaseDistance);
            setSliderValue.Register(SliderValueSet);
        }

        private void OnDisable()
        {
            guiTextController.Hide();
            guiSliderController.Hide();

            decreaseSliderDistance.Deregister(DecreaseDistance);
            increaseSliderDistance.Deregister(IncreaseDistance);
            setSliderValue.Deregister(SliderValueSet);
        }

        public float GetSliderValue()
        {
            return guiSliderController.slider.value;
        }

        public void DecreaseDistance()
        {
            Debug.Log("slider decrease distance");
            distance = distance - (1 * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            guiSliderController.slider.value = distance;
        }

        public void IncreaseDistance()
        {
            Debug.Log("slider increase distance");
            distance = distance + (1 * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            guiSliderController.slider.value = distance;
        }

        public void ChangeDistance(float inputDistance)
        {
            Debug.Log("slider decrease distance");
            distance = distance + (inputDistance * sensitivity);
            distance = Mathf.Clamp(distance, minValue, maxValue);
            guiTextController.SetText(distance.ToString());
            guiSliderController.slider.value = distance;
        }

        public void MoveSliderInView()
        {
            
        }

        public void SliderValueSet()
        {
            enabled = false;
        }

    }
}

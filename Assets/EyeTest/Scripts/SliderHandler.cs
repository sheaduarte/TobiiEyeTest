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
        public Transform head;

        private Vector3 _headPositionDifference;
        public bool sliderShowing = false;

        private void Start()
        {
            _headPositionDifference = head.position - transform.position;
        }

        public void Show()
        {
            sliderShowing = true;


            Vector3 playerPos = head.transform.position;
            Vector3 playerDirection = head.transform.forward;
            playerDirection.y = 0;
            Quaternion playerRotation = head.transform.rotation;
            float spawnDistance = 10;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            transform.position = spawnPos;


            Vector3 v = head.transform.position - transform.position;
            v.x = v.z = 0.0f;
            transform.LookAt(head.transform.position - v);
            transform.Rotate(0, 180, 0);

            guiTextController.Show();
            guiSliderController.Show();

            guiTextController.SetText(distance.ToString());

            decreaseSliderDistance.Register(DecreaseDistance);
            increaseSliderDistance.Register(IncreaseDistance);
            setSliderValue.Register(Hide);

        }

        private void Hide()
        {
            Debug.Log("Hide Slider");
            sliderShowing = false;

            guiTextController.Hide();
            guiSliderController.Hide();

            decreaseSliderDistance.Deregister(DecreaseDistance);
            increaseSliderDistance.Deregister(IncreaseDistance);
            setSliderValue.Deregister(Hide);
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

    }
}

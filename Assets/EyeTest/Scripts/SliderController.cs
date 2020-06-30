using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public float distance;
    public float sensitivity;
    public UIController uiController;
    public TaskEvent decreaseSliderDistance;
    public TaskEvent increaseSliderDistance;
    public int minValue, maxValue;
    public Slider slider;
  

    private void OnEnable()
    {
        decreaseSliderDistance.Register(DecreaseDistance);
        increaseSliderDistance.Register(IncreaseDistance);
    }

    private void OnDisable()
    {
        decreaseSliderDistance.Deregister(DecreaseDistance);
        increaseSliderDistance.Deregister(IncreaseDistance);
    }
    // Start is called before the first frame update
    void Start()
    {
        uiController.SetText(distance.ToString());
        uiController.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        uiController.SetText(distance.ToString());
        slider.value = distance;
    }

    public void IncreaseDistance()
    {
        Debug.Log("slider increase distance");
        distance = distance + (1 * sensitivity);
        distance = Mathf.Clamp(distance, minValue, maxValue);
        uiController.SetText(distance.ToString());
        slider.value = distance;
    }

    public void ChangeDistance(float inputDistance)
    {
        Debug.Log("slider decrease distance");
        distance = distance + (inputDistance * sensitivity);
        distance = Mathf.Clamp(distance, minValue, maxValue);
        uiController.SetText(distance.ToString());
        slider.value = distance;
    }

}

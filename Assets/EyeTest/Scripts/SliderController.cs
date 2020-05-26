using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public float distance;
    public float sensitivity;
    public UIController uiController;
    public TaskEvent decreaseSliderDistance;
    public TaskEvent increaseSliderDistance;

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

    public void DecreaseDistance()
    {
        Debug.Log("slider decrease distance");
        distance = distance - (1 * sensitivity);
        uiController.SetText(distance.ToString());
    }

    public void IncreaseDistance()
    {
        Debug.Log("slider increase distance");
        distance = distance + (1 * sensitivity);
        uiController.SetText(distance.ToString());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public float distance;
    public float sensitivity;
    public UIController uiController;

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
        distance = distance - (1 * sensitivity);
    }

    public void IncreaseDistance()
    {
        distance = distance + (1 * sensitivity);
    }
}

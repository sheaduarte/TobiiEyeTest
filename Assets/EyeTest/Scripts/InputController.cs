using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public TaskEvent decreaseSliderDistance;
    public TaskEvent increaseSliderDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            increaseSliderDistance.Raise();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            decreaseSliderDistance.Raise();
    }
}

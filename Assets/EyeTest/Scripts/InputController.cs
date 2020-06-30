using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public TaskEvent decreaseSliderDistance;
    public TaskEvent increaseSliderDistance;
    public TaskEvent logDataRow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up arrow down.");
            increaseSliderDistance.Raise();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down arrow down.");

            decreaseSliderDistance.Raise();

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Down arrow down.");

            logDataRow.Raise();

        }
    }
}

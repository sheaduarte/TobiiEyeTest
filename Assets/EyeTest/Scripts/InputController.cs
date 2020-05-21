using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public TaskEvents taskevents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            taskevents.IncreaseDistance();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            taskevents.DecreaseDistance();
    }
}

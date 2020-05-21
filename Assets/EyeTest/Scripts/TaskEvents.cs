using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskEvents : MonoBehaviour
{
    public Action onIncreaseDistance;
    public Action onDecreaseDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseDistance()
    {
        Debug.Log("increase distance");
        if (onIncreaseDistance != null)
            onIncreaseDistance();
    }

    public void DecreaseDistance()
    {
        Debug.Log("decrease distance");
        if (onDecreaseDistance != null)
            onDecreaseDistance();
    }
}

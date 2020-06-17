using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Settings : MonoBehaviour
{
    public bool vrOn;
    private void Awake()
    {
        XRSettings.enabled = vrOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

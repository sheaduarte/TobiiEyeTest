using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


namespace EyeTest
{
    public class Settings : MonoBehaviour
    {
        public bool vrOn;

        private void Awake()
        {
            XRSettings.enabled = vrOn;
        }
    } 
}

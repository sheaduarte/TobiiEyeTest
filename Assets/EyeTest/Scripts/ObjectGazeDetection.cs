using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tobii.G2OM;

public class ObjectGazeDetection : MonoBehaviour, IGazeFocusable
{
    public Action onNewGazeDetected;

    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            if (onNewGazeDetected != null)
            {
                onNewGazeDetected();
            }

            GazeObjectController.Instance.SetGazeObject(gameObject);
        }
        else
        {
            GazeObjectController.Instance.SetGazeObject(null);

        }
    }
}

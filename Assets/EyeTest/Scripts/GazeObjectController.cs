using System.Collections;
using System.Collections.Generic;
using EyeTest;
using UnityEngine;
using Sirenix.OdinInspector;

public class GazeObjectController : Singleton<GazeObjectController>
{
    [ReadOnly]
    public GameObject gazeObject = null;

    public string GetGazeObjectName()
    {
        return gazeObject != null ? gazeObject.name : "";
    }

    public Vector3 GetGazeObjectPosition()
    {
        return gazeObject != null ? gazeObject.transform.position : Vector3.zero;
    }

    public void SetGazeObject(GameObject newGazeObject)
    {
        gazeObject = newGazeObject;
    }
}

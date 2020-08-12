using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimenterUIManager : MonoBehaviour
{
    public Button attachTobiiDevButton;
    public GameObject tobiiDevTools;

    void Start()
    {
        attachTobiiDevButton.onClick.AddListener(AttachDevToolToCamera);
    }

    public void AttachDevToolToCamera()
    {
        GameObject mockCamera = GameObject.Find("MouseProvider Camera");
        tobiiDevTools.transform.SetParent(mockCamera.transform);
    }
}

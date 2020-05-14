using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;


public class GUIonGaze : MonoBehaviour, IGazeFocusable
{
    public UIController uiController;
    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            uiController.Show();
        }
    }
}

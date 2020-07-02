using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiSliderController : MonoBehaviour

{
    public GameObject canvas;
    public Slider slider;

    private void Start()
    {
    }
    public void Show() 
    {
        canvas.SetActive(true);
    }
    public void Hide()
    {
        canvas.SetActive(false);
    }
}

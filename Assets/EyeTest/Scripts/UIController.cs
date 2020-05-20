using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour

{
    public GameObject canvas;
    public TextMeshProUGUI textbox;

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

    public void SetText(string newtext)
    {
        textbox.text = newtext;
    }


}

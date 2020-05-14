using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour

{
    public GameObject canvas;
    public string message;
    public TextMeshProUGUI textbox;

    private void Start()
    {
        textbox.text = message;
        Hide();
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

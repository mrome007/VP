using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VPButton : MonoBehaviour
{
    public Action ButtonPressed;

    protected Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PostButtonPressed);
    }

    protected void PostButtonPressed()
    {
        if(ButtonPressed != null)
        {
            ButtonPressed.Invoke();
        }
    }

    public virtual void UpdateButton()
    {
    }
}

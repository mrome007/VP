using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Video Poker Button.
/// </summary>
[RequireComponent(typeof(Button))]
public class VPButton : MonoBehaviour
{
    /// <summary>
    /// Button Pressed Action.
    /// </summary>
    public Action ButtonPressed;

    /// <summary>
    /// UI Button.
    /// </summary>
    protected Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PostButtonPressed);
    }

    /// <summary>
    /// Posts the button pressed action.
    /// </summary>
    protected void PostButtonPressed()
    {
        if(ButtonPressed != null)
        {
            ButtonPressed.Invoke();
        }
    }

    /// <summary>
    /// Updates the button.
    /// </summary>
    public virtual void UpdateButton()
    {
    }

    /// <summary>
    /// Enables the button.
    /// </summary>
    /// <param name="enable">If set to <c>true</c> enable.</param>
    public virtual void EnableButton(bool enable)
    {
        button.interactable = enable;
    }
}

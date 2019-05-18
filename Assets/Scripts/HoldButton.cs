using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : VPButton
{
    [SerializeField]
    private int buttonIndex;

    [SerializeField]
    private bool held;

    [SerializeField]
    private GameObject holdText;

    public int HoldIndex { get { return buttonIndex; } }
    public bool Held { get { return held; } }

    public void RegisterHoldButton()
    {
        held = false;
        holdText.SetActive(false);
        button.onClick.AddListener(ToggleHoldButton);
    }

    public void UnRegisterHoldButton()
    {
        held = false;
        holdText.SetActive(false);
        button.onClick.RemoveListener(ToggleHoldButton);
    }

    private void ToggleHoldButton()
    {
        held = !held;
        holdText.SetActive(held);
    }
}

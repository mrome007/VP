using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button that holds cards.
/// </summary>
public class HoldButton : VPButton
{
    /// <summary>
    /// Button index.
    /// </summary>
    [SerializeField]
    private int buttonIndex;

    /// <summary>
    /// Held flag indicating whether this
    /// button is held.
    /// </summary>
    [SerializeField]
    private bool held;

    /// <summary>
    /// Hold text.
    /// </summary>
    [SerializeField]
    private GameObject holdText;

    /// <summary>
    /// Card button.
    /// </summary>
    [SerializeField]
    private Button cardButton;

    /// <summary>
    /// Gets the index of the button.
    /// </summary>
    /// <value>button index</value>
    public int HoldIndex { get { return buttonIndex; } }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:HoldButton"/> is held.
    /// </summary>
    /// <value><c>true</c> if held; otherwise, <c>false</c>.</value>
    public bool Held { get { return held; } }

    /// <summary>
    /// Registers hold button events.
    /// </summary>
    public void RegisterHoldButton()
    {
        held = false;
        holdText.SetActive(false);
        button.onClick.AddListener(ToggleHoldButton);
        cardButton.onClick.AddListener(ToggleHoldButton);
    }

    /// <summary>
    /// Unregisters hold button events.
    /// </summary>
    public void UnRegisterHoldButton()
    {
        held = false;
        holdText.SetActive(false);
        button.onClick.RemoveListener(ToggleHoldButton);
        cardButton.onClick.RemoveListener(ToggleHoldButton);
    }

    /// <summary>
    /// Toggles the hold button.
    /// </summary>
    private void ToggleHoldButton()
    {
        held = !held;
        holdText.SetActive(held);
    }

    /// <inheritdoc />
    public override void EnableButton(bool enable)
    {
        base.EnableButton(enable);
        cardButton.interactable = enable;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hold buttons container.
/// </summary>
public class HoldButtons : MonoBehaviour
{
    /// <summary>
    /// The hold buttons.
    /// </summary>
    [SerializeField]
    private List<HoldButton> holdButtons;

    /// <summary>
    /// Enables the hold buttons.
    /// </summary>
    /// <param name="enable">If set to <c>true</c> enable.</param>
    public void EnableButtons(bool enable)
    {
        holdButtons.ForEach(button => button.EnableButton(enable));
    }

    /// <summary>
    /// Registers all hold buttons events.
    /// </summary>
    public void RegisterHoldButtons()
    {
        holdButtons.ForEach(holdButton => holdButton.RegisterHoldButton());
    }

    /// <summary>
    /// Unregisters all hold buttons events.
    /// </summary>
    public void UnRegisterHoldButtons()
    {
        holdButtons.ForEach(holdButton => holdButton.UnRegisterHoldButton());
    }

    /// <summary>
    /// Gets the held flag for all hold buttons.
    /// </summary>
    /// <returns>List of all held flags.</returns>
    public List<bool> GetHeld()
    {
        var held = new List<bool>();
        for(var index = 0; index < holdButtons.Count; index++)
        {
            held.Add(holdButtons[index].Held);
        }
        return held;
    }
}

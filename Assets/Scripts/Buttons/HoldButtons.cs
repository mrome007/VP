using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButtons : MonoBehaviour
{
    [SerializeField]
    private List<HoldButton> holdButtons;

    public void RegisterHoldButtons()
    {
        holdButtons.ForEach(holdButton => holdButton.RegisterHoldButton());
    }

    public void UnRegisterHoldButtons()
    {
        holdButtons.ForEach(holdButton => holdButton.UnRegisterHoldButton());
    }

    public List<bool> GetHeld()
    {
        var held = new List<bool>();
        for (var index = 0; index < holdButtons.Count; index++)
        {
            held.Add(holdButtons[index].Held);
        }
        return held;
    }
}

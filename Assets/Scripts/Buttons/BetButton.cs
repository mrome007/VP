using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Bet button class.
/// </summary>
public class BetButton : VPButton
{
    /// <summary>
    /// Bet meter. Holds information regarding the
    /// current bet.
    /// </summary>
    [SerializeField]
    private Meter betMeter;

    /// <summary>
    /// Bet Value text.
    /// </summary>
    [SerializeField]
    private Text betValueText;

    /// <inheritdoc/>
    public override void UpdateButton()
    {
        betValueText.text = betMeter.MeterValue.ToString();
    }
}

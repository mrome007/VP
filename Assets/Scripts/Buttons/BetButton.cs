using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : VPButton
{
    [SerializeField]
    private Meter betMeter;

    [SerializeField]
    private Text betValueText;

    public override void UpdateButton()
    {
        betValueText.text = betMeter.MeterValue.ToString();
    }
}

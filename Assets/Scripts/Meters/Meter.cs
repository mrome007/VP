using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField]
    private int meterValue;

    [SerializeField]
    private Text meterValueText;

    public int MeterValue { get { return meterValue; } }

    private void Awake()
    {
        UpdateMeterValue(meterValue);
    }

    public void UpdateMeterValue(int value)
    {
        meterValue = value;
        meterValueText.text = value.ToString();
    }
}

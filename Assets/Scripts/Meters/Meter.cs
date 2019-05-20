using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField]
    private Text meterValueText;

    public int MeterValue { get; private set; }

    private void Awake()
    {
        UpdateMeterValue(MeterValue);
    }

    public void UpdateMeterValue(int value)
    {
        MeterValue = value;
        meterValueText.text = value.ToString();
    }
}

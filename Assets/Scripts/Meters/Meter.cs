using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Meter.
/// </summary>
public class Meter : MonoBehaviour
{
    /// <summary>
    /// The meter value text.
    /// </summary>
    [SerializeField]
    private Text meterValueText;

    /// <summary>
    /// Gets the meter value.
    /// </summary>
    /// <value>The meter value.</value>
    public int MeterValue { get; private set; }

    private void Awake()
    {
        UpdateMeterValue(MeterValue);
    }

    /// <summary>
    /// Updates the meter value.
    /// </summary>
    /// <param name="value">Value.</param>
    public void UpdateMeterValue(int value)
    {
        MeterValue = value;
        meterValueText.text = value.ToString();
    }
}

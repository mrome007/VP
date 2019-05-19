using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetersController : MonoBehaviour
{
    [SerializeField]
    private Meter betMeter;

    [SerializeField]
    private Meter winMeter;

    [SerializeField]
    private Meter creditMeter;

    private int currentCredits = 100000;
    private int currentBet = 1;
    private int maxBet = 5;

    public int BetValue { get { return betMeter.MeterValue; } }
    public int WinValue { get { return winMeter.MeterValue; } }
    public int CreditValue { get { return creditMeter.MeterValue; } }

    public void InitializeMeters()
    {
        betMeter.UpdateMeterValue(currentBet);
        winMeter.UpdateMeterValue(0);
        creditMeter.UpdateMeterValue(currentCredits);
    }

    public void CycleBet()
    {
        currentBet++;
        currentBet %= maxBet;
        if(currentBet == 0)
        {
            currentBet = maxBet;
        }

        betMeter.UpdateMeterValue(currentBet);
    }

    public bool CanBet()
    {
        var creditsAfterBet = currentCredits - currentBet;
        return creditsAfterBet >= 0;
    }

    public void BetGame()
    {
        if(!CanBet())
        {
            return;
        }

        currentCredits -= currentBet;
        creditMeter.UpdateMeterValue(currentCredits);
    }
}

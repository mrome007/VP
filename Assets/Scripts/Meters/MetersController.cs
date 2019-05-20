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

    [SerializeField]
    private PaytableSelection paytableSelection;

    private const int initalCredits = 100000;
    private const int maxBet = 5;

    private readonly List<int> basePrizeAmounts = new List<int>()
    {
        1,
        2,
        3,
        4,
        6,
        9,
        25,
        50,
        800
    };

    private void Awake()
    {
        InitializeMeters();
    }

    public void InitializeMeters()
    {
        betMeter.UpdateMeterValue(1);
        winMeter.UpdateMeterValue(0);
        creditMeter.UpdateMeterValue(initalCredits);
    }

    public void CycleBet()
    {
        var currentBet = betMeter.MeterValue;
        currentBet++;
        currentBet %= maxBet;

        if(currentBet == 0)
        {
            currentBet = maxBet;
        }

        betMeter.UpdateMeterValue(currentBet);
        paytableSelection.ShowSelection(currentBet - 1, true);
    }

    public bool CanBet()
    {
        var creditsAfterBet = creditMeter.MeterValue - betMeter.MeterValue;
        return creditsAfterBet >= 0;
    }

    public void BetGame()
    {
        if(!CanBet())
        {
            return;
        }

        var currentCredits = creditMeter.MeterValue  - betMeter.MeterValue;
        creditMeter.UpdateMeterValue(currentCredits);
    }

    public void AwardPrize(WinningHandCategory hand)
    {
        if(hand == WinningHandCategory.Other)
        {
            return;
        }

        var prizeIndex = (int)hand - 1;
        var win = betMeter.MeterValue * basePrizeAmounts[prizeIndex];
        var currentCredits = creditMeter.MeterValue;
        currentCredits += win;

        creditMeter.UpdateMeterValue(currentCredits);
        winMeter.UpdateMeterValue(win);
    }

    public void ClearWin()
    {
        winMeter.UpdateMeterValue(0);
    }

    public void AddCredits()
    {
        var currentCredits = creditMeter.MeterValue;
        currentCredits += initalCredits;
        creditMeter.UpdateMeterValue(currentCredits);
    }

    public bool HasCredits()
    {
        return creditMeter.MeterValue != 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Meters controller.
/// </summary>
public class MetersController : MonoBehaviour
{
    /// <summary>
    /// Bet meter.
    /// </summary>
    [SerializeField]
    private Meter betMeter;

    /// <summary>
    /// Win meter.
    /// </summary>
    [SerializeField]
    private Meter winMeter;

    /// <summary>
    /// Credit meter.
    /// </summary>
    [SerializeField]
    private Meter creditMeter;

    /// <summary>
    /// Paytable selection.
    /// </summary>
    [SerializeField]
    private PaytableSelection paytableSelection;

    /// <summary>
    /// Inital credits.
    /// </summary>
    private const int initalCredits = 100000;

    /// <summary>
    /// Max bet.
    /// </summary>
    private const int maxBet = 5;

    /// <summary>
    /// Base prize amounts.
    /// </summary>
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

    /// <summary>
    /// Initializes the meters.
    /// </summary>
    public void InitializeMeters()
    {
        betMeter.UpdateMeterValue(1);
        winMeter.UpdateMeterValue(0);
        creditMeter.UpdateMeterValue(initalCredits);
    }

    /// <summary>
    /// Cycles the bet.
    /// </summary>
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

    /// <summary>
    /// Check if there's enough credits to bet.
    /// </summary>
    /// <returns><c>true</c>, if can bet, <c>false</c> otherwise.</returns>
    public bool CanBet()
    {
        var creditsAfterBet = creditMeter.MeterValue - betMeter.MeterValue;
        return creditsAfterBet >= 0;
    }

    /// <summary>
    /// Bets the game.
    /// </summary>
    public void BetGame()
    {
        if(!CanBet())
        {
            return;
        }

        var currentCredits = creditMeter.MeterValue  - betMeter.MeterValue;
        creditMeter.UpdateMeterValue(currentCredits);
    }

    /// <summary>
    /// Awards the prize.
    /// </summary>
    /// <param name="hand">Hand.</param>
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

    /// <summary>
    /// Clears the win.
    /// </summary>
    public void ClearWin()
    {
        winMeter.UpdateMeterValue(0);
    }

    /// <summary>
    /// Adds credits.
    /// </summary>
    public void AddCredits()
    {
        var currentCredits = creditMeter.MeterValue;
        currentCredits += initalCredits;
        creditMeter.UpdateMeterValue(currentCredits);
    }

    /// <summary>
    /// Checks if there are credits
    /// </summary>
    /// <returns><c>true</c>, if there are credits, <c>false</c> otherwise.</returns>
    public bool HasCredits()
    {
        return creditMeter.MeterValue != 0;
    }
}

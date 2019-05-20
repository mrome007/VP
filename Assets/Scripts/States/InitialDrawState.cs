using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initial draw presentation state.
/// </summary>
public class InitialDrawState : PresentationState
{
    /// <summary>
    /// Deck
    /// </summary>
    [SerializeField]
    private Deck deck;

    /// <summary>
    /// Hand
    /// </summary>
    [SerializeField]
    private Hand hand;

    /// <summary>
    /// Hold buttons
    /// </summary>
    [SerializeField]
    private HoldButtons holdButtons;

    /// <summary>
    /// Deal button
    /// </summary>
    [SerializeField]
    private VPButton dealButton;

    /// <summary>
    /// Bet button
    /// </summary>
    [SerializeField]
    private VPButton betButton;

    /// <summary>
    /// Meters controller
    /// </summary>
    [SerializeField]
    private MetersController metersController;

    /// <summary>
    /// Messages controller
    /// </summary>
    [SerializeField]
    private MessagesController messagesController;

    /// <inheritdoc />
    public override void EnterState()
    {
        base.EnterState();

        if(!metersController.HasCredits())
        {
            metersController.AddCredits();
        }

        EnableButtonsForInitialDraw();
    }

    /// <inheritdoc />
    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        dealButton.ButtonPressed += HandleDealButtonPressed;
        betButton.ButtonPressed += HandleBetButtonPressed;
    }

    /// <inheritdoc />
    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        dealButton.ButtonPressed -= HandleDealButtonPressed;
        betButton.ButtonPressed -= HandleBetButtonPressed;
    }

    /// <summary>
    /// Handler when deal button is pressed.
    /// </summary>
    private void HandleDealButtonPressed()
    {
        if(!metersController.CanBet())
        {
            return; 
        }

        UnRegisterEvents();
        messagesController.ShowMessages(false);
        metersController.ClearWin();
        metersController.BetGame();
        DealCards();
        ExitState();
    }

    /// <summary>
    /// Handler when bet button is pressed.
    /// </summary>
    private void HandleBetButtonPressed()
    {
        hand.ReturnAllCards();
        messagesController.ShowMessages(false);
        metersController.ClearWin();
        metersController.CycleBet();
        betButton.UpdateButton();
    }

    /// <summary>
    /// Deals the cards.
    /// </summary>
    private void DealCards()
    {
        hand.ReturnAllCards();
        deck.Shuffle();

        for(var count = 0; count < Hand.NumberOfCardsInHand; count++)
        {
            var card = deck.DealCard();
            hand.AddCard(card);
        }
    }

    /// <summary>
    /// Enables the buttons for initial draw.
    /// </summary>
    private void EnableButtonsForInitialDraw()
    {
        betButton.EnableButton(true);
        dealButton.EnableButton(true);
        holdButtons.EnableButtons(false);
    }
}

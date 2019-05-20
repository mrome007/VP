using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDrawState : PresentationState
{
    [SerializeField]
    private Deck deck;

    [SerializeField]
    private Hand hand;

    [SerializeField]
    private HoldButtons holdButtons;

    [SerializeField]
    private VPButton dealButton;

    [SerializeField]
    private VPButton betButton;

    [SerializeField]
    private MetersController metersController;

    [SerializeField]
    private MessagesController messagesController;

    public override void EnterState()
    {
        base.EnterState();

        if(!metersController.HasCredits())
        {
            metersController.AddCredits();
        }

        EnableButtonsForInitialDraw();
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        dealButton.ButtonPressed += HandleDealButtonPressed;
        betButton.ButtonPressed += HandleBetButtonPressed;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        dealButton.ButtonPressed -= HandleDealButtonPressed;
        betButton.ButtonPressed -= HandleBetButtonPressed;
    }

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

    private void HandleBetButtonPressed()
    {
        hand.ReturnAllCards();
        messagesController.ShowMessages(false);
        metersController.ClearWin();
        metersController.CycleBet();
        betButton.UpdateButton();
    }

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

    private void EnableButtonsForInitialDraw()
    {
        betButton.EnableButton(true);
        dealButton.EnableButton(true);
        holdButtons.EnableButtons(false);
    }
}

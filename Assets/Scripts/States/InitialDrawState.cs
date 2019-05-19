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
    private VPButton dealButton;

    [SerializeField]
    private VPButton betButton;

    [SerializeField]
    private MetersController metersController;

    [SerializeField]
    private MessagesController messagesController;

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
        metersController.BetGame();
        DealCards();
        ExitState();
    }

    private void HandleBetButtonPressed()
    {
        hand.ReturnAllCards();
        messagesController.ShowMessages(false);
        metersController.CycleBet();
        betButton.UpdateButton();
    }

    private void DealCards()
    {
        hand.ReturnAllCards();
        deck.Shuffle();

        for (var count = 0; count < 5; count++)
        {
            var card = deck.DealCard();
            hand.AddCard(card);
        }
    }
}

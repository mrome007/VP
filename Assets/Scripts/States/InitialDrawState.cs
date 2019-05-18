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

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        dealButton.ButtonPressed += HandleDealButtonPressed;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        dealButton.ButtonPressed -= HandleDealButtonPressed;
    }

    private void HandleDealButtonPressed()
    {
        UnRegisterEvents();
        DealCards();
        ExitState();
    }

    private void DealCards()
    {
        deck.Shuffle();

        for (var count = 0; count < 5; count++)
        {
            var card = deck.DealCard();
            hand.AddCard(card);
        }
    }
}

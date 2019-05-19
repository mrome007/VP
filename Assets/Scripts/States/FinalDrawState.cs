using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDrawState : PresentationState
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

        betButton.EnableButton(false);
        dealButton.EnableButton(true);
        holdButtons.EnableButtons(true);
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        holdButtons.RegisterHoldButtons();
        dealButton.ButtonPressed += HandleDealButtonPressed;
    }

    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        holdButtons.UnRegisterHoldButtons();
        dealButton.ButtonPressed -= HandleDealButtonPressed;
    }

    private void HandleDealButtonPressed()
    {
        DealNewCards();
        UnRegisterEvents();
        ExitState();
    }

    private void DealNewCards()
    {
        var held = holdButtons.GetHeld();
        for(var index = 0; index < held.Count; index++)
        {
            if(held[index])
            {
                continue;
            }

            var card = deck.DealCard();
            hand.AddCard(card, index);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Final draw presentation state.
/// </summary>
public class FinalDrawState : PresentationState
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
        EnableButtonsForFinalDraw();
        ShowCurrentWinningHandMessage();
    }

    /// <inheritdoc />
    protected override void RegisterEvents()
    {
        base.RegisterEvents();
        holdButtons.RegisterHoldButtons();
        dealButton.ButtonPressed += HandleDealButtonPressed;
    }

    /// <inheritdoc />
    protected override void UnRegisterEvents()
    {
        base.UnRegisterEvents();
        holdButtons.UnRegisterHoldButtons();
        dealButton.ButtonPressed -= HandleDealButtonPressed;
    }

    /// <summary>
    /// Handler when deal button is pressed.
    /// </summary>
    private void HandleDealButtonPressed()
    {
        DealNewCards();
        ShowFinalHandMessage();
        var currentHand = hand.ScoreHand();
        metersController.AwardPrize(currentHand);
        UnRegisterEvents();
        ExitState();
    }

    /// <summary>
    /// Deals new cards.
    /// </summary>
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

    /// <summary>
    /// Shows the current winning hand message.
    /// </summary>
    private void ShowCurrentWinningHandMessage()
    {
        var currentHand = hand.ScoreHand();
        if(currentHand != WinningHandCategory.Other)
        {
            messagesController.UpdateWinMessage(currentHand);
            messagesController.ShowWinMessage();
        }
        else
        {
            messagesController.ShowMessages(false);
        }
    }

    /// <summary>
    /// Shows the final hand message.
    /// </summary>
    private void ShowFinalHandMessage()
    {
        var currentHand = hand.ScoreHand();
        if(currentHand != WinningHandCategory.Other)
        {
            messagesController.UpdateWinMessage(currentHand);
            messagesController.ShowWinMessage();
        }
        else
        {
            messagesController.ShowGameOverMessage();
        }
    }

    /// <summary>
    /// Enables the buttons for final draw.
    /// </summary>
    private void EnableButtonsForFinalDraw()
    {
        betButton.EnableButton(false);
        dealButton.EnableButton(true);
        holdButtons.EnableButtons(true);
    }
}

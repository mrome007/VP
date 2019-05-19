using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public const int NumberOfCardsInHand = 5;

    [SerializeField]
    private List<Transform> handTransforms;

    private List<Card> hand;
    private int currentAddIndex = 0;

    private void Awake()
    {
        InitializeHand();
        currentAddIndex = 0;
    }

    private void InitializeHand()
    {
        hand = new List<Card>();
        for(var count = 0; count < NumberOfCardsInHand; count++)
        {
            hand.Add(null);
        }
    }

    public void ReturnAllCards()
    {
        for(var count = 0; count < NumberOfCardsInHand; count++)
        {
            if(hand[count] == null)
            {
                continue;
            }

            hand[count].ReturnCard();
            hand[count] = null;
        }
    }

    public void AddCard(Card card)
    {
        hand[currentAddIndex] = card;

        card.SetCard(handTransforms[currentAddIndex]);

        currentAddIndex++;
        currentAddIndex %= NumberOfCardsInHand;
    }

    public void AddCard(Card card, int index)
    {
        if(index < 0 || index >= NumberOfCardsInHand)
        {
            return;
        }

        var previousCard = hand[index];
        if(previousCard != null)
        {
            previousCard.ReturnCard();
        }

        hand[index] = card;
        card.SetCard(handTransforms[index]);
    }

    public WinningHandCategory ScoreHand()
    {
        return WinningHand.ScoreHand(hand);
    }
}

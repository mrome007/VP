using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private int numberOfCardsInHand = 5;

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
        for(var count = 0; count < numberOfCardsInHand; count++)
        {
            hand.Add(null);
        }
    }

    public void ReturnAllCards()
    {
        foreach(var card in hand)
        {
            if(card == null)
            {
                continue;
            }

            card.ReturnCard();
        }
    }

    public void AddCard(Card card)
    {
        hand[currentAddIndex] = card;

        card.SetCard(handTransforms[currentAddIndex]);

        currentAddIndex++;
        currentAddIndex %= numberOfCardsInHand;
    }

    public void AddCard(Card card, int index)
    {
        if(index < 0 || index >= numberOfCardsInHand)
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

    public int ScoreHand()
    {
        return 0;
    }
}

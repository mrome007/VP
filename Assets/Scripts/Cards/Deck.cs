using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<Card> cards;

    private int dealtIndex = 0;

    public void Shuffle()
    {
        dealtIndex = 0;
        CardShuffle.Shuffle(cards);
    }

    public Card DealCard()
    {
        if(dealtIndex < 0 || dealtIndex >= cards.Count)
        {
            return null;
        }

        var card = cards[dealtIndex++];
        return card;
    }

    public Card[] DealHand(int numberOfCards)
    {
        if(dealtIndex + numberOfCards >= cards.Count)
        {
            return null;
        }

        var hand = new Card[numberOfCards];
        for(var count = 0; count < numberOfCards; count++)
        {
            hand[count] = cards[dealtIndex++];
        }
        return hand;
    }
}

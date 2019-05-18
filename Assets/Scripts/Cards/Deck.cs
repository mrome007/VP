using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public const int NumberOfCards = 52;

    [SerializeField]
    private List<Card> cards;

    private int dealtIndex = 0;
    private List<int> shuffleIndexes;

    public void Shuffle()
    {
        dealtIndex = 0;
        ShuffleCards();
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

    private void ShuffleCards()
    {
        PopulateShuffleIndexes();

        var endIndex = NumberOfCards - 1;
        var startIndex = 0;

        for(var count = 0; count < NumberOfCards; count++)
        {
            var currentIndex = Random.Range(startIndex, endIndex);
            var shuffleIndex = shuffleIndexes[currentIndex];

            //move shuffleIndex selected to end of shuffleIndexes list.
            shuffleIndexes[currentIndex] = shuffleIndexes[endIndex];
            shuffleIndexes[endIndex] = shuffleIndex;

            var card = cards[count];
            cards[count] = cards[shuffleIndex];
            cards[shuffleIndex] = card;

            endIndex--;
        }
    }

    private void PopulateShuffleIndexes()
    {
        if(shuffleIndexes != null)
        {
            return;
        }

        shuffleIndexes = new List<int>();
        for(var count = 0; count < NumberOfCards; count++)
        {
            shuffleIndexes.Add(count);
        }
    }
}

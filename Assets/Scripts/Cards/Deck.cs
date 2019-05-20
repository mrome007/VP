using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deck class.
/// </summary>
public class Deck : MonoBehaviour
{
    /// <summary>
    /// The number of cards per deck.
    /// </summary>
    public const int NumberOfCards = 52;

    /// <summary>
    /// Cards.
    /// </summary>
    [SerializeField]
    private List<Card> cards;

    /// <summary>
    /// Current dealt card index.
    /// </summary>
    private int dealtIndex = 0;

    /// <summary>
    /// List of indexes used for shuffling.
    /// </summary>
    private List<int> shuffleIndexes;

    /// <summary>
    /// Shuffle deck.
    /// </summary>
    public void Shuffle()
    {
        dealtIndex = 0;
        ShuffleCards();
    }

    /// <summary>
    /// Deals the card.
    /// </summary>
    /// <returns>The card.</returns>
    public Card DealCard()
    {
        if(dealtIndex < 0 || dealtIndex >= cards.Count)
        {
            return null;
        }

        var card = cards[dealtIndex++];
        return card;
    }

    /// <summary>
    /// Deals the hand.
    /// </summary>
    /// <returns>The hand.</returns>
    /// <param name="numberOfCards">Number of cards.</param>
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

    /// <summary>
    /// Shuffles the cards.
    /// </summary>
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

    /// <summary>
    /// Populates the shuffle indexes.
    /// </summary>
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

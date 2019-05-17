using System.Collections.Generic;
using UnityEngine;

public static class CardShuffle
{
    public const int NumberOfCards = 52;
    private static List<int> shuffleIndexes;

    public static void Shuffle(List<Card> cards)
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

    private static void PopulateShuffleIndexes()
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

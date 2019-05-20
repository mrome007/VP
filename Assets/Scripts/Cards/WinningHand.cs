using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Utility class for figuring out winning hands.
/// </summary>
public static class WinningHand
{
    /// <summary>
    /// The number of cards per suit.
    /// </summary>
    public const int NumberOfCardsPerSuit = 13;

    /// <summary>
    /// Scores the hand.
    /// </summary>
    /// <returns>Winning Hand Category.</returns>
    /// <param name="cards">Cards.</param>
    public static WinningHandCategory ScoreHand(List<Card> cards)
    {
        var result = WinningHandCategory.Other;

        if(IsJacksOrBetter(cards))
        {
            result = WinningHandCategory.JacksOrBetter;
        }
        if(IsTwoPair(cards))
        {
            result = WinningHandCategory.TwoPair;
        }
        if(IsThreeOfAKind(cards))
        {
            result = WinningHandCategory.ThreeOfAKind;
        }
        if(IsStraight(cards))
        {
            result = WinningHandCategory.Straight;
        }
        if(IsFlush(cards))
        {
            result = WinningHandCategory.Flush;
        }
        if(IsFullHouse(cards))
        {
            result = WinningHandCategory.FullHouse;
        }
        if(IsFourOfAKind(cards))
        {
            result = WinningHandCategory.FourOfAKind;
        }
        if(IsStraightFlush(cards))
        {
            result = WinningHandCategory.StraightFlush;
        }
        if(IsRoyalFlush(cards))
        {
            result = WinningHandCategory.RoyalFlush;
        }

        return result;
    }

    /// <summary>
    /// Is the current hand jacks or better.
    /// </summary>
    /// <returns><c>true</c>, if jacks or better, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsJacksOrBetter(List<Card> cards)
    {
        var pairCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            pairCount[cards[index].CardValue - 1]++;
        }

        var numberOfJacksOrBetterCards = 4;
        var jackOrBetterIndex = (int)FaceCards.Jack - 1; 
        for(var count = 0; count < numberOfJacksOrBetterCards; count++)
        {
            if(pairCount[jackOrBetterIndex] == 2)
            {
                return true;
            }

            jackOrBetterIndex++;
            jackOrBetterIndex %= NumberOfCardsPerSuit;
        }

        return false;
    }

    /// <summary>
    /// Is the current hand a Two Pair.
    /// </summary>
    /// <returns><c>true</c>, if two pair, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsTwoPair(List<Card> cards)
    {
        var pairCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            pairCount[cards[index].CardValue - 1]++;
        }

        var twoPairsCount = 0;

        for(var index = 0; index < pairCount.Length; index++)
        {
            if(pairCount[index] == 2)
            {
                twoPairsCount++;
                if(twoPairsCount == 2)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Is the current hand Three Of A Kind.
    /// </summary>
    /// <returns><c>true</c>, if three of a kind, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsThreeOfAKind(List<Card> cards)
    {
        var similarCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            similarCount[cards[index].CardValue - 1]++;
        }

        for(var index = 0; index < similarCount.Length; index++)
        {
            if(similarCount[index] == 3)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is the current hand a Straight.
    /// </summary>
    /// <returns><c>true</c>, if straight, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsStraight(List<Card> cards)
    {
        var cardCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            cardCount[cards[index].CardValue - 1]++;
        }

        var cardIndex = 0;
        var straightCount = 0;
        for(var count = 0; count <= NumberOfCardsPerSuit; count++)
        {
            if(cardCount[cardIndex] == 1)
            {
                straightCount++;
                if(straightCount == cards.Count)
                {
                    break;
                }
            }
            else
            {
                straightCount = 0;
            }

            cardIndex--;
            if(cardIndex < 0)
            {
                cardIndex += NumberOfCardsPerSuit;
            }
        }

        return straightCount == cards.Count;
    }

    /// <summary>
    /// Is the current hand a Flush
    /// </summary>
    /// <returns><c>true</c>, if flush, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsFlush(List<Card> cards)
    {
        return cards.All(card => card.CardSuit == cards[0].CardSuit);
    }

    /// <summary>
    /// Is the current hand a Full House
    /// </summary>
    /// <returns><c>true</c>, if full house, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsFullHouse(List<Card> cards)
    {
        var similarCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            similarCount[cards[index].CardValue - 1]++;
        }

        var threeOfAKind = false;
        var pair = false;

        for(var index = 0; index < similarCount.Length; index++)
        {
            if(similarCount[index] == 3)
            {
                threeOfAKind = true;
            }

            if(similarCount[index] == 2)
            {
                pair = true;
            }
        }

        return threeOfAKind && pair;
    }

    /// <summary>
    /// Is the current hand a Four Of A Kind
    /// </summary>
    /// <returns><c>true</c>, if four of a kind, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsFourOfAKind(List<Card> cards)
    {
        var similarCount = new int[NumberOfCardsPerSuit];
        for(var index = 0; index < cards.Count; index++)
        {
            similarCount[cards[index].CardValue - 1]++;
        }

        for(var index = 0; index < similarCount.Length; index++)
        {
            if (similarCount[index] == 4)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is the current hand a Straight Flush.
    /// </summary>
    /// <returns><c>true</c>, if straight flush, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsStraightFlush(List<Card> cards)
    {
        return IsStraight(cards) && IsFlush(cards);
    }

    /// <summary>
    /// Is the current hand a Royal Flush.
    /// </summary>
    /// <returns><c>true</c>, if royal flush, <c>false</c> otherwise.</returns>
    /// <param name="cards">Cards.</param>
    public static bool IsRoyalFlush(List<Card> cards)
    {
        return IsStraightFlush(cards) && !cards.Any(card => card.CardValue > 1 && card.CardValue < 10);
    }
}

/// <summary>
/// Winning hand category.
/// </summary>
public enum WinningHandCategory
{
    Other,
    JacksOrBetter,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush
}

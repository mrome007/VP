using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class WinningHand
{
    public const int NumberOfCardsPerSuit = 13;

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

    public static bool IsFlush(List<Card> cards)
    {
        return cards.All(card => card.CardSuit == cards[0].CardSuit);
    }

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

    public static bool IsStraightFlush(List<Card> cards)
    {
        return IsStraight(cards) && IsFlush(cards);
    }

    public static bool IsRoyalFlush(List<Card> cards)
    {
        return IsStraightFlush(cards) && !cards.Any(card => card.CardValue > 1 && card.CardValue < 10);
    }
}

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

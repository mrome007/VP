using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hand class.
/// </summary>
public class Hand : MonoBehaviour
{
    /// <summary>
    /// The number of cards in hand.
    /// </summary>
    public const int NumberOfCardsInHand = 5;

    /// <summary>
    /// The hand transforms. Positions in the scene.
    /// </summary>
    [SerializeField]
    private List<Transform> handTransforms;

    /// <summary>
    /// The hand.
    /// </summary>
    private List<Card> hand;

    /// <summary>
    /// Current index in hand. Used for adding cards.
    /// </summary>
    private int currentAddIndex = 0;

    private void Awake()
    {
        InitializeHand();
        currentAddIndex = 0;
    }

    /// <summary>
    /// Initializes the hand.
    /// </summary>
    private void InitializeHand()
    {
        hand = new List<Card>();
        for(var count = 0; count < NumberOfCardsInHand; count++)
        {
            hand.Add(null);
        }
    }

    /// <summary>
    /// Returns all cards.
    /// </summary>
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

    /// <summary>
    /// Adds a card.
    /// </summary>
    /// <param name="card">Card.</param>
    public void AddCard(Card card)
    {
        hand[currentAddIndex] = card;

        card.SetCard(handTransforms[currentAddIndex]);

        currentAddIndex++;
        currentAddIndex %= NumberOfCardsInHand;
    }

    /// <summary>
    /// Adds a card in a specific index.
    /// </summary>
    /// <param name="card">Card.</param>
    /// <param name="index">Index.</param>
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

    /// <summary>
    /// Scores the hand.
    /// </summary>
    /// <returns>Winning Hand</returns>
    public WinningHandCategory ScoreHand()
    {
        return WinningHand.ScoreHand(hand);
    }
}

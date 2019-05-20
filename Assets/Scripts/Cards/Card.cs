using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Card class.
/// </summary>
public class Card : MonoBehaviour
{
    /// <summary>
    /// Card suit.
    /// </summary>
    [SerializeField]
    private Suit cardSuit;

    /// <summary>
    /// Card value.
    /// </summary>
    [SerializeField]
    protected int cardValue;

    /// <summary>
    /// Gets the card suit.
    /// </summary>
    /// <value>The card suit.</value>
    public Suit CardSuit { get { return cardSuit; } }

    /// <summary>
    /// Gets the card value.
    /// </summary>
    /// <value>The card value.</value>
    public virtual int CardValue { get { return cardValue; } }

    /// <summary>
    /// Card's parent transform.
    /// </summary>
    private Transform cardContainer;

    private void Awake()
    {
        cardContainer = transform.parent;
    }

    /// <summary>
    /// Returns the card original parent.
    /// </summary>
    public void ReturnCard()
    {
        transform.SetParent(cardContainer);
        transform.localPosition = Vector3.zero;
    }

    /// <summary>
    /// Sets the card to new parent.
    /// </summary>
    /// <param name="container">Container.</param>
    public void SetCard(Transform container)
    {
        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.SetAsLastSibling();
    }
}

/// <summary>
/// Suits
/// </summary>
public enum Suit
{
    Club,
    Diamond,
    Heart,
    Spade,
}

/// <summary>
/// Face cards
/// </summary>
public enum FaceCards
{
    Jack = 11,
    Queen = 12,
    King = 13,
}
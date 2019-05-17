using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Image cardImage;

    [SerializeField]
    private Suit cardSuit;

    [SerializeField]
    protected int cardValue;

    public Suit CardSuit { get { return cardSuit; } set { cardSuit = value; } }
    public virtual int CardValue { get { return cardValue; } set { cardValue = value; } }
    public Image CardImage { get { return cardImage; } }
}

public enum Suit
{
    Club,
    Diamond,
    Heart,
    Spade,
}

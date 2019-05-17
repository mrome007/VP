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

    public Suit CardSuit { get { return cardSuit; } }
    public virtual int CardValue { get { return cardValue; } }
}

public enum Suit
{
    Club,
    Diamond,
    Heart,
    Spade,
}

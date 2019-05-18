using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Suit cardSuit;

    [SerializeField]
    protected int cardValue;

    public Suit CardSuit { get { return cardSuit; } }
    public virtual int CardValue { get { return cardValue; } }

    private Transform cardContainer;

    private void Awake()
    {
        cardContainer = transform.parent;
    }

    public void ReturnCard()
    {
        transform.SetParent(cardContainer);
        transform.localPosition = Vector3.zero;
    }

    public void SetCard(Transform container)
    {
        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.SetAsLastSibling();
    }
}

public enum Suit
{
    Club,
    Diamond,
    Heart,
    Spade,
}

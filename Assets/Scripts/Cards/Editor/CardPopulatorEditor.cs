using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(CardPopulator))]
public class CardPopulatorEditor : Editor
{
    private CardPopulator cardPopulator;

    private void OnEnable()
    {
        cardPopulator = target as CardPopulator;
    }

    public override void OnInspectorGUI()
    {
        if(cardPopulator == null)
        {
            cardPopulator = target as CardPopulator;
        }

        DrawPopulateDeck();

        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawPopulateDeck()
    {
        if(GUILayout.Button("Populate Cards"))
        {
            GUI.changed = PopulateDeck();
        }
    }

    private bool PopulateDeck()
    {
        Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
        var suitIndex = 0;
        var currentSuit = suits[suitIndex];
        var cardCount = 0;

        var cardImages = Resources.LoadAll<Sprite>("Cards");
        var cardImagesIndex = 0;

        foreach(Transform child in cardPopulator.transform)
        {
            if (cardCount >= 13)
            {
                suitIndex++;
                currentSuit = suits[suitIndex];
                cardCount = 0;
            }

            var card = child.GetComponent<Card>();
            card.CardValue = cardCount + 1;
            card.CardSuit = currentSuit;
            card.CardImage.sprite = cardImages[cardImagesIndex];
            card.gameObject.name = GetCardName(card.CardValue) + "Of" + card.CardSuit.ToString() + "s";

            cardCount++;
            cardImagesIndex++;
        }
        return true;
    }

    private string GetCardName(int value)
    {
        var cardName = string.Empty;

        switch(value)
        {
            case 1:
                cardName = "Ace";
                break;
            case 11:
                cardName = "Jack";
                break;
            case 12:
                cardName = "Queen";
                break;
            case 13:
                cardName = "King";
                break;

            default:
                cardName = value.ToString();
                break;
        }

        return cardName;
    }
}

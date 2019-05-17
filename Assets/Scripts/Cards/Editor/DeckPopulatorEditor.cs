using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(DeckPopulator))]
public class DeckPopulatorEditor : Editor
{
    private DeckPopulator deckPopulator;

    private void OnEnable()
    {
        deckPopulator = target as DeckPopulator;
    }

    public override void OnInspectorGUI()
    {
        if(deckPopulator == null)
        {
            deckPopulator = target as DeckPopulator;
        }

        DrawPopulateDeck();

        if(GUI.changed)
        {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private void DrawPopulateDeck()
    {
        if(GUILayout.Button("Populate Deck"))
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

        foreach(Transform child in deckPopulator.transform)
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

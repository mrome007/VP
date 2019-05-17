using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<Card> cards;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CardShuffle.Shuffle(cards);

            for(var index = 0; index < cards.Count; index++)
            {
                var card = cards[index];
                card.transform.SetSiblingIndex(index);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMessage : MonoBehaviour
{
    [SerializeField]
    private Text winMessageLeft;

    [SerializeField]
    private Text winMessageRight;

    private readonly List<string> winMessages = new List<string>()
    {
        "",
        "JACKS\nOR\nBETTER",
        "TWO\nPAIR",
        "THREE\nOF\nA\nKIND",
        "STRAIGHT",
        "FLUSH",
        "FULL\nHOUSE",
        "FOUR\nOF\nA\nKIND",
        "STRAIGHT\nFLUSH",
        "ROYAL\nFLUSH",
    };

    public void UpdateWinMessage(WinningHand hand)
    {
        var message = winMessages[(int)hand];
        winMessageLeft.text = message;
        winMessageRight.text = message;
    }
}

public enum WinningHand
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Win Message.
/// </summary>
public class WinMessage : MonoBehaviour
{
    /// <summary>
    /// Win message text on the left.
    /// </summary>
    [SerializeField]
    private Text winMessageLeft;

    /// <summary>
    /// Win message text on the right.
    /// </summary>
    [SerializeField]
    private Text winMessageRight;

    /// <summary>
    /// Winning hand messages.
    /// </summary>
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

    /// <summary>
    /// Updates the win message.
    /// </summary>
    /// <param name="hand">Hand.</param>
    public void UpdateWinMessage(WinningHandCategory hand)
    {
        var message = winMessages[(int)hand];
        winMessageLeft.text = message;
        winMessageRight.text = message;
    }
}

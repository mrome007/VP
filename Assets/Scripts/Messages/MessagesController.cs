using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverMessageContainer;

    [SerializeField]
    private GameObject winMessageContainer;

    [SerializeField]
    private WinMessage winMessage;

    public void ShowGameOverMessage()
    {
        gameOverMessageContainer.SetActive(true);
        winMessageContainer.SetActive(false);
    }

    public void ShowWinMessage()
    {
        gameOverMessageContainer.SetActive(false);
        winMessageContainer.SetActive(true);
    }

    public void ShowMessages(bool show)
    {
        gameOverMessageContainer.SetActive(show);
        winMessageContainer.SetActive(show);
    }

    public void UpdateWinMessage(WinningHandCategory hand)
    {
        winMessage.UpdateWinMessage(hand);
    }
}

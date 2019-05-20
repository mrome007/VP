using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Messages controller.
/// </summary>
public class MessagesController : MonoBehaviour
{
    /// <summary>
    /// Game over message container.
    /// </summary>
    [SerializeField]
    private GameObject gameOverMessageContainer;

    /// <summary>
    /// Win message container.
    /// </summary>
    [SerializeField]
    private GameObject winMessageContainer;

    /// <summary>
    /// Win message.
    /// </summary>
    [SerializeField]
    private WinMessage winMessage;

    /// <summary>
    /// Shows the game over message.
    /// </summary>
    public void ShowGameOverMessage()
    {
        gameOverMessageContainer.SetActive(true);
        winMessageContainer.SetActive(false);
    }

    /// <summary>
    /// Shows the win message.
    /// </summary>
    public void ShowWinMessage()
    {
        gameOverMessageContainer.SetActive(false);
        winMessageContainer.SetActive(true);
    }

    /// <summary>
    /// Shows the messages.
    /// </summary>
    /// <param name="show">If set to <c>true</c> show.</param>
    public void ShowMessages(bool show)
    {
        gameOverMessageContainer.SetActive(show);
        winMessageContainer.SetActive(show);
    }

    /// <summary>
    /// Updates the win message.
    /// </summary>
    /// <param name="hand">Hand.</param>
    public void UpdateWinMessage(WinningHandCategory hand)
    {
        winMessage.UpdateWinMessage(hand);
    }
}

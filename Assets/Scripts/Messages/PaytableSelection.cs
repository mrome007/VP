using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Paytable selection.
/// </summary>
public class PaytableSelection : MonoBehaviour
{
    /// <summary>
    /// List of selection objects.
    /// </summary>
    [SerializeField]
    private List<GameObject> paytableSelections;

    /// <summary>
    /// Shows the selections.
    /// </summary>
    /// <param name="show">If set to <c>true</c> show.</param>
    public void ShowSelections(bool show)
    {
        paytableSelections.ForEach(selection => selection.SetActive(show));
    }

    /// <summary>
    /// Shows the selection at specific index.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="show">If set to <c>true</c> show.</param>
    public void ShowSelection(int index, bool show)
    {
        if(index < 0 || index >= paytableSelections.Count)
        {
            return;
        }

        ShowSelections(false);
        paytableSelections[index].SetActive(show);
    }
}

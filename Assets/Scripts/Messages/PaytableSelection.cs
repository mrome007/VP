using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaytableSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> paytableSelections;

    public void ShowSelections(bool show)
    {
        paytableSelections.ForEach(selection => selection.SetActive(show));
    }

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

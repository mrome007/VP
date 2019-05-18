using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesController : MonoBehaviour
{
    [SerializeField]
    private PresentationState InitialState;

    private void Start()
    {
        InitialState.EnterState();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationState : MonoBehaviour
{
    [SerializeField]
    private PresentationState nextState;

    public virtual void EnterState()
    {
        RegisterEvents();
    }

    public virtual void ExitState()
    {
        UnRegisterEvents();
        nextState.EnterState();
    }

    protected virtual void RegisterEvents()
    {

    }

    protected virtual void UnRegisterEvents()
    {

    }
}

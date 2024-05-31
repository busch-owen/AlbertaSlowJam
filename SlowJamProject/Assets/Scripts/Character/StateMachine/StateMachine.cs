using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

    public event Action<IState> StateChanged;

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.EnterState();

        StateChanged?.Invoke(startingState);
    }

    public void ChangeState(IState nextState)
    {
        CurrentState.ExitState();
        CurrentState = nextState;
        nextState.EnterState();

        StateChanged?.Invoke(nextState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateState();
        }
    }
}
using System;
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
        CurrentState?.UpdateState();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdateState();
    }
}
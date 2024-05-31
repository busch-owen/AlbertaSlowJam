using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;
    public PlayerBaseState(PlayerController player)
    {
        this._player = player;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void ExitState() {}
}
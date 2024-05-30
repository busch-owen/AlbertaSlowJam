using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;

    public PlayerBaseState(PlayerController player)
    {
        _player = player;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void ExitState() {}

    protected void Movement(Vector3 movement)
    {
        _player.Controller.Move(movement * Time.fixedDeltaTime);
    }
}
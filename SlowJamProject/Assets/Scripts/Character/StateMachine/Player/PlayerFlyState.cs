using UnityEngine;

public class PlayerFlyState : PlayerBaseState
{
    public PlayerFlyState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        _player.Velocity = _player.FlySpeed;
    }

    public override void UpdateState()
    {
        HandleSpeed();
        if (_player.DirectionInput == Vector2.zero)
        {
            _player.PlayerStates.ChangeState(_player.PlayerStates.GlideState);
        }
    }

    void HandleSpeed()
    {
        if (_player.DirectionInput.y > 0)
        {
            _player.Velocity = _player.FlySpeed;
        }
        else if (_player.DirectionInput.y < 0)
        {
            _player.Velocity = _player.GlideSpeed * _player.ReducedSpeed;
        }
    }
}
using UnityEngine;

public class PlayerGlideState : PlayerBaseState
{
    public PlayerGlideState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        _player.Velocity = _player.GlideSpeed;
        _player.Camera.SwitchToFollowView();
    }

    public override void UpdateState()
    {
        
    }

    public override void FixedUpdateState()
    {
        Glide();
        HandleSpeed();
        CalcTurns();
    }

    void HandleSpeed()
    {
        if (_player.DirectionInput.y > 0)
        {
            _player.Velocity = _player.FlySpeed;
        }
        else if (_player.DirectionInput.y < 0)
        {
            _player.Velocity = _player.GlideSpeed;
        }
    }
}
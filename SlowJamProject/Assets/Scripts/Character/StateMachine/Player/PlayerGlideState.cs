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
        HandleSpeed();
        CalcTurns();
    }

    public override void FixedUpdateState()
    {
        Glide();
        
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
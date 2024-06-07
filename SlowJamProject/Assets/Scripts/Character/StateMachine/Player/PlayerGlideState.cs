using System.Collections;
using UnityEngine;

public class PlayerGlideState : PlayerBaseState
{
    readonly int _glideHash = Animator.StringToHash("glide");
    readonly int _flapHash = Animator.StringToHash("flap");
    public PlayerGlideState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        _player.Animator.CrossFadeInFixedTime(_glideHash, 0.15f);
        _player.Velocity = _player.GlideSpeed;
        _player.Camera.SwitchToFollowView();
    }

    public override void FixedUpdateState()
    {
        Glide();
        HandleSpeed();
        CalcTurns();
    }

    public override void ExitState()
    {
        AudioManager.Instance.StopSounds();
    }

    void HandleSpeed()
    {
        if (_player.DirectionInput.y > 0)
        {
            _player.Velocity = _player.FlySpeed;
            _player.Animator.CrossFadeInFixedTime(_flapHash, 0.15f);
            AudioManager.Instance.PlayAudioLoop(_player.OwlSounds[0]);
        }
        else if (_player.DirectionInput.y < 0)
        {
            _player.Velocity = _player.GlideSpeed;
            _player.Animator.CrossFadeInFixedTime(_glideHash, 0.15f);
            AudioManager.Instance.StopSounds();
        }
    }
}
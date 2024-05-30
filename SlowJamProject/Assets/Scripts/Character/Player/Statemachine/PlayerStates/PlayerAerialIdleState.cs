using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialIdleState : PlayerBaseState
{
    float _rotationDamping = 1.25f;

    public PlayerAerialIdleState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        _player.Velocity = _player.GlideSpeed;
    }

    public override void UpdateState()
    {
        Vector3 glideDireciton = CalculateGlide();
        Movement(glideDireciton * _player.Velocity);
        FaceDirection(glideDireciton);

        if (_player.DirectionInput != Vector2.zero)
        {
            _player.PlayerStates.ChangeState(_player.PlayerStates.AerialMoveState);
        }
    }

    Vector3 CalculateGlide()
    {
        Vector3 forward = _player.MainCameraTransform.forward;
        Vector3 right = _player.MainCameraTransform.right;
        
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward + right;
    }

    void FaceDirection(Vector3 movement)
    {
        _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.LookRotation(movement), Time.fixedDeltaTime * _rotationDamping);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialMoveState : PlayerBaseState
{
    float _rotationDamping = 1.25f;

    public PlayerAerialMoveState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Aerial Movement yo!");
        _player.Velocity = _player.FlySpeed;
    }

    public override void UpdateState()
    {
        Vector3 movementInput = CalculateMovement();
        var vectorLerpMovement = Vector3.Lerp(movementInput, movementInput * _player.Velocity, 3f);
        Movement(vectorLerpMovement);
        FaceDirection(movementInput);

        if (movementInput == Vector3.zero)
        {
            _player.PlayerStates.ChangeState(_player.PlayerStates.AerialIdle);
        }
    }

    // calculates the charcater movement based on where the camera is facing.
    Vector3 CalculateMovement()
    {
        Vector3 forward = _player.MainCameraTransform.forward;
        Vector3 right = _player.MainCameraTransform.right;
        
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * _player.DirectionInput.y + right * _player.DirectionInput.x;
    }

    // Makes the player face the direciton of input.
    void FaceDirection(Vector3 movement)
    {
        _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.LookRotation(movement), Time.fixedDeltaTime * _rotationDamping);
    }
}
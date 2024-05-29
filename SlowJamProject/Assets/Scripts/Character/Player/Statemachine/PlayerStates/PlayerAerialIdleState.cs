using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialIdleState : PlayerBaseState
{
    public PlayerAerialIdleState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Flying in place, yo");
    }

    public override void UpdateState()
    {
        if (_player.DirectionInput != Vector2.zero)
        {
            // Move to aerialMovementState.
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
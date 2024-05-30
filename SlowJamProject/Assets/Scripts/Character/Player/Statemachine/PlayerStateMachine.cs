using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    // Grounded States
    public PlayerGroundIdle GroundedIdle;
    public PlayerTakeOffState TakeOff;
    // Airial States
    public PlayerAerialIdleState AerialIdle;
    public PlayerAerialMoveState AerialMoveState;
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        this.GroundedIdle = new PlayerGroundIdle(player);
        this.TakeOff = new PlayerTakeOffState(player);
        this.AerialIdle = new PlayerAerialIdleState(player);
        this.AerialMoveState = new PlayerAerialMoveState(player);
    }
}
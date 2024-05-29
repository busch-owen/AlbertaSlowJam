using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    // Grounded States
    public PlayerGroundIdle GroundedIdle;
    public PlayerTakeOffState TakeOff;
    public PlayerAerialIdleState AerialIdle;
    // Airial States
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        this.GroundedIdle = new PlayerGroundIdle(player);
    }
}
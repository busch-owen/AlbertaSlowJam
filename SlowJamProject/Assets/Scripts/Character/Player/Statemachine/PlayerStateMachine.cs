using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    // Grounded States
    public PlayerGroundIdle GroundedIdle;
    // Airial States
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        this.GroundedIdle = new PlayerGroundIdle(player);
    }
}
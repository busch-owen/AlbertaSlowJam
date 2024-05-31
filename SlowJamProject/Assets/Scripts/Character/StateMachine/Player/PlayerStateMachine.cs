using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    public PlayerGlideState GlideState;
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        this.GlideState = new PlayerGlideState(player);
    }
}
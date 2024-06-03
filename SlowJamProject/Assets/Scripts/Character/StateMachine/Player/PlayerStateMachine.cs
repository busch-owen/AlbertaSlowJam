using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    public PlayerGlideState GlideState;
    public PlayerAttackState StrikeState;
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        this.GlideState = new PlayerGlideState(player);
        this.StrikeState = new PlayerAttackState(player);
    }
}
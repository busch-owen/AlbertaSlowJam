using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    public PlayerGlideState GlideState;
    public PlayerAttackState StrikeState;
    public PlayerAimState AimState;
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        GlideState = new PlayerGlideState(player);
        StrikeState = new PlayerAttackState(player);
        AimState = new PlayerAimState(player);
    }
}
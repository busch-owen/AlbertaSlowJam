using System;
using System.Collections.Generic;
using Character.StateMachine.Player;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player States
    public PlayerGlideState GlideState;
    public PlayerAttackState StrikeState;
    public PlayerAimState AimState;
    public PlayerReturnToFlightState ReturnState;
    #endregion

    public PlayerStateMachine(PlayerController player)
    {
        GlideState = new PlayerGlideState(player);
        StrikeState = new PlayerAttackState(player);
        AimState = new PlayerAimState(player);
        ReturnState = new PlayerReturnToFlightState(player);
    }
}
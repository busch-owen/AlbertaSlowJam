using System;
using System.Collections;
using UnityEngine;

public class PlayerTakeOffState : PlayerBaseState
{
    float _takeOffTime = 1.2f;
    public PlayerTakeOffState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Taking Off!");
        _player.IsFlying = true;
        _player.Gravity = 0f;
        _player.StartCoroutine(SwitchToFlight());
    }

    public override void ExitState()
    {
        _player.StopCoroutine(SwitchToFlight());
    }

    IEnumerator SwitchToFlight()
    {
        yield return new WaitForSeconds(0.15f);
        _player.PlayerStates.ChangeState(_player.PlayerStates.AerialIdle);
    }
}

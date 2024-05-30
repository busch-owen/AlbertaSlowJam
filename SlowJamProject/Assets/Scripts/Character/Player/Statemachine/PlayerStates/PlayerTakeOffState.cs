using System;
using System.Collections;
using UnityEngine;

public class PlayerTakeOffState : PlayerBaseState
{
    Vector3 _aerialMovement;

    float _takeOffTime = 1.2f;
    public PlayerTakeOffState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Taking Off!");
        _aerialMovement = _player.Controller.velocity;
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
        _aerialMovement.y += _player.TakeOffForce;
        yield return new WaitForSeconds(0.15f);
        _player.PlayerStates.ChangeState(_player.PlayerStates.AerialIdle);
    }
}

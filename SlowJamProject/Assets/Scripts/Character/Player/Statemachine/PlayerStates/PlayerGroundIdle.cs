using UnityEngine;

public class PlayerGroundIdle : PlayerBaseState
{
    public PlayerGroundIdle(PlayerController player) : base(player)
    {
    }

    public override void EnterState() 
    {
        Debug.Log("Grounded and doing nothing, so idling.");
        _player.TakeFlightEvent += HandleFlight;
    }

    public override void UpdateState()
    {
        // Update stuff here.
    }

    public override void ExitState()
    {
        Debug.Log("Leaving grounded Idle!");
        _player.TakeFlightEvent -= HandleFlight;
    }

    void HandleFlight()
    {
        _player.PlayerStates.ChangeState(_player.PlayerStates.TakeOff);
    }
}
using UnityEngine;

public class PlayerGroundIdle : PlayerBaseState
{
    public PlayerGroundIdle(PlayerController player) : base(player)
    {
    }

    public override void EnterState() 
    {
        Debug.Log("Grounded and doing nothing, so idling.");
    }

    public override void UpdateState()
    {
        // Doing the update thing here.
    }

    public override void ExitState()
    {
        Debug.Log("Leaving grounded Idle!");
    }
}
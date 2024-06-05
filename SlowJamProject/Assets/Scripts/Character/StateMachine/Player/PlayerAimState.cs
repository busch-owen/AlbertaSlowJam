using UnityEngine;

public class PlayerAimState : PlayerBaseState
{
    public PlayerAimState(PlayerController player) : base(player)
    {
        
    }

    public override void FixedUpdateState()
    {
        AimCamera();
    }

    private void AimCamera()
    {
        _player.Camera.SwitchToTopDownView();
    }
}

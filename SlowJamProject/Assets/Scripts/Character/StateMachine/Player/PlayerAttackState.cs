using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerController player) : base(player)
    {
        
    }
    
    public override void FixedUpdateState()
    {
        Plunge();
    }

    private void Plunge()
    {
        _player.Rb.linearVelocity = _player.AttackVelocity * Time.fixedDeltaTime;
    }
}
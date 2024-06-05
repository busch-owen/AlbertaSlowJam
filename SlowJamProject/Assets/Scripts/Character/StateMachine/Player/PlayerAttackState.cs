using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerController player) : base(player)
    {
        
    }
    
    public override void FixedUpdateState()
    {
        Plunge();
        CheckForCritters();
    }

    private void Plunge()
    {
        _player.Rb.linearVelocity = _player.AttackVelocity * Time.fixedDeltaTime;
    }

    private void CheckForCritters()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_player.transform.position + _player.GrabPosition, _player.GrabRadius, Vector3.down, out hit, _player.CritterLayer))
        {
            Debug.Log("Hit Something");
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerController player) : base(player)
    {
        
    }

    public override void EnterState()
    {
        Plunge();
        _player.ReturnToFlight.AddListener(ReturnToFlight);
    }
    
    public override void FixedUpdateState()
    {
        CheckForCritters();

        if (_player.transform.position.y >= _player.FlightHeight && _player.TakingOff)
        {
            _player.PlayerStates.ChangeState(_player.PlayerStates.GlideState);
            _player.TakingOff = false;
        }
    }

    private void Plunge()
    {
        _player.Rb.linearVelocity = _player.AttackVelocity * Time.fixedDeltaTime;
    }

    private void CheckForCritters()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_player.transform.position + _player.GrabPosition, _player.GrabRadius, Vector3.down, out hit, _player.GrabRadius, _player.CritterLayer))
        {
            _player.CritterTransform = hit.transform;
            _player.CritterGrabbed.Invoke();
            ReturnToFlight();
        }
    }
}
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    readonly int _snatchCritter = Animator.StringToHash("snatch");

    public PlayerAttackState(PlayerController player) : base(player)
    { 
    }

    public override void EnterState()
    {
        Plunge();
        _player.Animator.CrossFadeInFixedTime(_snatchCritter, 0.15f);
        //_player.ReturnToFlight.AddListener(ReturnToFlight);
    }
    
    public override void FixedUpdateState()
    {
        CheckForCritters();

        // if (_player.transform.position.y >= _player.FlightHeight && _player.TakingOff)
        // {
        //     _player.PlayerStates.ChangeState(_player.PlayerStates.GlideState);
        //     _player.TakingOff = false;
        // }
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
            if (_player.CarryingCritter) return;
            _player.CritterTransform = hit.transform;
            _player.CritterGrabbed.Invoke();
            _player.PlayerStates.ChangeState(_player.PlayerStates.ReturnState);
        }
    }
}
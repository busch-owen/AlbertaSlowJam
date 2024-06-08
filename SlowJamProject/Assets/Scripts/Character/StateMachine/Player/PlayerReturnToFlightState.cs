using UnityEngine;

namespace Character.StateMachine.Player
{
    public class PlayerReturnToFlightState : PlayerBaseState
    {
        public PlayerReturnToFlightState(PlayerController player) : base(player)
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();
            _player.Rb.linearVelocity = _player.TakeoffSpeed * Time.fixedDeltaTime;
            _player.Camera.SwitchToFollowView();
            _player.TakingOff = true;
        }

        public override void FixedUpdateState()
        {
            if (_player.transform.position.y >= _player.IdealFlightHeight && _player.TakingOff)
            {
                _player.PlayerStates.ChangeState(_player.PlayerStates.GlideState);
                _player.TakingOff = false;
            }

        }
    }
}
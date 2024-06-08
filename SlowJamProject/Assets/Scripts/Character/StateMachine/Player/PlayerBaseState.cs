using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;
    public PlayerBaseState(PlayerController player)
    {
        _player = player;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
    public virtual void FixedUpdateState() {}
    public virtual void ExitState() {}

    protected void Movement(Vector3 input)
    {
        _player.Rb.linearVelocity = input * Time.fixedDeltaTime;
    }

    protected Vector3 Accelerate()
    {
        Vector3 forward = _player.transform.forward;

        forward.y = 0f;

        forward.Normalize();

        return forward * Mathf.Abs(_player.DirectionInput.y);
    }

    protected void Glide()
    {
        Vector3 forward = _player.transform.forward;
        Vector3 up = Vector3.zero;

        
        if (_player.transform.position.y < _player.IdealFlightHeight - 1f)
        {
            up = _player.transform.up * _player.TakeoffSpeed.y;
        }
        else if (_player.transform.position.y > _player.IdealFlightHeight + 1f)
        {
            up = -_player.transform.up * _player.TakeoffSpeed.y;
        }
        _player.Rb.linearVelocity = forward  * (_player.Velocity * Time.fixedDeltaTime) + up * Time.fixedDeltaTime;
    }

    protected void CalcTurns()
    {
        _player.transform.Rotate(Vector3.up, _player.DirectionInput.x * _player.TurnSensitivity * Time.deltaTime);
        TurnShipVisuals();
    }

    void TurnShipVisuals()
    {
        Quaternion flightRotation = Quaternion.Slerp(_player.BirdBody.transform.localRotation, Quaternion.Euler(new Vector3(
            _player.DirectionInput.y * _player.AngleY,
            _player.BirdBody.transform.localEulerAngles.y, -_player.DirectionInput.x * _player.AngleX)), Time.fixedDeltaTime * _player.RollSpeed);

        _player.BirdBody.transform.localRotation = flightRotation;
    }

    protected void ReturnToFlight()
    {
        _player.Rb.linearVelocity = _player.TakeoffSpeed * Time.fixedDeltaTime;
        _player.Camera.SwitchToFollowView();
        _player.TakingOff = true;
    }
}
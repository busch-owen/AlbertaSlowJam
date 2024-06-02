using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;

    public PlayerBaseState(PlayerController player)
    {
        this._player = player;
    }

    public virtual void EnterState() {}
    public virtual void UpdateState() {}
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
        _player.Rb.linearVelocity = _player.transform.forward * _player.Velocity * Time.fixedDeltaTime;
    }

    protected void CalcTurns()
    {
        _player.transform.Rotate(Vector3.up, _player.DirectionInput.x * _player.TurnSensitivity * Time.fixedDeltaTime);
        TurnShipVisuals();
    }

    void TurnShipVisuals()
    {
        _player.transform.localEulerAngles = new Vector3(
            _player.DirectionInput.y * _player.AngleY, 
            _player.transform.localEulerAngles.y, 
            -_player.DirectionInput.x * _player.AngleX);
    }
}
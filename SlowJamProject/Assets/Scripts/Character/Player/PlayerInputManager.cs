using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    InputSystem_Actions _inputActions;
    PlayerController _player;

    void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputSystem_Actions();

            _inputActions.Player.Move.performed += i => _player.HandleMovementInput(i.ReadValue<Vector2>());
        }
    }
}

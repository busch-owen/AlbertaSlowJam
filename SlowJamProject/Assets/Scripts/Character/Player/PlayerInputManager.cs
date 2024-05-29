using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerController _player;
    PlayerInputs _inputActions;

    void Awake()
    {
        _player = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerInputs();
            _inputActions.PlayerActions.Move.performed += (val) => _player.HandleMovementInput(val.ReadValue<Vector2>());
            _inputActions.PlayerActions.TakeFlight.performed += (val) => _player.HandleTakeFlight();
        }
        _inputActions.Enable();
    }
}

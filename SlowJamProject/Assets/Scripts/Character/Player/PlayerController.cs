using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Componenents
    [Header("Components")]
    [SerializeField]
    GameObject _birdBody;
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine PlayerStates { get; private set; }
    #endregion

    #region Movement Variables
    [Header("Movement Related")]
    [field:SerializeField]
    public float FlySpeed { get; private set; } = 10f;
    [field:SerializeField]
    public float SwoopSpeed { get; private set; } = 15f;
    public Vector2 DirectionInput { get; private set; }
    public bool IsFlying;
    #endregion

    #region Events related to States
    public event Action TakeFlightEvent;
    #endregion

    void Awake()
    {
        _birdBody = GameObject.FindGameObjectWithTag("BirdBody");

        if (PlayerStates == null)
        {
            PlayerStates = new PlayerStateMachine(this);
        }
    }

    void Start()
    {
        PlayerStates.ChangeState(PlayerStates.GroundedIdle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerStates.Update();
    }

    public void HandleMovementInput(Vector2 inputVec)
    {
        DirectionInput = inputVec;
    }

    public void HandleTakeFlight()
    {
        if (!IsFlying)
            TakeFlightEvent?.Invoke();
        else
            return;
    }
}

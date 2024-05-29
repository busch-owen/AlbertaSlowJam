using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Componenents
    [Header("Components")]
    [SerializeField]
    GameObject _birdBody;
    public Rigidbody Rb { get; private set; }
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
    [field:SerializeField]
    public float TakeOffForce { get; private set; } = 10f;
    public bool IsFlying;
    #endregion

    #region Events related to States
    public event Action TakeFlightEvent;
    #endregion

    // Misc
    [SerializeField]
    public float Gravity = -9.81f;

    void Awake()
    {
        _birdBody = GameObject.FindGameObjectWithTag("BirdBody");
        Rb = GetComponent<Rigidbody>();

        if (PlayerStates == null)
        {
            PlayerStates = new PlayerStateMachine(this);
        }
    }

    void Start()
    {
        IsFlying = false;
        PlayerStates.Initialize(PlayerStates.GroundedIdle);
        Rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStates.Update();
    }

    void FixedUpdate()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Rb.linearVelocity = new Vector3(transform.position.x, Gravity, transform.position.z);
    }

    public void HandleMovementInput(Vector2 inputVec)
    {
        DirectionInput = inputVec;
    }

    public void HandleTakeFlight()
    {
        if (IsFlying)
        {
            return;
        }
        else
        {
            TakeFlightEvent?.Invoke();
            Rb.AddForce(Rb.linearVelocity.x, TakeOffForce, Rb.linearVelocity.z);
        }
    }
}

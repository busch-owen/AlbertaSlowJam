using System;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [SerializeField]
    GameObject _birdBody;
    public Rigidbody Rb { get; private set; }
    [field:SerializeField]
    // public CharacterController Controller { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine PlayerStates { get; private set; }
    #endregion

    #region Movement Variables
    public float Velocity;
    [field:SerializeField]
    public float ReducedSpeed { get; private set; } = 0.85f;
    [field:SerializeField]
    public float GlideSpeed { get; private set; } = 1.25f;
    [field:SerializeField]
    public float FlySpeed { get; private set; } = 5f;
    [field:SerializeField]
    public float SwoopSpeed { get; private set; } = 15f;
    public Vector2 DirectionInput { get; private set; }
    [field:SerializeField]
    public float AngleX { get; private set; } = 30f;
    [field:SerializeField]
    public float AngleY { get; private set; } = 3f;
    public float TurnSensitivity { get; private set; } = 15f;
    #endregion

    // Misc
    #region Misc Variables
    [SerializeField]
    public float Gravity = -9.81f;
    // public Transform MainCameraTransform { get; private set; }
    #endregion

    void Awake()
    {
        _birdBody = GameObject.FindGameObjectWithTag("BirdBody");
        Rb = GetComponent<Rigidbody>();
        // Controller = GetComponent<CharacterController>();

        // MainCameraTransform = Camera.main.transform;

        if (PlayerStates == null)
        {
            PlayerStates = new PlayerStateMachine(this);
        }
    }

    void Start()
    {
        PlayerStates.Initialize(PlayerStates.GlideState);
    }

    void Update()
    {
        PlayerStates.Update();
    }

    public void HandleMovementInput(Vector2 inputs)
    {
        DirectionInput = inputs;
    }
}

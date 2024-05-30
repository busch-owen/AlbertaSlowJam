using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    #region Componenents
    [Header("Components")]
    [SerializeField]
    GameObject _birdBody;
    [field:SerializeField]
    public CharacterController Controller { get; private set; }
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
    Vector2 _cameraDirection;
    [field:SerializeField]
    public float TakeOffForce { get; private set; } = 10f;
    public bool IsFlying;
    #endregion

    #region Events related to States
    public event Action TakeFlightEvent;
    #endregion

    #region Misc Variables
    [SerializeField]
    public float Gravity = -9.81f;
    public Transform MainCameraTransform { get; private set; }
    #endregion

    void Awake()
    {
        _birdBody = GameObject.FindGameObjectWithTag("BirdBody");
        Controller = GetComponent<CharacterController>();

        MainCameraTransform = Camera.main.transform;

        if (PlayerStates == null)
        {
            PlayerStates = new PlayerStateMachine(this);
        }
    }

    void Start()
    {
        // IsFlying = false;
        PlayerStates.Initialize(PlayerStates.AerialIdle);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStates.Update();
    }

    public void HandleMovementInput(Vector2 inputVec)
    {
        DirectionInput = inputVec;
    }

    // This might be removed later we'll see how scoping goes.
    public void HandleTakeFlight()
    {
        if (Controller.isGrounded)
        {
            TakeFlightEvent?.Invoke();
        }
    }
}

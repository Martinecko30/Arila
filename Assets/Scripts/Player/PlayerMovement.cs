using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float runSpeed;

    [Header("Inputs")]
    private PlayerInputActions playerInputActions;
    private InputAction move;
    private InputAction jump;
    private InputAction run;

    private float _ySpeed;
    private float _speed;
    private bool _running;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        if(TryGetComponent(out CharacterController control))
            controller = control;
        else
            controller = gameObject.AddComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        move = playerInputActions.Player.Move;
        jump = playerInputActions.Player.Jump;
        run = playerInputActions.Player.Run;

        move.Enable();
        jump.Enable();
        run.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        run.Disable();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 camRelativeMovement = Utils.ConvertToCameraSpace(new(
            move.ReadValue<Vector2>().x,
            0,
            move.ReadValue<Vector2>().y
        ));

        if (jump.triggered && controller.isGrounded)
        {
            _ySpeed = jumpForce;
        }

        if (run.IsPressed())
        {
            _running = !_running;
        }

        if (!_running)
        {
            _speed = walkSpeed;
        }
        else
        {
            _speed = runSpeed;
        }

        if (camRelativeMovement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(camRelativeMovement);


        //camRelativeMovement = Vector3.Lerp(transform.position, camRelativeMovement, Time.deltaTime * 100);

        camRelativeMovement *= _speed;
        camRelativeMovement.y = _ySpeed;

        controller.Move(camRelativeMovement * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float runSpeed;

    private float _ySpeed;
    private float _speed;
    private bool _running;

    void Start()
    {
        if(TryGetComponent(out CharacterController control))
            controller = control;
        else
            controller = gameObject.AddComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 camRelativeMovement = Utils.ConvertToCameraSpace(new(
            Input.GetAxis("Horizontal"), 
            0, 
            Input.GetAxis("Vertical"))
        );

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            _ySpeed = jumpForce;
        }

        if (Input.GetKey(KeyCode.LeftShift) && !_running)
        {
            _speed = runSpeed;
            _running = true;
        }
        else
        {
            _speed = walkSpeed;
            _running = false;
        }
        camRelativeMovement *= _speed;
        camRelativeMovement.y = _ySpeed;

        controller.Move(camRelativeMovement * Time.deltaTime);
    }
}
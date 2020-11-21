using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    PlayerControls controls;

    public Rigidbody rb;
    Vector3 movement;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveForward.performed += ctx => movement.z = ctx.ReadValue<float>();
        controls.Gameplay.MoveForward.canceled += ctx => movement.z = 0;

        controls.Gameplay.MoveRight.performed += ctx => movement.x = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => movement.x = 0;

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { set; get; }

    [Header("Player Health")]
    public int health = 100;                                            

    [Header("Movement Settings")]
    public float playerSpeed = 5.0f;
    public float turnSpeed = 5.0f;

    PlayerControls controls;

    Rigidbody rb;
    Vector3 movement;
    float rotation = 0.0f;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveForward.performed += ctx => movement.z = ctx.ReadValue<float>();
        controls.Gameplay.MoveForward.canceled += ctx => movement.z = 0;

        controls.Gameplay.MoveRight.performed += ctx => movement.x = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => movement.x = 0;

        controls.Gameplay.Run.performed += ctx => Run();
        controls.Gameplay.Run.canceled += ctx => Walk();

        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
        // If the player is going left
        if (movement.x == -1)
        {
            rotation = -90;
        }
        else if (movement.x == 1)
        {
            rotation = 90;
        }
        else if (movement.z == -1)
        {
            rotation = 180;
        }
        else if (movement.z == 1)
        {
            rotation = 0;
        }

        // Rotate the player by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(movement.x, rotation, movement.z);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * turnSpeed);
    }

    void Run()
    {
        Debug.Log("Player is running");
    }

    void Walk()
    {
        Debug.Log("Player is walking");
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

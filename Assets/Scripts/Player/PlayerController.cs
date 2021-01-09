using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { set; get; }

    [Header("Player Health")]
    public int health = 100;                                            

    [Header("Movement Settings")]
    public int playerSpeed = 2;
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
        controls.Gameplay.Run.canceled += ctx => Run();

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
        // Gets the dirction based on 
        if (movement.x == -1 && movement.z == 0)
        {
            rotation = -90;
        }
        else if (movement.x == 1 && movement.z == 0)
        {
            rotation = 90;
        }
        else if (movement.z == -1 && movement.x == 0)
        {
            rotation = 180;
        }
        else if (movement.z == 1 && movement.x == 0)
        {
            rotation = 0;
        }
        else if (movement.x == 1 && movement.z == 1)
        {
            rotation = 45;
        }
        else if (movement.x == -1 && movement.z == 1)
        {
            rotation = -45;
        }
        else if (movement.x == 1 && movement.z == -1)
        {
            rotation = 135;
        }
        else if (movement.x == -1 && movement.z == -1)
        {
            rotation = -135;
        }
        
        // Rotate the player by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(movement.x, rotation, movement.z);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * turnSpeed);
    }

    void Run()
    {
        Debug.Log("Player is running");
        playerSpeed = 5;

        if (playerSpeed == 1)
        {

        }
        else
        {
            playerSpeed = 2;
        }
    }

    void Walk()
    {
        Debug.Log("Player is walking");
        
    }

    void OnEnable()
    {
        // Enables the player's input when the game object is enabled
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

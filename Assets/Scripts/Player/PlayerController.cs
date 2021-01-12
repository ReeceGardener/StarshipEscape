using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { set; get; }

    [Header("Player Health")]
    public float health = 100;
    public float maxHealth = 100;
    public Slider healthBar;

    [Header("Movement Settings")]
    public int playerSpeed = 2;
    public float turnSpeed = 5.0f;

    PlayerControls controls;

    CharacterController characterController;
    Vector3 movement;
    float rotation = 0.0f;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveForward.performed += ctx => movement.z = ctx.ReadValue<float>();
        controls.Gameplay.MoveForward.canceled += ctx => movement.z = 0;

        controls.Gameplay.MoveRight.performed += ctx => movement.x = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => movement.x = 0;

        // If the player presses the run button the Run function will be called
        controls.Gameplay.Run.performed += ctx => Run();
        controls.Gameplay.Run.canceled += ctx => Walk();

        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        healthBar.value = health / maxHealth;
    }

    void FixedUpdate()
    {
        characterController.Move(movement * Time.deltaTime * playerSpeed);
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
        playerSpeed = 4;
    }

    void Walk()
    {
        Debug.Log("Player is walking");
        playerSpeed = 2;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(LoseGame), 0.5f);
    }
    private void LoseGame()
    {

    }

    void OnEnable()
    {
        // Enables the player's input when the game object is enabled
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        // Disables the player's input when the game object is disabled
        controls.Gameplay.Disable();
    }
}

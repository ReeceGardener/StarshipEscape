using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { set; get; }

    string buttonName;
    public GameObject gameOverScreen;
    public Text gameResultText;
    public string gameResult;

    public EventSystem eventSystem;
    AudioSource audioSource;

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();

        // Gets the UI Audio Source
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        gameResultText.text = gameResult;
    }

    public void ConfirmSelection()
    {
        if (GameManager.instance.gameOver == true)
        {
            buttonName = eventSystem.currentSelectedGameObject.name;
            switch (buttonName)
            {
                case "RetryButton":
                    RetryLevel("MainScene");
                    break;
                case "MainMenuButton":
                    MainMenu("MainMenu");
                    break;
            }
        }
    }

    public void RetryLevel(string level)
    {
        audioSource.Play();
        GameManager.instance.gameOver = false;
        SceneLoader.instance.LoadLevel(level);
        Time.timeScale = 1;
    }

    public void MainMenu(string level)
    {
        audioSource.Play();
        GameManager.instance.gameOver = false;
        SceneLoader.instance.LoadLevel(level);
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        // Enables the player's input when the game object is enabled
        controls.MenuContol.Enable();
    }

    void OnDisable()
    {
        // Disables the player's input when the game object is disabled
        controls.MenuContol.Disable();
    }
}

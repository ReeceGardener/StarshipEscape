using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    string buttonName;

    public Text hiScoreText;
    public EventSystem eventSystem;
    AudioSource audioSource;

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();

        // Gets the Main Menu Audio Source
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // When the game starts the game will get the high score from the game manager
        hiScoreText.text = "HI SCORE: " + GameManager.instance.hiScore;
    }

    public void PlayGame(string level)
    {
        // Plays a audio file
        audioSource.Play();

        // Loads into the main level
        SceneLoader.instance.LoadLevel(level);
    }

    public void QuitGame()
    {
        // Plays a audio file
        audioSource.Play();

        // Quits the game
        Application.Quit();
    }

    public void ConfirmSelection()
    {
        buttonName = eventSystem.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "PlayButton":
                PlayGame("MainScene");
                break;
            case "QuitButton":
                QuitGame();
                break;
        }
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

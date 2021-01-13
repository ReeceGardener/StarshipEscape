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

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();
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

    public void RetryLevel(string level)
    {
        SceneLoader.instance.LoadLevel(level);
        Time.timeScale = 1;
    }

    public void MainMenu(string level)
    {
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

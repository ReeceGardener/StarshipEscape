using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    string buttonName;

    public EventSystem eventSystem;

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();
    }

    public void ConfirmSelection()
    {
        buttonName = eventSystem.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "RetryButton":
                RetryLevel("MainScene");
                //Time.timeScale = 1;
                break;
            case "MainMenuButton":
                MainMenu("MainMenu");
                //Time.timeScale = 1;
                break;
        }
    }

    public void RetryLevel(string level)
    {
        SceneLoader.instance.LoadLevel(level);
    }

    public void MainMenu(string level)
    {
        SceneLoader.instance.LoadLevel(level);
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

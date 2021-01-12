﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    string buttonName;

    public Text hiScoreText;
    public EventSystem eventSystem;

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();
    }

    private void Start()
    {
        // When the game starts the game will get the high score from the game manager
        hiScoreText.text = "HI SCORE: " + GameManager.instance.hiScore;
    }

    public void PlayGame(string level)
    {
        // Loads 
        SceneLoader.instance.LoadLevel(level);
    }

    public void QuitGame()
    {
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

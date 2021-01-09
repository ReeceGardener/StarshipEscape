using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    int menuIndex;
    float menu;

    public Button[] mainMenuButtons;
    public Text hiScoreText;
    public Text testText;

    MainMenu controls;

    void Awake()
    {
        controls = new MainMenu();

        controls.MenuContol.MoveSelection.performed += ctx => menu = ctx.ReadValue<float>();
        //controls.MenuContol.MoveSelection.canceled += ctx => menuIndex = ctx.ReadValue<int>();

        controls.MenuContol.ConfirmSelection.performed += ctx => ConfirmSelection();
        //controls.MenuContol.ConfirmSelection.canceled += ctx => ConfirmSelection();
    }

    private void Start()
    {
        // When the game starts the game will get the high score from the game manager
        hiScoreText.text = "HI SCORE: " + GameManager.instance.hiScore;
    }

    void Update()
    {
        menuIndex = (int)(menuIndex - menu);
        menuIndex = Mathf.Clamp(menuIndex, 0, mainMenuButtons.Length);
        testText.text = "Menu Index: " + menu;
        mainMenuButtons[menuIndex].Select();
    }

    public void PlayGame(string level)
    {
        // 
        SceneLoader.instance.LoadLevel(level);
    }

    public void QuitGame()
    {
        // Quits the game
        Application.Quit();
    }

    public void ConfirmSelection()
    {
        Debug.Log(menuIndex);
        switch(menuIndex)
        {
            case 0:
                PlayGame("MainScene");
                break;
            case 1:
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
        controls.MenuContol.Disable();
    }
}

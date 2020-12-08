using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public Button mainMenuButtons;
    public Text hiScoreText;

    GameObject gameManager;
    GameManager gameManagerScript;

    public SceneLoader sceneLoader;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        hiScoreText.text = "HI SCORE: " + gameManagerScript.hiScore;
    }

    public void PlayGame()
    {
        sceneLoader.LoadLevel(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

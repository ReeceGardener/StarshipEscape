using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public Button mainMenuButtons;
    public Text hiScoreText;

    private void Start()
    {
        hiScoreText.text = "HI SCORE: " + GameManager.instance.hiScore;
    }

    public void PlayGame(string level)
    {
        SceneLoader.instance.LoadLevel(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

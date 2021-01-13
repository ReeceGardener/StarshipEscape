using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { set; get; }
    
    public int hiScore;
    public int score = 0;

    public Text hiScoreText;

    private void Awake()
    {
        // Tells the game to not destroy this game object
        DontDestroyOnLoad(gameObject);

        // Gets the high score from the computer's re
        hiScore = PlayerPrefs.GetInt("hiscore");
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver(bool hasLost)
    {
        Time.timeScale = 0;

        if (hasLost == true)
        {
            ScoreManager.instance.score = 0;
            UIManager.instance.gameResult = "YOU LOST!!!";
        }
        else
        {
            ScoreManager.instance.CalculateFinalScore();

            UIManager.instance.gameResult = "YOU WON!!!";
            // if the player's score is more than the current high score
            if (ScoreManager.instance.score > hiScore)
            {
                // Sets high score to the player's score
                hiScore = ScoreManager.instance.score;
                // Sets the player pref for the high s
                PlayerPrefs.SetInt("hiscore", hiScore);
                // Saves the player prefs
                PlayerPrefs.Save();
            }
        }
        UIManager.instance.gameOverScreen.SetActive(true);
    }
}

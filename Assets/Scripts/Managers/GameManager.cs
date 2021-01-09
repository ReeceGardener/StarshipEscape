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

    public void GameOver()
    {
        // if the player's score is more than the current high score
        if (score > hiScore)
        {
            // Sets high score to the player's score
            hiScore = score;
            // Sets the player pref for the high s
            PlayerPrefs.SetInt("hiscore", hiScore);
            // Saves the player prefs
            PlayerPrefs.Save();
            // Resets the player's score to 0
            score = 0;
        }
    }
}

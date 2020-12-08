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
        DontDestroyOnLoad(gameObject);
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
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt("score", hiScore);
            PlayerPrefs.Save();
            score = 0;
        }
    }
}

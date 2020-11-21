using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    int hiScore;
    int score = 0;

    public Text hiScoreText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        hiScore = PlayerPrefs.GetInt("hiscore");
        hiScoreText.text = "HI SCORE: " + hiScore;
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

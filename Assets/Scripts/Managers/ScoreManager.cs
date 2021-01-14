using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { set; get; }

    [Header("Score Settings")]
    public int score = 0;
    public int finalScore = 0;
    public int fullHealthReward = 2500;
    public int knockOutReward = 100;
    public Text scoreText;
    public Text finalScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void CalculateFinalScore()
    {
        finalScore += score;
        if (PlayerController.instance.health == PlayerController.instance.maxHealth)
        {
            finalScore += fullHealthReward;
            finalScoreText.text = "YOUR SCORE: " + finalScore;
        }

        finalScoreText.text = "YOUR SCORE: " + finalScore;
    }
}

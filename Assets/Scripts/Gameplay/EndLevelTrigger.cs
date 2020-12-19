using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public string levelName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You have won!!!");
        Debug.Log("Score: " + "100");
        ScoreManager.instance.score += 100;
        GameManager.instance.score = ScoreManager.instance.score;
        GameManager.instance.GameOver();
        SceneLoader.instance.LoadLevel(levelName);
    }
}

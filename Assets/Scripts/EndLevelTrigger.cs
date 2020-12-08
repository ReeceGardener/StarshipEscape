using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    GameObject gameManager;
    GameManager gameManagerScript;

    public SceneLoader sceneLoader;
    public ScoreManager scoreManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You have won!!!");
        Debug.Log("Score: " + "100");
        gameManagerScript.score = scoreManager.score;
        gameManagerScript.GameOver();
        sceneLoader.LoadLevel(1);
    }
}

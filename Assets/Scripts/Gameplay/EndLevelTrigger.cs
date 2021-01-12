using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public string levelName;

    public GameObject gameOverScreen;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.score += 100;
        GameManager.instance.GameOver();
        //Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        audioSource.Play();
    }
}

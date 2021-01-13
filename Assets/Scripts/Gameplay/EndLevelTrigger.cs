using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public string levelName;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.score += 100;
        GameManager.instance.GameOver(false);
        audioSource.Play();
    }
}

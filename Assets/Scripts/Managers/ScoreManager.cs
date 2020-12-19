using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { set; get; }

    [Header("Score Settings")]
    public int score = 0;

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
        
    }
}

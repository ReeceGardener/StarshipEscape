using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public string levelName;

    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsychronously(levelName));
    }

    IEnumerator LoadAsychronously(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            yield return null;
        }
    }
}

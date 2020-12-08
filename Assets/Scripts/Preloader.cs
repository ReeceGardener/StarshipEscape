using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsychronously(1));
    }

    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            yield return null;
        }
    }
}

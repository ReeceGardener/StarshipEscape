using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject[] gameUI;

    public void LoadLevel(int level)
    {
        StartCoroutine(LoadAsychronously(level));
    }

    IEnumerator LoadAsychronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        foreach (GameObject UI in gameUI)
        {
            UI.SetActive(false);
        }

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            yield return null;
        }
    }
}

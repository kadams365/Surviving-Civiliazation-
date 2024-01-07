using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingTip;
    public string[] loadingScreentips = new string[] { "Don't forget to do some healing.", "Sometimes taking the long way pays off.", "Each nation has their own style of fighting." };

    void OnEnable()
    {
        string loadingtip = loadingScreentips[Random.Range(0, loadingScreentips.Length)];
        loadingTip.text = loadingtip;
    }

    public void InitialLoading()
    {
        StartCoroutine(ActivateAndDeactivate(Random.Range(0, 3)));
        print("Started Initial Loading");
    }

    IEnumerator ActivateAndDeactivate(int duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate the GameObject after the duration
        gameObject.SetActive(!gameObject.activeSelf);
        print("Finished Initial Loading");
    }

    public void NextScene()
    {
        StartCoroutine(LoadNextAsyncScene());
    }

    IEnumerator LoadNextAsyncScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);
    }
}

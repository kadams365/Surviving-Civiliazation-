using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveCity : MonoBehaviour
{

    public GameObject leaveUI;
    public GameObject npcUI;

    //Loading Screen Stuff
    public GameObject loadingScreen;
    public Text loadingTip;
    public string[] tips = new string[] { "Don't forget to do some healing.", "Sometimes taking the long way pays off.", "Each nation has their own style of fighting." };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
            leaveUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
            leaveUI.SetActive(false);
    }

    private void Update()
    {
        if(npcUI.activeSelf)
            leaveUI.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E) && leaveUI.activeSelf)
        {
            GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        loadingScreen.SetActive(true);
        string loadingtip = tips[Random.Range(0, tips.Length)];
        loadingTip.text = loadingtip;

        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(currentScene);
    }
}

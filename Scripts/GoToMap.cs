using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Game");
        print("going to game.");
    }
}

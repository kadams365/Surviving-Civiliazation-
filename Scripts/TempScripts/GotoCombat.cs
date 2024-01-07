using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoCombat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Battle");
        print("going to battle.");
    }
}

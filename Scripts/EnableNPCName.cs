using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNPCName : MonoBehaviour
{
    public GameObject NameText;

    public void OnBecameInvisible()
    {
        NameText.SetActive(false);
    }

    public void OnBecameVisible()
    {
        NameText.SetActive(true);
    }
}

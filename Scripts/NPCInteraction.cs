using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject soldierUI;
    public GameObject interactionText;
    public GameObject talkingOptions;

    public Text dialog;
    public Button talkOption1;
    public Button talkOption2;
    public Button talkOption3;

    public GameObject potionUI;

    private string[] introduction = new string[] { "Citizen.", "What do you need?", "What is it?", "No lollygaggin'.", "Everything all right?", };
    private string[] cityInfo = new string[] { "There is rumor as it there is a blackmarket in the city.", "This city is under my protection. You watch yourself, now", "If you need potions, you should try seeing the potion master.", "Need a blade? You should talk to the weapon master, at the tents.", "You can sell off that junk at any of the shops in the city.", };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier"))
            soldierUI.SetActive(true);
        if (other.CompareTag("Potion Seller"))
            potionUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soldier"))
            soldierUI.SetActive(false);
        if (other.CompareTag("Potion Seller"))
            potionUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && soldierUI.activeSelf)
        {
            GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = true;
            talkingOptions.SetActive(true);
            interactionText.SetActive(false);
            //lock camera?
            Introduction();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && soldierUI.activeSelf && talkingOptions.activeSelf)
            StartCoroutine(AboutCity());
        if (Input.GetKeyDown(KeyCode.Alpha2) && soldierUI.activeSelf && talkingOptions.activeSelf)
            Duel();
        if (Input.GetKeyDown(KeyCode.Alpha3) && soldierUI.activeSelf && talkingOptions.activeSelf)
            Bye();

        if (Input.GetKeyDown(KeyCode.E) && potionUI.activeSelf)
        {
            GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = true;
            talkingOptions.SetActive(true);
            interactionText.SetActive(false);
            //lock camera?
            Introduction();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && soldierUI.activeSelf && talkingOptions.activeSelf)
            StartCoroutine(AboutCity());
        if (Input.GetKeyDown(KeyCode.Alpha2) && soldierUI.activeSelf && talkingOptions.activeSelf)
            Duel();
        if (Input.GetKeyDown(KeyCode.Alpha3) && soldierUI.activeSelf && talkingOptions.activeSelf)
            Bye();
    }

    private void Introduction()
    {
        string introductionString = introduction[Random.Range(0, introduction.Length)];
        dialog.text = introductionString;
    }

    private void Duel()
    {
        //transfer NPC Name and Mesh to battle Scene then load Duel Scene
    }

    IEnumerator AboutCity()
    {
        talkOption1.interactable = false;
        talkOption2.interactable = false;
        talkOption3.interactable = false;

        string aboutCityString = cityInfo[Random.Range(0, cityInfo.Length)];
        dialog.text = aboutCityString;

        yield return new WaitForSeconds(2f);

        talkOption1.interactable = true;
        talkOption2.interactable = true;
        talkOption3.interactable = true;
    }

    public void Bye()
    {
        GameObject.Find("Player").GetComponent<Rigidbody>().isKinematic = false;
        talkingOptions.SetActive(false);
        interactionText.SetActive(true);
    }
}

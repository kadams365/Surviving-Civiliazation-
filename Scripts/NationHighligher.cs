using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NationHighligher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject highlight;
    public GameObject nationAbout;
    public TextMeshProUGUI nationAboutText;
    public string nationAboutString;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GetComponent<Button>().interactable = true;
        highlight.SetActive(true);
        nationAbout.SetActive(true);
        nationAboutText.text = nationAboutString;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        GetComponent<Button>().interactable = false;
        highlight.SetActive(false);
        nationAbout.SetActive(false);
    }
}

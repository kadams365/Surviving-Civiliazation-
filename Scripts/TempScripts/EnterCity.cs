using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterCity : MonoBehaviour
{
    public GameObject enterCityButton;
    public int cityID;

    //City Data
    public Text cityName;
    public Text attackOdds;
    public Image cityIcon;
    public Image cityFlag;
    public int cityPower;

    //City Images
    public Sprite ArcneEmpireCity;

    //Flag Images
    public Sprite ArcneEmpirFlag;

    private void OnTriggerEnter(Collider other)
    {
        LoadCity();
        enterCityButton.SetActive(true);
    }

    // Disable the city panel
    private void OnTriggerExit(Collider other)
    {
        enterCityButton.SetActive(false);
    }

    //Load City Data
    void LoadCity()
    {
        if(cityID == 0)
        {
            //Attack Odds
            attackOdds.text = "Ally";
            //City Icon
            cityIcon.sprite = ArcneEmpireCity;
            //City Name
            cityName.text = "Old Castle";
            //Flag
            cityFlag.sprite = ArcneEmpirFlag;
        }
        if (cityID == 1)
        {
            //Attack Odds
            attackOdds.text = "Attack Odds: Fair";
            //City Icon
            cityIcon.sprite = ArcneEmpireCity;
            //City Name
            cityName.text = "Red Castle";
            //Flag
            cityFlag.sprite = ArcneEmpirFlag;
        }
        else
        {
            Debug.LogError("City Unknown");
        }
    }

    //Go into city
    public void GoIntoCity()
    {
        //save current game info
        Save();
        //set city secific info
        //load into new scene
        SceneManager.LoadScene("City");
        //load already saved data
    }

    //Save
    void Save()
    {
        //player inventory
        //player location
        //player level
        //player army
        //player time
        //player stats
        //player money
    }
}

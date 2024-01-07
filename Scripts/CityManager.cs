using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CityManager : MonoBehaviour
{

    public GameObject playerInventoryScreen;
    public GameObject playerStatsScreen;

    public TextMesh weaponsMasterText;
    public TextMesh potionMasterText;

    public GameObject settingsPanel;
    bool gamePaused;


    void Start()
    {
        SetNames();
        settingsPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gamePaused = !gamePaused;

        if (gamePaused)
            settingsPanel.SetActive(true);
        else
            settingsPanel.SetActive(false);
    }

    void SetNames()
    {
        string nationName = GameManager.CountryName;

        if (nationName == "Acrne Empire")
        {
            weaponsMasterText.text = "Chadwick Carman\n<Weapons Master>";
            potionMasterText.text = "Edric Huntere\n<Potion Master>";
        }
        else if (nationName == "Snake Village")
        {
            weaponsMasterText.text = "Samrah Hashim\n<Weapons Master>";
            potionMasterText.text = "Zero Naqvi\n<Potion Master>";
        }
        else if (nationName == "Shogun")
        {
            weaponsMasterText.text = "Jin Masahiro\n<Weapons Master>";
            potionMasterText.text = "Anzai Takashi\n<Potion Master>";
        }
        else if (nationName == "Holy Knights")
        {
            weaponsMasterText.text = "Rheinallt Beddoe\n<Weapons Master>";
            potionMasterText.text = "Neifion Erwood\n<Potion Master>";
        }
        else if (nationName == "Black Frost Legion")
        {
            weaponsMasterText.text = "Hagan Stroman\n<Weapons Master>";
            potionMasterText.text = "Wolfram Frei\n<Potion Master>";
        }
    }

    public void OpenInventory()
    {
        if(playerInventoryScreen.activeInHierarchy == true)
        {
            playerInventoryScreen.SetActive(false);
        }
        else
        {
            playerInventoryScreen.SetActive(true);
        }
    }

    public void OpenStats()
    {
        if (playerStatsScreen.activeInHierarchy == true)
        {
            playerStatsScreen.SetActive(false);
        }
        else
        {
            playerStatsScreen.SetActive(true);
        }
    }

    //Leave city
    public void LeaveCity()
    {
        //save current game info
        Save();
        //set city secific info
        //load into new scene
        SceneManager.LoadScene("Game");
        //load already saved data
    }

    //Save
    public void Save()
    {
        //player inventory
        //player level
        //player army
        //player time
        //player stats
        Debug.Log("Saved Game");
    }

    //Exit game
    public void ExitGame()
    {
        Save();
        Application.Quit();
    }
}
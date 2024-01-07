using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private int level;
    private int exp;
    private int maxHP;
    private int currentHP;
    private int baseDamage;
    private int baseHeal;

    public GameObject settingsScreen;

    //Loading Screen Stuff
    public GameObject loadingScreen;

    GameData saveData = new GameData();

    private void Start()
    {   
        // Loads saved player settings
        saveData = SaveSystem.instance.LoadGame();

        loadingScreen.SetActive(!loadingScreen.activeSelf);
        settingsScreen.SetActive(!settingsScreen.activeSelf);

        loadingScreen.GetComponent<LoadingScreen>().InitialLoading();
        settingsScreen.GetComponent<Settings>().LoadingInitialSettings();
    }

    public void SetDawnhold()
    {
        GameManager.CountryName = "Dawnhold";
        MoveScene();
    }

    public void SetShadowmere()
    {
        GameManager.CountryName = "Shadowmere";
        MoveScene();
    }

    public void SetValoria()
    {
        GameManager.CountryName = "Valoria";
        MoveScene();
    }

    public void SetHavencrest()
    {
        GameManager.CountryName = "Havencrest";
        MoveScene();
    }
    public void SetFrostholm()
    {
        GameManager.CountryName = "Frostholm";
        MoveScene();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MoveScene()
    {
        loadingScreen.SetActive(true);
        SetPlayerStats();
        loadingScreen.GetComponent<LoadingScreen>().NextScene();
    }

    private void SetPlayerStats()
    {
        // Defines player stats
        level = 1;
        exp = 0;
        maxHP = 20;
        currentHP = maxHP;
        baseDamage = 5;
        baseHeal = 3;

        // Saves player stats
        saveData.PlayerLevel(level);
        saveData.PlayerEXP(exp);
        saveData.PlayerMaxHP(maxHP);
        saveData.PlayerCurrentHP(currentHP);
        saveData.BaseDamge(baseDamage);
        saveData.BaseHeal(baseHeal);
    }
}
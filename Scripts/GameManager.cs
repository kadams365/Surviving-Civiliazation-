using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameData saveData = new GameData();

    public static string CountryName;
    public string countryName;
    //public Text countryText;
    //public Text gameOverText;
    //public Text WinLoseText;

    public GameObject gameOverScreen;

    // Score stuff
    TimeSpan RoundTotalTime;
    DateTime RoundStartTime;
    DateTime RoundEndTime;
    public static int PublicScore;
    private int privateScore;

    private bool Timer;
    private bool win;

    void Start()
    {
        win = true;
        //countryText.text = CountryName;
        StartCoroutine(StartTimer());
        StartTime();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSecondsRealtime(3);
        Timer = true;
    }

    private void StartTime()
    {
        RoundStartTime = DateTime.Now;
    }

    private void GetEndTime()
    {
        RoundEndTime = DateTime.Now;
        RoundTotalTime = RoundEndTime.Subtract(RoundStartTime);
    }

    public void Win()
    {

    }

    public void Update()
    {
        privateScore = PublicScore;
        if (Timer == true)
        {
            //------------------------Lose Check Start------------------------\\

            //------------------------Lose Check End------------------------\\

            //------------------------Win Check Start------------------------\\

            //------------------------Win Check End------------------------\\
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        win = false;
    }

    private void DominationWin()
    {
        //WinLoseText.text = "YOU WIN!";
        //gameOverText.text = "Your nation has dominated all others";
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        CaculateScore();
    }

    private void FindLoserScore()
    {
        //Finding Tech bounus
        //privateScore = +(TechManager.Totalresearch * 100);
        //Finding Building bounus
        //privateScore = +(BusinessManager.TotalBuilding * 100);
        //if (GameMenu.easyPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 100);
        //}
        //if (GameMenu.mediumPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 250);
        //}
        //if (GameMenu.hardPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 500);
        //}
    }

    private void CaculateScore()
    {
        // Finding time bonus
        // x is total seconds in a round
        //int x = (int)RoundTotalTime.TotalSeconds;

        //if (GameMenu.easyPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 100);
        //    privateScore = +1000;
        //    privateScore = easyScore - (x * 2);
        //}
        //if (GameMenu.mediumPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 250);
        //    privateScore = +2000;
        //    privateScore = mediumScore - (x * 2);
        //}
        //if (GameMenu.hardPlay == true)
        //{
        //    privateScore = +(AttackManager.TotalNations * 500);
        //    privateScore = +3000;
        //    privateScore = hardScore - (x * 2);
        //}
        //Finding Tech bounus
    }

    public void Quit()
    {
        Application.Quit();
    }
}
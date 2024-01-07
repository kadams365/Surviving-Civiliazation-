using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //User Data
    public string username = "";
    public int highScore = 0;

    //Player Stats
    public int level;
    public int exp;
    public int maxHP;
    public int currentHP;
    public int baseDamage;
    public int baseHeal;

    //Video Settings
    public bool vsync;
    public bool triplebuffering;
    public bool fps;
    public int antiAliasing;
    public int qualityLevel;

    //Sound Settings
    public float masterVol;
    public float musicVol;
    public float effectsVol;

    public void PlayerLevel(int amount)
    {
        level = amount;
    }

    public void PlayerEXP(int amount)
    {
        exp = amount;
    }

    public void PlayerMaxHP(int amount)
    {
        maxHP = amount;
    }

    public void PlayerCurrentHP(int amount)
    {
        currentHP = amount;
    }

    public void BaseDamge(int amount)
    {
        baseDamage = amount;
    }

    public void BaseHeal(int amount)
    {
        baseHeal = amount;
    }

    public void AddUsername(string name)
    {
        username = name;
    }

    public void HighScore(int score)
    {
        highScore = score;
    }

    public void ChangeVsync(bool toggle)
    {
        vsync = toggle;
    }

    public void ChangeBuffering(bool toggle)
    {
        triplebuffering = toggle;
    }

    public void ChangeFPS(bool toggle)
    {
        fps = toggle;
    }

    public void ChangeAntiAliasing(int score)
    {
        antiAliasing = score;
    }

    public void ChangeQualityLevel(int score)
    {
        qualityLevel = score;
    }

    public void ChangeMasterVolume(float vol)
    {
        masterVol = vol;
    }
    public void ChangeMusicVolume(float vol)
    {
        musicVol = vol;
    }
    public void ChangeEffectsVolume(float vol)
    {
        effectsVol = vol;
    }

    public void ResetData()
    {
        username = "";
        highScore = 0;
        vsync = false;
        triplebuffering = false;
        fps = false;
        antiAliasing = 0;
        qualityLevel = 0;
        masterVol = 0;
        musicVol = 0;
        effectsVol = 0;
        level = 0;
        exp = 0;
        maxHP = 0;
        currentHP = 0;
        baseDamage = 0;
        baseHeal = 0;
    }
}

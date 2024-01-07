using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleStats : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damge;

    public int maxHP;
    public int currentHP;

    GameData saveData = new GameData();

    public void Start()
    {
        saveData = SaveSystem.instance.LoadGame();
        Invoke("LateStart", 0.001f);
    }

    void LateStart()
    {
        unitName = saveData.username;
        unitLevel = saveData.level;
        maxHP = saveData.maxHP;
        currentHP = saveData.currentHP;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;
    public int heal;
    public int chanceofHit = 10;
    public int armour;

    public int maxHP;
    public int currentHP;

    public string skill1;
    public string skill2;
    public string skill3;
    public string skill4;

    GameData saveData = new GameData();

    private void Awake()
    {
        saveData = SaveSystem.instance.LoadGame();
    }

    private void OnEnable()
    {
        if (gameObject.CompareTag("Player"))
        {
            unitLevel = saveData.level;
            unitName = saveData.username;
            maxHP = saveData.maxHP;
            currentHP = saveData.currentHP;
            damage = saveData.baseDamage;
            heal = saveData.baseHeal;
        }

        if (gameObject.name == "Ememy(Clone)")
        {
            //Define level, HP, and damage
            unitName = "Wizard Apprentice";
            unitLevel = Random.Range(unitLevel - 2, unitLevel + 2);
            if (unitLevel <= 0)
            {
                unitLevel = 1;
            }
            maxHP = Random.Range(maxHP - 20, maxHP + 20);
            if (maxHP <= 20)
            {
                maxHP = 20;
            }
            currentHP = maxHP;
            damage = Random.Range(damage - 5, damage + 5);
            if (damage <= 5)
            {
                damage = 5;
            }
            heal = Random.Range(heal - 5, heal + 5);
            if (heal <= 5)
            {
                heal = 5;
            }

            // Defines skills
            AssignMagicSkills();
        }
        if (gameObject.name == "TestEnemy(Clone)")
        {
            unitName = "John";
            unitLevel = Random.Range(unitLevel - 2, unitLevel + 2);
            if (unitLevel <= 0)
            {
                unitLevel = 1;
            }
            maxHP = Random.Range(maxHP - 20, maxHP + 20);
            if (maxHP <= 20)
            {
                maxHP = 20;
            }
            currentHP = maxHP;
            damage = Random.Range(damage - 5, damage + 5);
            if (damage <= 5)
            {
                {
                    damage = 5;
                }
                heal = Random.Range(heal - 5, heal + 2);
                if (heal <= 5)
                {
                    heal = 5;
                }

                // Defines skills
                AssignMeleeSkills();
            }
        }
    }

    private void AssignMagicSkills()
    {
        string[] DamgeSkillList = new string[] { "Magic Missiles", "Fire Ball", "Lighting Bolt"};
        string[] HealSkillList = new string[] { "Lesser Heal", "Heal", "Greater Heal"};
        string[] BuffSkillList = new string[] { "Sheild", "Invisibility", "Haste"};
        int skill = Random.Range(0, DamgeSkillList.Length);
        skill1 = DamgeSkillList[skill];
        skill = Random.Range(0, HealSkillList.Length);
        skill2 = HealSkillList[skill];
        skill = Random.Range(0, BuffSkillList.Length);
        skill3 = BuffSkillList[skill];

        Debug.Log("Skill 1 : " + skill1 + " Skill 2: " + skill2 + " Skill 3: " + skill3);
    }

    private void AssignMeleeSkills()
    {
        string[] DamgeSkillList = new string[] { "Quick Attack", "Normal Attack", "Heavy Attack", "Hidden Blade" };
        string[] HealSkillList = new string[] { "Weapon Sharpen", "Rage", "Grinding Edge" };
        string[] BuffSkillList = new string[] { "Dog", "Parry", "Haste" };
        int skill = Random.Range(0, DamgeSkillList.Length);
        skill1 = DamgeSkillList[skill];
        skill = Random.Range(0, HealSkillList.Length);
        skill2 = HealSkillList[skill];
        skill = Random.Range(0, BuffSkillList.Length);
        skill3 = BuffSkillList[skill];

        Debug.Log("Skill 1 : " + skill1 + " Skill 2: " + skill2 + " Skill 3: " + skill3);
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

    public void Damge()
    {
        if (skill2 == "Weapon Sharpen")
        {
            damage++;
        }
        if (skill2 == "Rage")
        {
            damage = +2;
        }
        if (skill2 == "Grinding Edge")
        {
            damage = +3;
        }
    }

    public void Heal()
    {
        if (skill2 == "Lesser Heal")
        {
            heal++;
        }
        if (skill2 == "Heal")
        {
            heal = +2;
        }
        if (skill2 == "Greater Heal")
        {
            heal = +3;
        }

        currentHP += heal;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void Buff()
    {
        if (skill2 == "Sheild")
        {
            chanceofHit = -1;
        }
        if (skill2 == "Invisibility")
        {
            chanceofHit = -2;
        }
        if (skill2 == "Haste")
        {
            chanceofHit = -3;
        }

        if (chanceofHit <= 1)
        {
            chanceofHit = 1;
        }
    }
}

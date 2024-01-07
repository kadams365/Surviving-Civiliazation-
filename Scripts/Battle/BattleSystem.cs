using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum BattleState { START, PALYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject player;

    //enemies
    public GameObject enemy;
    public GameObject enemyWizard;
    public GameObject enemyTest;

    private int whichenemy;

    public Transform playerBattleSation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI dialogeText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public Button Skill1;
    public Button Skill2;
    public Button Skill3;
    public Button Skill4;

    GameData saveData = new GameData();

    private void Awake()
    {
        saveData = SaveSystem.instance.LoadGame();
    }

    void Start()
    {
        whichenemy = Random.Range(1, 3);
        if(whichenemy == 1)
        {
            enemy = enemyWizard;
        }
        if(whichenemy >= 2)
        {
            enemy = enemyTest;
        }

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(player, playerBattleSation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemy, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogeText.text = "The cities protector " + enemyUnit.unitName + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PALYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //disables skills
        Skill1.interactable = false;
        Skill2.interactable = false;
        Skill3.interactable = false;
        Skill4.interactable = false;

        int attackChance = Random.Range(-10, 20);
        if(attackChance > enemyUnit.chanceofHit)
        {
            dialogeText.text = "You attack but dont do damge.";
            yield return new WaitForSeconds(1f);
        }
        else
        {
            bool isdead = enemyUnit.TakeDamage(playerUnit.damage);
            Debug.Log(playerUnit.damage);

            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogeText.text = "You attack.";

            yield return new WaitForSeconds(1f);

            if (isdead)
            {
                state = BattleState.WON;
                EndBattle();
            }
        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        //disables skills
        Skill1.interactable = false;
        Skill2.interactable = false;
        Skill3.interactable = false;
        Skill4.interactable = false;

        dialogeText.text = enemyUnit.unitName + " turn.";

        yield return new WaitForSeconds(.5f);

        // Enemy AI
        if (enemyUnit.currentHP < enemyUnit.heal - enemyUnit.maxHP)
        {
            //heal Skill2
            enemyUnit.Heal();
            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogeText.text = enemyUnit.unitName + " used " + enemyUnit.skill2 + " gaining some health back.";

        }
        if (playerUnit.currentHP <= enemyUnit.damage)
        {
            //attack Skill1
            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
            playerHUD.SetHP(playerUnit.currentHP);
            Debug.Log(enemyUnit.damage);

            dialogeText.text = enemyUnit.unitName + " used " + enemyUnit.skill1 + " hurting you.";

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.PALYERTURN;
                PlayerTurn();
            }
        }
        else
        {
            //attack, buff, or debuff
            int Whatdo = Random.Range(1, 4);
            if (Whatdo == 1)
            {
                //attack
                //attack Skill1
                bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
                playerHUD.SetHP(playerUnit.currentHP);

                dialogeText.text = enemyUnit.unitName + " used " + enemyUnit.skill1 + " hurting you.";

                if (isDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
            }
            if (Whatdo == 2)
            {
                //buff skill3
                enemyUnit.Buff();
                dialogeText.text = enemyUnit.unitName + " used " + enemyUnit.skill3 + " and is now harder to hit.";
            }
            if (Whatdo >= 3)
            {
                //heal Skill2
                enemyUnit.Heal();
                enemyHUD.SetHP(enemyUnit.currentHP);
                dialogeText.text = enemyUnit.unitName + " used " + enemyUnit.skill2 + " gaining some health back.";
            }
        }

        yield return new WaitForSeconds(1f);

        state = BattleState.PALYERTURN;
        PlayerTurn();
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogeText.text = "You have won the fight.";
            saveData.PlayerMaxHP(playerUnit.maxHP);
            saveData.PlayerCurrentHP(playerUnit.currentHP);
            saveData.PlayerLevel(playerUnit.unitLevel);
        }
        else if (state == BattleState.LOST) {
            dialogeText.text = "You have lost the fight.";
        }
    }

    void PlayerTurn()
    {
        //enables skills
        Skill1.interactable = true;
        Skill2.interactable = true;
        Skill3.interactable = true;
        Skill4.interactable = true;

        dialogeText.text = "Choose an action: ";
    }

    IEnumerator PlayerHeal()
    {
        //disables skills
        Skill1.interactable = false;
        Skill2.interactable = false;
        Skill3.interactable = false;
        Skill4.interactable = false;

        playerUnit.Heal();
        playerHUD.SetHP(playerUnit.currentHP);

        dialogeText.text = "You healed some health back.";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PALYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PALYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }
}

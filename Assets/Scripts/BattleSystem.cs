using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	// ROUND COUNTER
	public int roundCounter;
	public TextMeshProUGUI displayRoundCounter;

	// SPECIFY THESE IN INSPECTOR
	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	// POSITION TO PLACE FIGHTERS 
	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	// CALL UNIT SCRIPT CLASS FOR UNIT INFO (HEALTH, LEVEL, ECT....)
	Unit playerUnit;
	Unit enemyUnit;

	public TextMeshProUGUI dialogueText;

	// VARIABLES TO DISPLAY HUDS 
	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		// BEGIN BATTLE  
		state = BattleState.START;
		StartCoroutine(SetupBattle());
		roundCounter++;
    }

	IEnumerator SetupBattle()
	{
		// SPAWN PLAYER , RETRIEVE PLAYER INFO
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();
        playerGO.GetComponent<Rigidbody2D>().isKinematic = true;


        // SPAWN ENEMY , RETRIEVE ENEMY INFO 
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();
		enemyGO.GetComponent<Rigidbody2D>().isKinematic = true;

		// DISPLAY ENCOUNTER TEXT (MIGHT NOT WANT THIS)
		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		// DISPLAY HUDS
		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		roundCounter = 0;
		displayRoundCounter.text = "0";
		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{

		// PUT MORE EXTENSIVE CODE HERE LATER 


		// ENEMY IS JUST GOING TO ATTACK FOR NOW 
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
            // Round Counter 
            roundCounter++;
            displayRoundCounter.text = roundCounter.ToString();
            state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}

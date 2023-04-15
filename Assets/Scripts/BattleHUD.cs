﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI levelText;
	public Slider hpSlider;

	// DISPLAY UPDATED UNIT INFO WHEN CALLED 
	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
	}

	// DISPLAY UPDATED UNIT HEALTH WHEN CALLED
	// Called when damaged (or healed?) 
	public void SetHP(int hp)
	{
		hpSlider.value = hp;
	}

}
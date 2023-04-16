using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI levelText;
	public Slider hpSlider;
    public TextMeshProUGUI hpText;

    // DISPLAY UPDATED UNIT INFO WHEN CALLED 
    public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
        hpText.text = "HP " + unit.currentHP + " / " + unit.maxHP;

    }


    // DISPLAY UPDATED UNIT HEALTH WHEN CALLED
    // Called when damaged (or healed?) 
    public void SetHP(int hp)
	{
		hpSlider.value = hp;
        hpText.text = "HP " + hp;

    }
}

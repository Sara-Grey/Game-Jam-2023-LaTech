using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public float unitLevel;
    public float yield; 

    public int damage;
    public float difference;
    public float xpMAX;
    public float currentXP;
    public int maxHP;
    public int currentHP; // tracked outside of the fight

    public float firstbit;
    public float lastbit;
    public float product;
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void GainXP(float enemyLevel, float baseYield)
    {
   
        currentXP += baseYield;

        if (currentXP >= xpMAX)
        {
            LevelUp(currentXP);
        }
 
        
    }
    public void LevelUp(float currentXP)
    {
        difference = Mathf.Abs(currentXP - xpMAX);
        unitLevel += 1;
        xpMAX *= 2;
        maxHP *= 2;
        currentHP = maxHP;
        currentXP = difference;
        while (difference >= xpMAX)
        {
            LevelUp(currentXP);
        }
    }
    private void Update()
    {
        if (currentHP <= 0)
        {
            foreach(Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(gameObject);
        }
    }

}

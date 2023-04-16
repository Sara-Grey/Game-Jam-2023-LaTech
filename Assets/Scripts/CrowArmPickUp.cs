using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/CrowArmPickUp")]

// Allows us to make multiple powerup objects with properties we can manipulate in unity editor; We can have variations of the same power up 
public class CrowArmPickUp : Powerup 
{
    // New Jump Limit is initialized in the Unity Editor for the Moon Boots asset 
    public int additional_damage;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Unit>().damage += additional_damage;
        target.GetComponent<Unit>().damage += additional_damage;
        if (target.ToString()[0] == 'P')
        {
            target.GetComponent<Unit>().damage += additional_damage; // Calls the maxJumps variable in the Player class 
        }
    }
}

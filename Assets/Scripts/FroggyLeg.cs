using UnityEngine;

// Allows us to make multiple powerup objects with properties we can manipulate in unity editor; We can have variations of the same power up
[CreateAssetMenu(menuName = "Powerups/MoonBoots")]
 
public class FroggyLeg : Powerup 
{
    // New Jump Limit is initialized in the Unity Editor for the Moon Boots asset 
    public int new_jumpLimit = 2;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().maxJumps = new_jumpLimit;
        target.GetComponent<Player>().jumpsRemaining = new_jumpLimit;
        if (target.ToString()[0] == 'P')
        {
            target.GetComponent<Player>().maxJumps = new_jumpLimit; // Calls the maxJumps variable in the Player class 
        }
    }
}

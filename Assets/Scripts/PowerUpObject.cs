using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// Template to destroy a power up object and apply its effect
// COLIN: Will these effects stack? How will we spawn these effects? 
public class PowerUpObject : MonoBehaviour
{
    public Powerup powerup; // Calls PowerAbstract.cs

    public TextMeshProUGUI pickUpText;
    public bool pickUpAllowed;
    public bool pickedUp;

    private void Start()
    {
        pickedUp = false; 
        pickUpText.gameObject.SetActive(false);
    }
    private void Update()
    {
  
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // make a new paddle game object
            Player player = collision.gameObject.GetComponent<Player>();

            if (player)
            {
                if (pickUpAllowed && Input.GetKeyUp(KeyCode.E))
                {
                    powerup.Apply(player.gameObject);
                    pickedUp = true;
                }
            }
        }  
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

}

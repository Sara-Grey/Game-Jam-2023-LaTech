    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// Template to destroy a power up object and apply its effect
public class PowerUpObject : MonoBehaviour
{
    public Powerup powerup; // Calls PowerAbstract.cs
    public GameObject bodypart;
    public Sprite FrogPart;
    public Sprite ChristmasLight;
    public Sprite DollEyes;
    public Sprite CrowHead;

    public TextMeshProUGUI pickUpText;
    public bool pickUpAllowed;
    public bool pickedUp;
    public bool grabbed = false;
    private void Start()
    {
        pickedUp = false; 
        pickUpText.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (grabbed)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag.StartsWith("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
            if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                powerup.Apply(collision.gameObject);
                grabbed = true;
                pickedUp = true;
            }
            
        }  
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        pickUpText.gameObject.SetActive(true);
        pickUpAllowed = true;
        if (collision.gameObject.transform.tag.StartsWith("Player") && !grabbed && Input.GetKeyDown(KeyCode.E))
        {
            grabbed = true;
            pickedUp = true;

            powerup.Apply(collision.gameObject);
            if (gameObject.transform.tag.EndsWith("Leg"))
            {
                bodypart = GameObject.FindGameObjectWithTag("LeftLeg");
                bodypart.GetComponent<SpriteRenderer>().sprite = FrogPart;
            }
            if (gameObject.name.EndsWith("Arm"))
            {
                bodypart = GameObject.FindGameObjectWithTag("RightArm");
                bodypart.GetComponent<SpriteRenderer>().sprite = CrowHead;
                bodypart.GetComponent<SpriteRenderer>().flipX = true;
                bodypart.GetComponent<SpriteRenderer>().flipY = true;
                bodypart.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
            }
            if (gameObject.name.EndsWith("Eyes"))
            {
                bodypart = GameObject.FindGameObjectWithTag("Eye");
                bodypart.GetComponent<SpriteRenderer>().sprite = DollEyes;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag.StartsWith("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

}

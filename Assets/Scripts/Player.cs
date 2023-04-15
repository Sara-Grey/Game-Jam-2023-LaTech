using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject playerEye;
    [SerializeField] private GameObject playerArm;
    [SerializeField] private GameObject playerLeg;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update(){
        // basic character movement
        moveChar(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        // Save player position outside of fight
    }
    
    void moveChar(Vector2 direction) {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    // not sure what to do with this, can remove
    void jump(Vector2 direction) {
        transform.Translate(direction * jumpForce * Time.deltaTime);
    }

    // prompt player if they want the body part or not, if yes set the corresponding body part to the gameobject 
    void promptPlayer(GameObject part) {
        // check the tags of the "body part" objects, assigns to player if contacted 
        if (part.transform.tag.EndsWith("Eye")){
            playerEye = part;
            part.GetComponent<PowerUp>().Activate();
        }
        else if (part.transform.tag.EndsWith("Arm")){
            playerArm = part;
        }
        else if (part.transform.tag.EndsWith("Leg")){
            playerLeg = part;
        }

    }

    void OnCollisionEnter2D(Collision2D c) {
        // check for collision with a body part
        if (c.gameObject.transform.tag.StartsWith("Body")) {
            promptPlayer(c.gameObject);
        }        

        // Collision with enemy 
    }
}

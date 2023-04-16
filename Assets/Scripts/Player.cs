using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    
    // Game Objects 
    public GameObject EntireBattleSystem;
    public GameObject playeritself;
    public GameObject MainCamera;
    public GameObject BattleCamera;

    // Outside Calls 
    private CharacterController2D charCon;
    public Animator animator;
    public BattleSystem battleCall;
    public BattleState battleState;
    public SaveAndLoad saveLocation;
    public float x, y, z;
    
    public bool movementPaused;

    // Movement Variables (mostly used)
    private float moveDir;
    public bool jump;
    private bool jumpAction = false;
    public bool crouch;
    public int jumpsRemaining;
    public int maxJumps;
    public float speed;
    public bool alive = true;
    private bool up = false;

    // Start Function
    private void Start()
    {
        movementPaused = false;
        CameraSwitch(true, false);
        charCon = GetComponent<CharacterController2D>();
        jump = false;
       
    }
    public void CameraSwitch(bool main, bool battle)
    {
        if (main)
        {
            MainCamera.SetActive(true);

        }
        else if (!main)
        {
            MainCamera.SetActive(false);
        }
        if (battle)
        {
            BattleCamera.SetActive(true);
            EntireBattleSystem.SetActive(true);
        }
        else if (!battle)
        {
            BattleCamera.SetActive(false);
            EntireBattleSystem.SetActive(false);
        }
    }

    public void GetLocation()
    {
        if (!movementPaused)
        {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;

            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", y);
            PlayerPrefs.SetFloat("z", z);
        }
        
    }
    private void Update()
    {
        GetLocation();
        if (battleState == BattleState.WON)
        {
            movementPaused = false;
        }

        if (charCon.IsPlayerOnGround() && !jumpAction)
        {
            jumpsRemaining = maxJumps;
        }
    }

    public bool PlayerCanMove()
    {
        if (movementPaused)
        {
            return false;
        }
        return true;
    }
    private void FixedUpdate()
    {
        if (alive)
        {
            if (charCon.IsPlayerOnGround())
            {
               // animator.SetTrigger("Grounded");
                
            }
            if (PlayerCanMove())
            {
                charCon.Move(moveDir * speed * Time.fixedDeltaTime, crouch, jump);
                jump = false;
            }
            
            //animator.SetFloat("Idle Run", Mathf.Abs(moveDir));
        }
    }

    #region Battle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Enemy"))
        {
            Destroy(collision.gameObject);
            CameraSwitch(false, true);
            battleCall.Start();
            


        }
    }
    #endregion

    #region Movement
    public void LeftRight(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
        
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            up = true;
        }
       
        if (context.canceled)
        {
            up = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0 && context.started)
        {
            jumpsRemaining--;
            jump = true;
            jumpAction = true;
           // animator.SetTrigger("Jump");
            
            charCon.m_Grounded = false;
        }
        if (context.canceled)
        {
            jumpAction = false;
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }
    }
    #endregion


}

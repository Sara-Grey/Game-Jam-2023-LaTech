using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
   
    private float moveDir;

    private CharacterController2D charCon;

    public Animator animator;
    public bool jump;
    private bool jumpAction = false;
    public bool crouch;
    public int jumpsRemaining;
    public int maxJumps;
    public float speed;
    public bool alive = true;
    
    private bool up = false;
    
    private void Start()
    {
        charCon = GetComponent<CharacterController2D>();
        jump = false;
     
    }

    private void Update()
    {
    

        if (charCon.IsPlayerOnGround() && !jumpAction)
        {
            jumpsRemaining = maxJumps;
        }
    }
    private void FixedUpdate()
    {
        if (alive)
        {
            if (charCon.IsPlayerOnGround())
            {
                animator.SetTrigger("Grounded");
                
            }

            charCon.Move(moveDir * speed * Time.fixedDeltaTime, crouch, jump);
            jump = false;
            animator.SetFloat("Idle Run", Mathf.Abs(moveDir));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


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



}

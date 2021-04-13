﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV1 : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    public Animator animator;
    private SpriteRenderer theSR;

  

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded )
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
            
        }

        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        animator.SetFloat("moveSpeed", Mathf.Abs (theRB.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
    }
}
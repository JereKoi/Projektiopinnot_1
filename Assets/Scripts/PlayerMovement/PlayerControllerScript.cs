using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public Animator anim;
    public SpriteRenderer playerSR;

    //public float hangTime = .2f;
    //private float hangCounter = 0f;

    //public float jumpBufferLength = .5f;
    //private float jumpBufferCount;
    public float checkRadius;

    private int extraJumps;
    public int extraJumpsValue = 0;

    //public Transform camTarget;
    //public float aheadAmount, aheadSpeed;

    //public ParticleSystem footsteps;
    //private ParticleSystem.EmissionModule footEmission;

    //public ParticleSystem impactEffect;
    private bool wasOnGround;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        theRB = GetComponent<Rigidbody2D>();
        //footEmission = footsteps.emission;
    }


    void FixeUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Liiku vaakasuunnassa
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,
        theRB.velocity.y);

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            theRB.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            theRB.velocity = Vector2.up * jumpForce;
        }

        //tarkistaa että pelaaja on maassa
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, whatIsGround) || Physics2D.OverlapCircle
        //(groundCheckPoint2.position, whatIsGround);


        //controlloi hangtimea
        //if (isGrounded)
        //{
        //    hangCounter = hangTime;
        //}
        //else
        //{
        //    hangCounter -= Time.deltaTime;
        //}

        //controlloi jump bufferia
        //if(Input.GetButtonDown("Jump"))
        //{
        //    jumpBufferCount = jumpBufferLength;
        //}
        //else
        //{
        //    jumpBufferCount -= Time.deltaTime;
        //}

        //hyppaa ilmaan
        //if (jumpBufferCount >= 0f && hangCounter > 0f)
        //{
        //    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        //    jumpBufferCount = 0f;
        //}

        //if(Input.GetButtonUp("Jump") && theRB.velocity.y > 0)
        //{
        //    theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * .5f);
        //}

        //kaantaa pelaajan
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerSR.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSR.flipX = true;
        }

        //Liikuttaa kameraa
        //if(Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    camTarget.localPosition = new Vector3(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * Input.GetAxisRaw("Horizontal"), 
        //    aheadSpeed * Time.deltaTime), camTarget.localPosition.y, camTarget.localPosition.z);
        //}

        //Nayttaa jalanjalkien effektit
        //if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
        //{
        //    footEmission.rateOverTime = 35f;
        //}
        //else
        //{
        //    footEmission.rateOverTime = 0f;
        //}

        //Nayttaa maahanlaskun effektit
        //if(!wasOnGround && isGrounded)
        //{
        //    impactEffect.gameObject.SetActive(true);
        //    impactEffect.Stop();
        //    impactEffect.transform.position = footsteps.transform.position;
        //    impactEffect.Play();
        //}

        //wasOnGround = isGrounded;

        //asettaa animaatiot
        //anim.SetFloat("xSpeed", Mathf.Abs(theRB.velocity.x));
        //anim.SetBool("grounded", isGrounded);
        //anim.SetFloat("ySpeed", theRB.velocity.y);
    }
}

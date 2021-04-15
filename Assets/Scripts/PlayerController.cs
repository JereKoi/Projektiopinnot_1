using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;

    float mx;
    public static PlayerController instance;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * moveSpeed, theRB.velocity.y);

        theRB.velocity = movement;
    }

}

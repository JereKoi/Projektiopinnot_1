using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_v1 : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("Damage TAKEN !");
    }
}

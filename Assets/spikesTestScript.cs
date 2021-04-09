using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesTestScript : MonoBehaviour
{
    //Lisää tää koodi piikkeihin


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Tägää Pelaaja Unity Enginessä, "Player" + Pelaajan Prefab laita "Overrides"

        if (other.tag == "Player")
        {
            Debug.Log("Hit");

            FindObjectOfType<HealthTestScript>().DealDamage(); //Etsii PlayerHealthController Scriptiä, joka on liitettynä pelaajan Unityn puolella
        }


    }
}

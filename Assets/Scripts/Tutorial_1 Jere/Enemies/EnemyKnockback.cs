using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    //Lisää tää koodi piikkeihin
    private PlayerStats playerStats;
    private PlayerControllerV2 playerController;



    private void OnTriggerEnter2D(Collider2D col)
    {
        //Tägää Pelaaja Unity Enginessä, "Player" + Pelaajan Prefab laita "Overrides"

        if (col.tag == "Player")
        {
            Debug.Log("Hit");

            playerStats = FindObjectOfType<PlayerStats>();
            playerStats.DecreaseHealth(1f);
            playerController = FindObjectOfType<PlayerControllerV2>();
            playerController.Knockback(2);
        }
    }
}

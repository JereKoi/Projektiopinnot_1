using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesTestScript : MonoBehaviour
{
    //Lisää tää koodi piikkeihin
    private PlayerStats playerStats;
    private PlayerControllerV2 playerController;

    public float decreaseHealthAmount = 1f;
    public int knockbackAmount = 2;


    private void OnTriggerEnter2D(Collider2D col)
    {
        //Tägää Pelaaja Unity Enginessä, "Player" + Pelaajan Prefab laita "Overrides"

        if (col.tag == "Player")
        {
            Debug.Log("Hit");

            playerStats = FindObjectOfType<PlayerStats>();
            playerStats.DecreaseHealth(decreaseHealthAmount);
            playerController = FindObjectOfType<PlayerControllerV2>();
            playerController.Knockback(knockbackAmount);
        }
    }
}

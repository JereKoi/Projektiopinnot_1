using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public int healthToGive;

    //public AudioSource pickupSound;

    public PlayerStats PS;

    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControllerV2>() == null)
        {
            return;
        }
        else if ((int)PS.currentHealth == PS.maxHealth)
        {
            return;
        }
        else
        {
            PS.AddHealth();
            //pickupSound.Play();
            gameObject.SetActive(false);
        }        
    }
}

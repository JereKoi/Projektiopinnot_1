using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public int healthToGive;

    public AudioSource pickupSound;

    public PlayerStats PS;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControllerV2>() == null)
        {
            return;
        }
        PS.AddHealth();
        //PS.DecreaseHealth(-healthToGive);
        pickupSound.Play();

        gameObject.SetActive(false);
    }
}

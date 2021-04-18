using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;


    public GameObject[] hearts;
    private int life;


    public float currentHealh;

    private GameManager GM;

    public static float currentHealth { get; internal set; } //tama on testi

    private void Start()
    {
        currentHealh = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        life = hearts.Length;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealh -= amount;
        TakeDamage(1);

        if (currentHealh <= 0.0f)
        {
            Die();
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            CinemachineShake.Instance.shakeCamera(2.5f, .1f);
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}

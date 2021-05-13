using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public AudioSource takeHitSound;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    public HealthBarScript healthbar;
    private GameManager GM;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth((int)(maxHealth));
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthbar.SetHealth((int)currentHealth);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        takeHitSound.Play();


        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void AddHealth()
    {
        if (currentHealth < maxHealth && currentHealth != 0)
        {
            currentHealth += 1;
            healthbar.SetHealth((int)currentHealth);
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.RespawnPlayer();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth((int)(maxHealth));
    }
}

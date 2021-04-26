using UnityEngine;
using UnityEngine.UI;

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


    private float currentHealth;

    private GameManager GM;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        life = hearts.Length;       
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        CinemachineShake.Instance.shakeCamera(4f, .1f);
        TakeDamage(1);

        if (currentHealth <= 0.0f)
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

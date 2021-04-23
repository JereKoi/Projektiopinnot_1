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


    private float currentHealh;

    private GameManager GM;

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

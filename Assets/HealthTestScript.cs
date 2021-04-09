using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTestScript : MonoBehaviour
{
    public static HealthTestScript instance;

    public int currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage()
    {
        Debug.Log("TakeDamage");
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

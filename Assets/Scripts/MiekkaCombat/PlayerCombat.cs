using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform firePosition;
    public GameObject projectile;
    public Transform attackPoint; // Gameobject attackpoint miekkaan että tämä toimii https://www.youtube.com/watch?v=sPiVz1k-fEs
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;

    public float attackRate = 10f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
        if (Time.time > nextFireTime)
        {

            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

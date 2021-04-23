using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;

    private Rigidbody2D rigidbody1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody2D>();
        rigidbody1.velocity = transform.right * projectileSpeed;
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class BossProjectile : MonoBehaviour
{


    // Liitä tää Scripti projectile spirteen Unityn puolella

    public float speed;  //Anna Unityn puolella arvo 5-10

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();  // Tekee pelaajaan lämää
        }



        Destroy(gameObject);
    }
}

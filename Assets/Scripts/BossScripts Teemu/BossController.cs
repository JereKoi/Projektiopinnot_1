using UnityEngine;

public class BossController : MonoBehaviour
{
    // Liitä tämä Script Bossiin ja myöhemmin HitBox objektiin (ehkä?)

    public enum bossStates { shooting, hurt, moving, ended };
    public bossStates currentState;

    public Transform theBoss; //liitä tähän Bossin Sprite Unityn puolella
    public Animator anim; // Unityn puolella myös tähän Bossin sprite (ehkä?)

    [Header("Movement")] //Liikkuu

    public float moveSpeed;            //Tämä Unityn puolella 10-15 (13?)
    public Transform leftPoint, rightPoint; //Luo Unitssa Point objektit joiden väliä Bossi kulkee ja liitä pointit Left- ja Right Pointiin
    private bool moveRight;

    [Header("Shooting")] //Ampuu
    public GameObject bullet;
    public Transform firePoint;     // Klikkaa bossi spriteä Unityssä --> Create New --> Nimeä Fire Point --> Aseta Bossin ampumis kohtaan (käsiin tai ase?) ja liitä tähän.
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")] //Ottaa lämää
    public float hurtTime;    // 1 Sekuntti pitäs olla ok
    private float hurtCounter;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;   //Bossin alku healthi
    public GameObject explosion;
    private bool isDefeated;

    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }

                break;

            case bossStates.hurt:   //Boss defeated

                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;

                    if (hurtCounter <= 0)
                    {
                        currentState = bossStates.moving;

                        if (isDefeated)
                        {
                            theBoss.gameObject.SetActive(false);
                            Instantiate(explosion, theBoss.position, theBoss.rotation);

                            currentState = bossStates.ended;
                        }
                    }
                }

                break;

            case bossStates.moving:

                if (moveRight)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x > rightPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);

                        moveRight = false;

                        EndMovement();

                    }
                }
                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);

                        moveRight = true;

                        EndMovement();

                    }
                }
                break;
        }
    }

    public void TakeHit()
    {
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("hit");

        health--;

        if (health <= 0)
        {
            isDefeated = true;
        }
    }

    //public void TakeHit1()
    //{
    //    currentState = bossStates.hurt;
    //    hurtCounter = hurtTime;

    //    anim.SetTrigger("Hit");
    //}

    private void EndMovement()
    {
        currentState = bossStates.shooting;

        shotCounter = timeBetweenShots;

        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);
    }
}

using Cinemachine;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;

    public GameObject CurrentCheckPoint;
    public GameObject Player;
    public Rigidbody2D PlayerRb;
    public Renderer playersRender;

    public GameObject DeathParticle;
    public GameObject RespawnParticle;
    public float RespawnDelay;
    public int PointPenaltyOnDeath;
    private float GravityStore;


    private bool respawn;

    private CinemachineVirtualCamera CVC;
    private PlayerControllerV2 PCV2;
    private PlayerStats PS;
    private PlayerCombat_V2 PCombat;

    private void Start()
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        PS = GameObject.Find("PlayerCharacterLizard").GetComponent<PlayerStats>();
        PCV2 = FindObjectOfType<PlayerControllerV2>();
        PCombat = FindObjectOfType<PlayerCombat_V2>();
        PlayerRb.GetComponent<Rigidbody2D>();
        playersRender.GetComponent<Renderer>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        //Hide Player
        playersRender.enabled = false;
        PCombat.enabled = false;
        PCV2.dashCooldown = 2f;

        //Generate Death Particle
        Instantiate(DeathParticle, Player.transform.position, Player.transform.rotation);

        //Gravity Reset
        GravityStore = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = Vector2.zero;

        yield return new WaitForSeconds(RespawnDelay);
        //Gravity restore   
        PlayerRb.gravityScale = GravityStore;
        //Enable players render
        playersRender.enabled = true;
        PCombat.enabled = true;

        //Instantiate particles
        Instantiate(RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
        //Respawn player at the current check point
        PCV2.transform.position = CurrentCheckPoint.transform.position;
        Debug.Log("Player Respawned");
    }
}

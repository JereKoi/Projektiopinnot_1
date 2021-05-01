using Cinemachine;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    //[SerializeField]
    //private GameObject player;
    //[SerializeField]
    //private float respawnTime;

    //private float respawnTimeStart;

    public GameObject CurrentCheckPoint;
    public GameObject Player;
    public Rigidbody2D PlayerRb;
    public Renderer playersRender;

    public GameObject DeathParticle;
    public GameObject RespawnParticle;
    //Respawn Delay
    public float RespawnDelay;
    //Point Penalty on Death
    public int PointPenaltyOnDeath;
    //Store Gravity Value
    private float GravityStore;

    private bool respawn;

    private CinemachineVirtualCamera CVC;
    private PlayerControllerV2 PCV2;
    private PlayerStats PS;

    private void Start()
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        PS = GameObject.Find("PlayerCharacterLizard").GetComponent<PlayerStats>();
        PCV2 = FindObjectOfType<PlayerControllerV2>();
        PlayerRb.GetComponent<Rigidbody2D>();
        playersRender.GetComponent<Renderer>();
    }

    private void Update()
    {
        //CheckRespawn();
    }

    //public void Respawn()
    //{
    //    //respawnTimeStart = Time.time;
    //    respawn = true;
    //}

    //private void CheckRespawn()
    //{
    //    if (Time.time >= respawnTimeStart + respawnTime && respawn)
    //    {
    //        var playerTemp = Instantiate(player, respawnPoint);
    //        CVC.m_Follow = playerTemp.transform;
    //        respawn = false;
    //    }
    //}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        //Hide Player
        //PlayerRb.isKinematic = true;
        playersRender.enabled = false;

        //Generate Death Particle
        Instantiate(DeathParticle, Player.transform.position, Player.transform.rotation);
        //Point Penalty
        //  ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Show player
        //PlayerRb.isKinematic = false;

        //Gravity Reset
        GravityStore = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = Vector2.zero;

        yield return new WaitForSeconds(RespawnDelay);
        //Gravity restore   
        PlayerRb.gravityScale = GravityStore;
        //Enable players render
        playersRender.enabled = true;

        //Instantiate particles
        Instantiate(RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
        //Respawn player at the current check point
        //Player.transform.position = new Vector2(CurrentCheckPoint.transform.position.x, CurrentCheckPoint.transform.position.y);
        //Player.transform.position = new Vector2(CurrentCheckPoint.transform.position.x, CurrentCheckPoint.transform.position.y);
        PCV2.transform.position = CurrentCheckPoint.transform.position;
        Debug.Log("Player Respawned");
    }
}

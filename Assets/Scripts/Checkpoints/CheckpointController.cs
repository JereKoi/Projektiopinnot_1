using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite gate;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GM.CurrentCheckPoint = gameObject;
            checkpointSpriteRenderer.sprite = gate;
            checkpointReached = true;
        }
    }
}

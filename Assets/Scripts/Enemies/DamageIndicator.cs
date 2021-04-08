using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public GameObject floatingPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FloatingDamageIndicator
        Instantiate(floatingPoints, transform.position, Quaternion.identity);
    }
}

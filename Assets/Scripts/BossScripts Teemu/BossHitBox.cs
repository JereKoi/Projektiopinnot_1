using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{

    //Liitä tää scripti HitBox nimiseen BossBattlen ala objektiin

    //Liitä HitBox objekti Unityn puolella Boss Battle "Hurt" Hit Box kohtaan

    public BossController bossCont;

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player" && PlayerControllerV2.Instance.transform.position.y > transform.position.y)
    //    {
    //        bossCont.TakeHit();

    //        //PlayerController.instance.Bounce();

    //        gameObject.SetActive(false);
    //    }
    //}


}

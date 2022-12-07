using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
   {
       foreach (var tag in GameSceneManager.instance.bulletTags)
            if (other.transform.CompareTag(tag))
            {
                Destroy(other.gameObject);
                foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(obj);
                    Player.instance.playerValues.Score += Player.instance.playerValues.scorePerHit;
                }
                   
                Destroy(gameObject);
                return;
            }
   }
}

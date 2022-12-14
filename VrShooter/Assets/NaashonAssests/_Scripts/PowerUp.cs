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
                SoundManager.instance.PlaySound("BackOff");
                SoundManager.instance.PlaySound("UsePowerUp");
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

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 80 * Time.deltaTime);  
    }
}

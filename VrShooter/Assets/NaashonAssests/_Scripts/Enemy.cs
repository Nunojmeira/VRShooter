using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct EnemyValues
{
    public float speed;
}
public class Enemy : MonoBehaviour
{
    public EnemyValues values;

    void Start()
    {
        transform.LookAt(Player.instance.transform); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, values.speed * Time.deltaTime, Space.Self);
    }

   void OnCollisionEnter(Collision other)
   {
       foreach (var tag in GameSceneManager.instance.bulletTags)
            if (other.transform.CompareTag(tag))
            {
                SoundManager.instance.PlaySound("EnemyDeath");
                Player.instance.playerValues.Score += Player.instance.playerValues.scorePerHit;
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }
   }
    
}

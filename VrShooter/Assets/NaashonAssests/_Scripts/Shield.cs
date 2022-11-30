using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        foreach (var tag in GameManager.instance.enemyTags)
            if (other.transform.CompareTag(tag))
            {   
                if (Player.instance.playerValues.shield)
                Player.instance.playerValues.health--;
                Destroy(Player.instance.playerValues.shields[Player.instance.playerValues.shields.Count - 1]);
                Player.instance.playerValues.shields.RemoveAt(Player.instance.playerValues.shields.Count - 1);
                return;
            }            
    }
}

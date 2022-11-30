using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        foreach (var tag in GameManager.instance.enemyTags)
            if (other.transform.CompareTag(tag))
            {
                Player.instance.playerValues.Score += Player.instance.playerValues.scorePerHit;
                return;
            }
    }
}

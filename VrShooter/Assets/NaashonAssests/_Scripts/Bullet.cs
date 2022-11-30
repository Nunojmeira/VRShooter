using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeBeforeDespawn;
    float timer = 0f;
    void OnCollisionEnter(Collision other)
    {
        foreach (var tag in GameManager.instance.enemyTags)
            if (other.transform.CompareTag(tag))
            {
                Player.instance.playerValues.Score += Player.instance.playerValues.scorePerHit;
                return;
            }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > timeBeforeDespawn)
            Destroy(gameObject);
    }
}

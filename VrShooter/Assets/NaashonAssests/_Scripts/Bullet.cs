using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeBeforeDespawn;
    float timer = 0f;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > timeBeforeDespawn)
            Destroy(gameObject);
    }
}

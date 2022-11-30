using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public void Shoot(ref ShootingVariables values)
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<Rigidbody>().velocity = values.handTransform.forward * values.bulletForce;
        values.timeSinceLastShot = 0;
    }
}

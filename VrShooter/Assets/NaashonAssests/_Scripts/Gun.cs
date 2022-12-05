using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    public void Shoot(ref ShootingVariables values)
    {
        var pos = transform.position;
        pos.z += 0.5f;
        pos.y += 0.5f;
        var bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.transform.SetParent(GameSceneManager.instance.expApp.transform);
        bullet.GetComponent<Rigidbody>().velocity = values.handTransform.forward * values.bulletForce;
        values.timeSinceLastShot = 0;
    }

    void Update()
    {
        transform.forward = Player.instance.shootingValues.handTransform.forward;
    }
}

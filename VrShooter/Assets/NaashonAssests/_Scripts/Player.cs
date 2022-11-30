using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Liminal.SDK;
using Liminal.SDK.VR.EventSystems;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using TMPro;

[Serializable]
public struct ShootingVariables
{
    public Gun gun;
    public Transform handTransform;
    public float bulletForce;
    public float timeBetweenShots;
    public float timeSinceLastShot;
}

[Serializable]
public struct PlayerVariables
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] string DisplayText;
    public int health;
    public int scorePerHit;
    public GameObject shield;
    public Vector3 startPoint;
    [HideInInspector] public List<GameObject> shields;

    public int Score { get => score; set { score = value; scoreText.text = DisplayText + '\n' + value.ToString(); } }
}

public class Player : MonoBehaviour
{
    public ShootingVariables shootingValues;
    public PlayerVariables playerValues;
    public static Player instance;
    //public IVRDevice device;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
       

    }
    void Start()
    {
        Vector3 vec = playerValues.startPoint;
        for (int i = 0; i < playerValues.health; i++)
        {
            vec.x += 0.5f;
            playerValues.shields.Add(Instantiate(playerValues.shield, vec, Quaternion.identity));
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        shootingValues.timeSinceLastShot += Time.deltaTime;

        if (shootingValues.timeSinceLastShot >= shootingValues.timeBetweenShots &&
            VRDevice.Device.GetButtonDown(VRButton.Trigger))
            shootingValues.gun.Shoot(ref shootingValues);
            
    }




}

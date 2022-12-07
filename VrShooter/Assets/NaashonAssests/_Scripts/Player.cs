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
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] string DisplayText;
    public int startingHealth;
    int health;
    public int scorePerHit;
    public GameObject shield;
    public Vector3 startPoint;
    public float offset;
    [HideInInspector] public List<GameObject> shields;

    public int Score { get => score; set { score = value; scoreText.text = DisplayText + '\n' + score.ToString(); } }
    public int Health { get => health; set
        {
            var temp = health;
            int it;
            health = value;
            if (health < temp)
            {
                it = temp - health;
                temp = -1;
                SoundManager.instance.PlaySound("HealthLoss");
            }
            else
            {
                it = health - temp;
                temp = 1;
            }

            if (value == 0)
            {
                for (int i = 0; i < shields.Count; i++)
                    GameManager.Destroy(shields[i]);
                shields.Clear();
                //GameManager.instance.gameState = GameState.Gameover;
                return;
            }

            for (int i = 0; i < it; i++)
            {
                if (temp < 0 && shields.Count > 0)
                {
                    GameManager.Destroy(shields[shields.Count - 1]);
                    shields.RemoveAt(shields.Count - 1);
                }
                else if (temp > 0 && shields.Count < startingHealth)
                {
                    var vec = startPoint;
                    vec.x += offset * shields.Count;
                    var obj = GameManager.Instantiate(shield, vec, Quaternion.identity);
                    obj.transform.SetParent(GameSceneManager.instance.expApp.transform);
                    shields.Add(obj);
                }
            }

            if (shields.Count <= 0)
            {
                GameManager.instance.gameState = GameState.Gameover;
                return;
            }
        } 
    }
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
        playerValues.Health = playerValues.startingHealth;
        playerValues.Score = playerValues.Score;
        EventManager.OnGameOverEnd += OnGameOverEnd;

    }

    void OnGameOverEnd()
    {
        playerValues.Health = playerValues.startingHealth;
        playerValues.Score = 0;
        shootingValues.timeSinceLastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        shootingValues.timeSinceLastShot += Time.deltaTime;

        if (shootingValues.timeSinceLastShot >= shootingValues.timeBetweenShots &&
            (VRDevice.Device.GetButtonDown(VRButton.Trigger) || Input.GetMouseButtonDown(0)))
            shootingValues.gun.Shoot(ref shootingValues);
            
    }

    void OnTriggerEnter(Collider collider)
    {
        foreach (var tag in GameSceneManager.instance.enemyTags)
            if (collider.CompareTag(tag))
            {
                Destroy(collider.gameObject);
                playerValues.Health--;
                return;
            }     
    }
}

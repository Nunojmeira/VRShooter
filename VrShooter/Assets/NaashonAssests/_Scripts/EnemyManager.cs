using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct SpawnVariables
{
    public float timeBetweenSpawns;
    public float spawnsBetweenSpawnSpeedUp;
    public float timeBetweenEnemySpeedUp;
    public int cyclesBetweenSpawnsPerCycleIncrease;

    [Range(0.01f, 0.9f)]
    public float speedTimeIncreasePercentage;
    [Range(0.01f, 0.9f)]
    public float spawnTimeDecreasePercentage;
    [Range(1.01f, 2f)]
    public float speedIncreasePerCycle;
    public int spawnsPerCycle;

    public int maxSpawnsPerCycle;
    public float maxSpeed;
    public float minTimeBetweenSpawns;
    public float minTimeBetweenEnemySpeedUp;

    public string DisplayText;


    public Vector3 BottomBackLeftBound;
    public Vector3 TopFrontRightBound;

}
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public SpawnVariables spawnVariables;
    public EnemyValues enemyValues;

    float timeBetweenSpawns = 0;
    float spawnsBetweenSpawnSpeedUp = 0;
    float timeBetweenEnemySpeedUp = 0;
    int spawnCycles = 0;
    int spawns = 0;

    [SerializeField] bool checkForSpawnOverlapping = true;



    [SerializeField] GameObject enemyPrefab;
    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeBetweenSpawns += Time.fixedDeltaTime;
        timeBetweenEnemySpeedUp += Time.fixedDeltaTime;
        
        if (timeBetweenEnemySpeedUp >= spawnVariables.timeBetweenEnemySpeedUp)
        {
            spawnVariables.timeBetweenEnemySpeedUp *=  (1 - spawnVariables.speedTimeIncreasePercentage);
            spawnVariables.timeBetweenEnemySpeedUp = Mathf.Max(spawnVariables.timeBetweenEnemySpeedUp, spawnVariables.minTimeBetweenEnemySpeedUp);
            enemyValues.speed *= spawnVariables.speedIncreasePerCycle;
            enemyValues.speed = Mathf.Min(enemyValues.speed, spawnVariables.maxSpeed);
            timeBetweenEnemySpeedUp = 0;
        }
        if (timeBetweenSpawns >= spawnVariables.timeBetweenSpawns)
        {
            for (int i = 0; i < spawnVariables.spawnsPerCycle; i++)
            {
                Vector3 spawnPos = new Vector3(
                 Random.Range(spawnVariables.BottomBackLeftBound.x, spawnVariables.TopFrontRightBound.x),
                 Random.Range(spawnVariables.BottomBackLeftBound.y, spawnVariables.TopFrontRightBound.y),
                 Random.Range(spawnVariables.BottomBackLeftBound.z, spawnVariables.TopFrontRightBound.z)
                 );
                if (checkForSpawnOverlapping)
                {
                    bool redo = false;
                    foreach (var collider in Physics.OverlapBox(spawnPos, transform.localScale / 2))
                    {
                        if (!collider.CompareTag(tag)) continue;

                        i--;
                        redo = true;
                        break;
                    }
                    if (redo) continue;
                }

                var obj = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                obj.transform.SetParent(GameSceneManager.instance.expApp.transform);
                obj.GetComponent<Enemy>().values.speed = enemyValues.speed; 
            }

            ++spawnCycles;
            ++spawns;
            if (spawns >= spawnVariables.spawnsBetweenSpawnSpeedUp)
            {
                spawnVariables.timeBetweenSpawns *= (1 - spawnVariables.spawnTimeDecreasePercentage);
                spawnVariables.timeBetweenSpawns = Mathf.Max(spawnVariables.timeBetweenSpawns, spawnVariables.minTimeBetweenSpawns);
                spawns = 0;
            }

            if (spawnCycles >= spawnVariables.cyclesBetweenSpawnsPerCycleIncrease)
            {
                spawnVariables.spawnsPerCycle++;
                spawnVariables.spawnsPerCycle = Mathf.Min(spawnVariables.spawnsPerCycle, spawnVariables.maxSpawnsPerCycle);
                spawnCycles = 0;
            }

            timeBetweenSpawns = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public List<string> enemyTags = new List<string>();
    public List<string> bulletTags = new List<string>();
    public GameObject expApp;
    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }


}

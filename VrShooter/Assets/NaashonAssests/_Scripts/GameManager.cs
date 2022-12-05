using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Gameplay,
    Gameover
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameState state = GameState.Gameplay;
    public GameState gameState { get => state; set { EventManager.ChangeStateEnd(); state = value; EventManager.ChangeStateBegin(); } }
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}

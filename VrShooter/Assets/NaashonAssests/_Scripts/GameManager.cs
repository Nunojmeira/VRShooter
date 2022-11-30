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
    public List<string> enemyTags = new List<string>();
    GameState state = GameState.Gameplay;
    public GameState gameState { get => state; set{ EventManager.ChangeStateEnd(); state = value; EventManager.ChangeStateBegin(state); } }
    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void GameEvent();

    static public event GameEvent OnGameOverStart;
    static public event GameEvent OnGameOverEnd;
    static public event GameEvent OnGamePlayStart;
    static public event GameEvent OnGamePlayEnd;

    public static void ChangeStateEnd()
    {
        switch (GameManager.instance.gameState)
        {
            case GameState.Gameplay:
                OnGamePlayEnd?.Invoke();
                break;
            case GameState.Gameover:
                OnGameOverEnd?.Invoke();    
                break;
        }
    }

    public static void ChangeStateBegin()
    {
        switch (GameManager.instance.gameState)
        {
            case GameState.Gameplay:
                OnGamePlayStart?.Invoke();
                break;
            case GameState.Gameover:
                OnGameOverStart?.Invoke();
                break;
        }
    }
}

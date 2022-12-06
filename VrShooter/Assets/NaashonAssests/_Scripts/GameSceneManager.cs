using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public List<string> enemyTags = new List<string>();
    public List<string> bulletTags = new List<string>();
    public GameObject expApp;
    public GameObject UI_Button;
    public string displayText;
    [SerializeField] TextMeshPro timeText;
    float timeAlive;

    public float TimeAlive { get => timeAlive; set { timeAlive = value; timeText.text = displayText + '\n' + SecondsToTime(timeAlive);  } }

    static public string SecondsToTime(float time)
    {
        float hr = time * 0.0002777778f;
        int hours = ((int)hr);
        float minutes = hr - (float)hours;
        minutes *= 60;
        float remainder = minutes - (float)((int)minutes);
        int mins = (int)minutes;
        int secs = (int)(remainder * 60f);
        string h = hours.ToString();
        string m = mins.ToString();
        string s = secs.ToString();
        if (s.Length < 2) s = s.Insert(0, "0");
        if (m.Length < 2) m = m.Insert(0, "0");
        if (h.Length < 2) h = h.Insert(0, "0");
        return h + ":" + m + ":" + s;
    }

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        TimeAlive = 0;
        SoundManager.instance.PlayRandomSong();
        EventManager.OnGameOverStart += OnGameOver;
        EventManager.OnGameOverEnd += OnGameOverEnd;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
            TimeAlive += Time.fixedDeltaTime;
    }

    void OnGameOver()
    {
        UI_Button.SetActive(true);
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            Destroy(enemy);
    }


    void OnGameOverEnd()
    {
        UI_Button.SetActive(false);
        TimeAlive = 0;
    }

}

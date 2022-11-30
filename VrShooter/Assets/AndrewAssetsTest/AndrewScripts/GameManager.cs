using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private variables
    private int _killscore;
    private int _highscore;

    //serialized variables
    [SerializeField] private GameObject livesHolo;
    [SerializeField] private List<GameObject> livesHoloDeck = new List<GameObject>();
    [SerializeField] private List<Transform> holoPoints = new List<Transform>();
    [SerializeField] private TMP_Text scoreText;
    

    //public variables
    public static GameManager Instance;//Instance of GameManager

    private void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SpawnHealth();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: \n"+_highscore.ToString();
    }


    void SpawnHealth()
    {
        for (int i = 0; i < 3; ++i)
        {
            livesHoloDeck.Add(Instantiate(livesHolo, holoPoints[i].position, Quaternion.identity));
        }
    }

    void DespawnHealth()
    {
        livesHoloDeck.Remove(livesHoloDeck[livesHoloDeck.Count - 1]);
    }
}

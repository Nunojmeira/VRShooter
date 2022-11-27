using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //private variables
    private int _killscore;
    private int _highscore;

    //serialized variables
    [SerializeField] private GameObject livesHoloDeck;
    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

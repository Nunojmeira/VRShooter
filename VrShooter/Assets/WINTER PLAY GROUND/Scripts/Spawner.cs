using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject OBJ;
    [SerializeField] private float spwTime = 5;
    [SerializeField] private float spwPosXmin;
    [SerializeField] private float spwPosXmax;
    [SerializeField] private float spwPosYmin;
    [SerializeField] private float spwPosYmax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        spwTime -= Time.deltaTime;
        if(spwTime <= 0)
        {
            float spwPosX = Random.RandomRange(spwPosXmin, spwPosXmax);
            float spwPosY = Random.RandomRange(spwPosYmin, spwPosYmax);
            Vector3 pos = new Vector3(spwPosX, spwPosY, 18f);

            Instantiate(OBJ, pos, Quaternion.identity);
            spwTime = 4;
        }
    }
}

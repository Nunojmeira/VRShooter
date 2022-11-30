using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _rotate = new Vector3( 0.0f, 1.0f, 0.0f );
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotate);
    }
}

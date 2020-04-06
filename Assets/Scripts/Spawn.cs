using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    Transform enemy;

    Transform start;
    float time;
    void Start()
    {   
        time=Time.time;
        GameObject.Instantiate(enemy,start.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

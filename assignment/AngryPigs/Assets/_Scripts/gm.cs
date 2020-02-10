using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gm : MonoBehaviour
{
    public GameObject Canon;
    public GameObject Camera;
    public int enemyCount;
    public int shotAttempt = 3;

    public int getLife()
    {
        return shotAttempt;
    }

    //public void downLife()
    //{
    //    shotAttempt = shotAttempt - 1;
    //}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

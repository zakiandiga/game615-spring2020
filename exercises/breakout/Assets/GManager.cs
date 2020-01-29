using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public int lifePoints = 3;
    public int blocks = 15;
    public bool gameover;
    public bool win;
    public lifepoints lp;
    

    void Start()
    {
        lp = GameObject.Find("lifepoints").GetComponent<lifepoints>();
    }


    void Update()
    {
        lp.lPoints = lifePoints;

        if (lifePoints < 1)
        {
            gameover = true;
        }
        
        if (blocks < 1)
        {
            win = true;
        }
    }
}

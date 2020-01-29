using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public int lifePoints = 3;
    public int blocks = 15;
    public lifepoints lp;
    public GameObject go;
    public GameObject youwin;
    

    void Start()
    {
        lp = GameObject.Find("lifepoints").GetComponent<lifepoints>();
    }


    void Update()
    {
        lp.lPoints = lifePoints;

        if (lifePoints < 1)
        {
            go.SetActive(true);
        }
        
        if (blocks < 1)
        {
            youwin.SetActive(true);
        }
    }
}

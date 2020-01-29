using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifepoints : MonoBehaviour
{
    Text txt;
    public int lPoints = 3;
    
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Lives: " + lPoints;
    }

    void Update()
    {
        txt.text = "Lives: " + lPoints;
    }
}
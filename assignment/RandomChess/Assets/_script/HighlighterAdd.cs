using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlighterAdd : MonoBehaviour
{
    public GameObject baseCube;
    void Start()
    {
        for(int i = 0; i < 8; i++)
        { 
            for (int j = 0; j < 8; j++)
            {
                GameObject square = Instantiate(baseCube, transform);
                square.transform.position = new Vector3(i * 2-7, 1.8f, j * 2-7);
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0);
            }
        }
        //Destroy(baseCube);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    
    void OnCollisionEnter()
    {
        Destroy(gameObject);
        //instantiate(particle, transform~~~
        //blockLeft = -1;

    }
}

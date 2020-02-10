using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject Piggy;
    public gm enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.Find("gm").GetComponent<gm>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            enemyCount.enemyCount--;
            Destroy(gameObject,3);
        }
            
    }
        
        

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject Piggy;
    public GameObject EnemyExplosion;
    public Transform Explosion;
    public gm enemyCount;
    public int HP = 5;
    public bool isExploding = false;
    int exploTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.Find("gm").GetComponent<gm>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1 && isExploding == false)
        {
            Invoke("EnemyExplode", exploTime);
            //isExploding = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        HP--;
        //if (HP <1)
        //if (col.gameObject.name == "Player")
        //{
        //    enemyCount.enemyCount--;
        //    Destroy(gameObject,3);
        //}
            
    }

    void EnemyExplode()
    {
        Debug.Log("Bird explosion activated!");
        EnemyExplosion.SetActive(true);
        Instantiate(Explosion, transform.position, Quaternion.identity, transform.parent);
        //gameObject.SetActive(false);
        enemyCount.enemyCount--;
        //Destroy(gameObject);
        //Invoke("ExplosionInit", exploTime);
        isExploding = true;
        
    }


}

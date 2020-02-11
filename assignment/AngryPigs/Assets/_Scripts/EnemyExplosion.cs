using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public GameObject Enemy;
    float desTime = 0.5f;
    public ScoreManager scoreManager;

    void Start()
    {
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void Update()
    {
        scoreManager.EnemyDead();
        //Debug.Log("Score added:" + scoreManager.getScore());
        Destroy(gameObject, desTime);
        Destroy(Enemy);

    }

}
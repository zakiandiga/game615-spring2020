using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyExplode : MonoBehaviour
{
    public GameObject Player;
    float desTime = 0.5f;

    void Start()
    {
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void Update()
    {
        Destroy(gameObject, desTime);
    }
    // Update is called once per frame
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Piggy")
    //    {
    //        Physics.IgnoreCollision(Player.collider, collider);
    //    }
    //}
}

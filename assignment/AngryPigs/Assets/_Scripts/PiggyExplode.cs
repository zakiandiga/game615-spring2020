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

}

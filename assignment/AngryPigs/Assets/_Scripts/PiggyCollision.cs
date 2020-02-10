using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyCollision : MonoBehaviour
{
public ScoreManager scoreManager;
const int resetTime = 3;
Vector3 originalPosition;
Transform parent;

void Start()
{
    originalPosition = transform.localPosition;
    parent = transform.parent;
}

void OnCollisionEnter2D(Collision2D collision)
{
    Invoke("ResetPiggy", resetTime);
    if (collision.gameObject.tag != "Floor")
    {
        scoreManager.PiggyStructure();
        //Debug.Log("Current score: " + scoreManager.getScore());
    }
}

void ResetPiggy()
{
    GetComponent<Rigidbody2D>().gravityScale = 0;
    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    GetComponent<Rigidbody2D>().angularVelocity = 0;
    transform.parent = parent;
    transform.localPosition = originalPosition;
    Camera.main.GetComponent<CameraFollow>().resetCameraPosition();
}
}
//ASK KRYSTOF ABOUT PIG RUN THROUGH COLLISION

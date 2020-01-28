using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float paddleSpeed = 1f;
    public float leftEdge = -2.43f;
    public float rightEdge = 2.43f;
    public float deviation = 400f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveLeft) && transform.position.x > leftEdge)
        {
            transform.position = new Vector3(transform.position.x - paddleSpeed, transform.position.y, 0);
        }
        if (Input.GetKey(moveRight) && transform.position.x < rightEdge)
        {
            transform.position = new Vector3(transform.position.x + paddleSpeed, transform.position.y, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == GetComponent<BoxCollider>())
            {
                float calc = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody>().AddForce(deviation * calc, 0, 0);
            }
        }
    }
}

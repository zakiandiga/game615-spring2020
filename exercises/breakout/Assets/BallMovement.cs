using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public KeyCode Launch;
    public bool IsRunning;
    public float magnitudeMod = 400f;
    public float xforceMod = 0;
    public GManager progress;
    


    void launchball()
    {
        //transform.position = new Vector3(0, 0, 0); //reset ball position when die
        transform.parent = null;
        IsRunning = true;
        GetComponent<Rigidbody>().isKinematic = false;
        float forceX = Random.Range(-0.5f, 0.5f);
        float forceY = 0.5f;
        float magnitude = magnitudeMod;
        float xforceModB = xforceMod * -1;
        float rangeX = Random.Range(xforceMod, xforceModB);

        //Vector3 force = new Vector3(forceX, forceY, 0);
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //GetComponent<Rigidbody>().AddForce(force * magnitude);

        GetComponent<Rigidbody>().AddForce(new Vector3(rangeX, magnitudeMod, 0));
    }

    void start()
    {
        progress = GameObject.Find("GManager").GetComponent<GManager>();
    }


    void Update()
    {
        if (Input.GetKey(Launch) && IsRunning == false)
        {
            launchball();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BottomWall")
        {
            progress.lifePoints--;
            Destroy(gameObject);
        }
    }
}
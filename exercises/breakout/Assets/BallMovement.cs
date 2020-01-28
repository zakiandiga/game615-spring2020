using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //public float BallSpeed = 500f;
    public KeyCode Launch;
    public bool IsRunning;
    public float magnitudeMod = 400f;
    void launchball()
    {

        //transform.position = new Vector3(0, 0, 0); //reset ball position when die
        transform.parent = null;
        IsRunning = true;
        GetComponent<Rigidbody>().isKinematic = false;
        float forceX = Random.Range(-0.5f, 0.5f);
        float forceY = 0.5f;
        float magnitude = magnitudeMod;
      
        //Vector3 force = new Vector3(forceX, forceY, 0);

        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //GetComponent<Rigidbody>().AddForce(force * magnitude);
        GetComponent<Rigidbody>().AddForce(new Vector3(magnitudeMod, magnitudeMod, 0));
        
        
        

    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Launch) && IsRunning == false)
        {
            launchball();
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Paddle")
    //    {
    //        GetComponent<Rigidbody>().AddForce(new Vector3((Random.Range()))
    //    }


    //}
}

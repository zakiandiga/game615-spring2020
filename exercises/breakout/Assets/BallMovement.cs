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
    public GameObject player;
    public Transform parent;
    
    public GameObject lose; //not used yet
    public GameObject win;  //not used yet


    void launchball()
    {
        transform.parent = null;
        IsRunning = true;
        GetComponent<Rigidbody>().isKinematic = false;
        float forceX = Random.Range(-0.5f, 0.5f);
        float forceY = 0.5f;
        float magnitude = magnitudeMod;
        float xforceModB = xforceMod * -1;
        float rangeX = Random.Range(xforceMod, xforceModB);

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
            player.transform.SetParent(parent);
            transform.position = new Vector3(parent.position.x, (parent.position.y + 0.2f), 0);
            IsRunning = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
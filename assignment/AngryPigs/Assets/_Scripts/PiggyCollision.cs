using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public gm gameManager;
    const int resetTime = 8;
    const int exploTime = 4;
    Vector3 originalPosition;
    Transform parent;
    public Transform Explosion;
    bool isExploding = false;    
    public GameObject PiggyExplosion;


    void Start()
    {
        originalPosition = transform.localPosition;
        parent = transform.parent;
        //Explosion = transform.Explosion;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (isExploding == false)
        {
            Invoke("PiggyExplode", exploTime);
            Invoke("ResetPiggy", resetTime);

            isExploding = true;
        }
        
        

        if (collision.gameObject.tag != "Floor")
        {
            scoreManager.PiggyStructure();
            
        }
    }

    void ResetPiggy()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<BoxCollider2D>().enabled = false;   //THIS deactivate the piggy to collide before launched (in case there are any object nearby)
        gameObject.SetActive(true);
        PiggyExplosion.SetActive(false);
        transform.parent = parent;
        transform.localPosition = originalPosition;
        gameManager.shotAttempt--;  //Shot attempt spent!
        //Camera.main.GetComponent<CameraFollow>().resetCameraPosition();
        isExploding = false;
    }

    void PiggyExplode()
    {
        //Debug.Log("explosion activated!");
        PiggyExplosion.SetActive(true);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        //gameManager.shotAttempt--;
    }

}
//Ask about piggies run through small collision 

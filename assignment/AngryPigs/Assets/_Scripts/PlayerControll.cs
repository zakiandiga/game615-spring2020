using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public KeyCode Fire;
    public GameObject piggy;
    public float power = 50f;
    private Rigidbody2D piggyBody;
    public gm gameManager;
    private BoxCollider2D piggyCollide;
         
    void Start()
    {
        piggyBody = piggy.GetComponent<Rigidbody2D>();
        piggyBody.gravityScale = 0;
        piggyCollide = piggy.GetComponent<BoxCollider2D>();
        //cameraPos = GetComponent<Camera>();           
    }




    void Update()
    {
        //if (cameraPos.transform.position.z < 0)
        //{
        //    cameraZ = 0;
        //}
        //else
        //{
        //    cameraZ = cameraPos.transform.position.z;
        //}

        Vector3 mousePointOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePointOnScreen);
        Vector3 direction = mouseInWorld - transform.position;


        float cosAlpha = Vector3.Dot(Vector3.right, direction.normalized); 

        float alpha = Mathf.Acos(cosAlpha);

        transform.rotation = Quaternion.Euler(0, 0, alpha); //*Mathf.Rad2Deg

        if (Input.GetKey(Fire) && piggy.transform.parent && gameManager.shotAttempt > 0) 
        {
            piggy.transform.parent = null;
            piggyBody.gravityScale = 1;
            piggyBody.AddForce(direction * power);
            piggyCollide.enabled = true;  //THIS activate the piggy's collider!

        }

    }
}

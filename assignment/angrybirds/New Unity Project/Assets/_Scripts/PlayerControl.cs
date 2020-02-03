using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject piggy;
    public float power = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePointOnScreen = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //Debug.Log(mouseinWorld);
        Vector3 mouseinWorld = Camera.main.ScreenToWorldPoint(mousePointOnScreen);
        Vector3 direction = mouseinWorld - transform.position;

        float cosAlpha = Vector3.Dot(new Vector3(1, 0, 0), direction.normalize);
        float alpha = Mathf.ACos(cosAlpha);
        transform.rotation = Quaternion.Euler(0, 0, alpha * Mathf.Rad2Deg);

        if (input.GetButtonDown("Fire"))
        {
            piggy.GetComponent<Rigidbody2D>().AddForce(direction*power);
        }
        
    }
}

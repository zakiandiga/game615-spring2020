using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject piggy;
    public float power = 50f;
    private Rigidbody2D piggyBody;
    // Start is called before the first frame update
    void Start()
    {
        piggyBody = piggy.GetComponent<Rigidbody2D>();
        piggyBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse point on screen is read from Input and by moving to 0 on z axis from the camera position
        Vector3 mousePointOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePointOnScreen);
        Vector3 direction = mouseInWorld - transform.position;

        // to find an angle between two vectors, you need to calculate the Dot product between the NORMALIZED vetors.
        // and retrieve the angle from the dot product, by calculating arccosine of it

        float cosAlpha = Vector3.Dot(Vector3.right, direction.normalized); 



        float alpha = Mathf.Acos(cosAlpha);

        transform.rotation = Quaternion.Euler(0, 0, alpha*Mathf.Rad2Deg);

        if (Input.GetButtonDown("Fire1")) 
        {
            piggy.transform.parent = null;
            piggyBody.gravityScale = 1;
            piggyBody.AddForce(direction*power);
        }

    }
}

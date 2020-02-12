using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform piggy;
    public Vector3 originalPos;
    public Camera cam;
    public float ZoomA = 5f;
    public float ZoomB = 8f;
    public float ZoomT = 0f;
    bool isOpening = true;
    //public Transform came;
    //public float smoothT = 0.3f;
    //public float posZ = -10;
    //private Vector3 velocity = Vector3.zero;


    //public orthographicSize cams;
    //private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        cam.orthographic = true;
        cam.orthographicSize = 5f;
        
    }


    void Update()
    {
        //if (isOpening == true)
        //{
        //    Vector3 targetPos = came.TransformPoint(new Vector3(0, 0, posZ));
        //    Vector3 desiredPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothT);
        //}

        //if (isOpening == true)
        //{
        //    Vector3 startPos = new Vector3 (defaultPos.x, defaultPos.y, defaultPos.z); 
        //    transform.position = Vector3.Lerp(originalPos, startPos, Time.deltaTime);
        //}
        //if (transform.position == defaultPos)
        //{
        //    isOpening = false;
        //}


        if (piggy.parent == null)  // &&isOpening == false)
        {
            Vector3 newPosition = new Vector3(piggy.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition,Time.deltaTime);
            float t =+ ZoomT;
            cam.orthographicSize = Mathf.SmoothStep(ZoomA, ZoomB, t);  //Camera doesn't gradually zoom!!
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime);
            cam.orthographicSize = 5f;
        }
    }

    public void resetCameraPosition()
    {
        transform.position = originalPos;
        cam.orthographicSize = 5f;
    }
}

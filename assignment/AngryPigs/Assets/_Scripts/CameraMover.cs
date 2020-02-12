using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform cam;
    public float smoothT = 0.3f;
    public float posZ = -10;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = cam.TransformPoint(new Vector3(0, 0, posZ));
        Vector3 desiredPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothT);

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform piggy;
    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (piggy.parent == null)
        {
            Vector3 newPosition = new Vector3(piggy.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition,Time.deltaTime);
            
        }
    }

    public void resetCameraPosition()
    {
        transform.position = originalPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    public GManager blockDestroy;

    void Start()
    {
        blockDestroy = GameObject.Find("GManager").GetComponent<GManager>();
    }
    void OnCollisionEnter()
    {
        blockDestroy.blocks--;
        Destroy(gameObject);
    }
}

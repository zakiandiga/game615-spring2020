﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Transform[,] chessboard = new Transform [8,8];
    public GameObject baseCube;
    public Transform boardParent;
    public Transform chessPiece;
    const int SQUARE_SIZE = 2;

    void Start()
    {
        for(int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                
                GameObject square = Instantiate(baseCube, boardParent);
                square.GetComponent<SquareInfo>().i = i;
                square.GetComponent<SquareInfo>().j = j;
                square.transform.position = new Vector3(i * SQUARE_SIZE - SQUARE_SIZE * 3.5f, 1.8f, j * SQUARE_SIZE - SQUARE_SIZE * 3.5f);
                

                for (int k = 0; k < chessPiece.childCount; ++k)  //This check squares information
                {
                    if (Vector3.Distance(chessPiece.GetChild(k).position, square.transform.position) < SQUARE_SIZE/2)
                    {
                        square.GetComponent<SquareInfo>().piece = chessPiece.GetChild(k);
                    }
                }
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.0f);


                chessboard[i, j] = square.transform;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
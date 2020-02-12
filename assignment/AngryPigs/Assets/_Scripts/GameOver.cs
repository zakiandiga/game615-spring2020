using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public KeyCode Reset;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(Reset))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gm : MonoBehaviour
{
    public KeyCode gameover;
    public GameObject Canon;
    public GameObject Camera;
    public int enemyCount = 5;
    public int shotAttempt = 3;
    public Text lifeTotal;
    public Text birdTotal;
    public Text gameOver;

    public int getLife()
    {
        return shotAttempt;
    }


    void Update()
    {
        lifeTotal.text = "Pigs " + shotAttempt;
        birdTotal.text = "Birds " + enemyCount;
        if (shotAttempt < 1)
        {
            gameOver.text = "No more piggies!";
            Invoke("GameOver", 3);
        }
        if (enemyCount <1)
        {
            gameOver.text = "Congratulation!";
            Invoke("YouWin", 3);
        }

    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void YouWin()
    {
        SceneManager.LoadScene("WinScreen");
    }

}

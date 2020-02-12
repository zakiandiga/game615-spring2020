using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    const int PiggyHitStructure = 9;
    const int StructureHitStructure = 7;
    const int EnemyDeadScore = 50;
    public Text scoreTotal;



    void Start()
    {
        
    }

    void Update()
    {
        scoreTotal.text = "Score " + Score;
    }
    public int getScore()
    {
        return Score;
    }

    public void PiggyStructure()
    {
        Score = Score + PiggyHitStructure;

    }

    public void StructureStructure()
    {
        Score = Score + StructureHitStructure;
    }

    public void EnemyDead()
    {
        Score = Score + EnemyDeadScore;
        //Debug.Log("Score update +" + EnemyDeadScore);
    }

}    
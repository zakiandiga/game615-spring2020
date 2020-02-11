using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    const int PiggyHitStructure = 1;
    const int StructureHitStructure = 2;
    const int EnemyDeadScore = 5;
    public GameObject ScoreBoard;

    // Start is called before the first frame update
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
    }

}    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAnimation : MonoBehaviour
{
    public Animator pawnAnimator;
    public KeyCode testStraight;
    public KeyCode testAttackL;
    public KeyCode testAttackR;
    public KeyCode testAttacked;
    const string moveStraight = "Straight";
    const string moveDiagonalL = "AttackL";
    const string moveDiagonalR = "AttackR";
    const string attacked = "Die";

    void Start()
    {
        //cameraAnimator.GetComponent<cameraAnimator>(); -> dont need this because we have public Animator
    }

        }
        if (Input.GetKeyDown(testAttacked))
        {
            pawnAnimator.SetTrigger(attacked);
        }
    }
}

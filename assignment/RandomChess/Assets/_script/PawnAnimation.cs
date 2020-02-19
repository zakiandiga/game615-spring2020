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

    void Update()
    {
        //ALL THE TRIGGERS SHOULD BE UPDATED LATER, THESE KEY INPUT IS ONLY FOR TESTING
        if (Input.GetKeyDown(testStraight))
        {
            pawnAnimator.SetTrigger(moveStraight);
        }
        if (Input.GetKeyDown(testAttackL))
        {
            pawnAnimator.SetTrigger(moveDiagonalL);
        }
        if (Input.GetKeyDown(testAttackR))
        {
            pawnAnimator.SetTrigger(moveDiagonalR);
        }
        if (Input.GetKeyDown(testAttacked))
        {
            pawnAnimator.SetTrigger(attacked);
        }
    }
}

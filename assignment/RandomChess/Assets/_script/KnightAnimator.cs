using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimator : MonoBehaviour
{
    public Animator knightAnimator;
    public KeyCode walk;
    public KeyCode turn90L;
    public KeyCode turn90R;
    public KeyCode turn45L;
    public KeyCode turn45R;
    public KeyCode attack;
    public KeyCode die;
    public KeyCode idle;
    const string moveStraight = "Straight";
    const string turnL = "turnL";
    const string turnR = "turnR";
    const string sideL = "sideL";
    const string sideR = "sideR";
    const string hit = "Attack";
    const string attacked = "Die";
    const string idling = "idle";

    void Start()
    {
        //cameraAnimator.GetComponent<cameraAnimator>(); -> dont need this because we have public Animator
    }

    void Update()
    {
        //ALL THE TRIGGERS SHOULD BE UPDATED LATER, THESE KEY INPUT IS ONLY FOR TESTING
        if (Input.GetKeyDown(walk))
        {
            knightAnimator.SetTrigger(moveStraight);
        }
        if (Input.GetKeyDown(turn90L))
        {
            knightAnimator.SetTrigger(turnL);
        }
        if (Input.GetKeyDown(turn90R))
        {
            knightAnimator.SetTrigger(turnR);
        }
        if (Input.GetKeyDown(turn45L))
        {
            knightAnimator.SetTrigger(sideL);
        }
        if (Input.GetKeyDown(turn45R))
        {
            knightAnimator.SetTrigger(sideR);
        }
        if (Input.GetKeyDown(attack))
        {
            knightAnimator.SetTrigger(hit);
        }
        if (Input.GetKeyDown(die))
        {
            knightAnimator.SetTrigger(attacked);
        }
        if (Input.GetKeyDown(idle))
        {
            knightAnimator.SetTrigger(idling);
        }
    }

}

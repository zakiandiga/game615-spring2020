using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    public Animator cameraAnimator;
    public KeyCode StarterW;
    public KeyCode StarterB;
    const string WhitePlay = "WhitePlay";
    const string BlackPlay = "BlackPlay";

    void Start()
    {
        //cameraAnimator.GetComponent<cameraAnimator>(); -> dont need this because we have public Animator
    }
    
    void Update()
    {
        if (Input.GetKeyDown(StarterW))
        {
            cameraAnimator.SetTrigger(WhitePlay);
        }
        if (Input.GetKeyDown(StarterB))
        {
            cameraAnimator.SetTrigger(BlackPlay);
        }
    }
}

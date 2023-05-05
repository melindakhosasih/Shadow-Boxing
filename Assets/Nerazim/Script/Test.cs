using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Animation animationComponent;
    public string[] nextAnimationLists;
    public int ListNum;
    private string nextAnimationName = "None";
    private bool isPlaying = false;
    private int move = 0;
    private float prev_time = 0;
    void Start()
    {
        animationComponent = GetComponent<Animation>();
        prev_time = Time.time;
    }

    void Update()
    {
        if (Time.time - prev_time >= 5f)
        {
            
            animationComponent.Play("Combo");
            
        }
        else
        {
            animationComponent.Play("Waiting");
        }

        if (Time.time - prev_time >= 8f)
        {
            prev_time = Time.time;
        }
        
    }

    void PlayAnimation(string animationName)
    {
        if (animationComponent.isPlaying)
        {
            isPlaying = true;
            return;
        }

        animationComponent.Play(animationName);

        isPlaying = true;

        nextAnimationName = nextAnimationLists[move];
        move = (move + 1) % ListNum;
    }

    void AnimationComplete()
    {
        isPlaying = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour //如果不是出招，就是等待3-5秒
{
    private Animation animationComponent;
    public string[] attackLists;
    public int ListNum;
    private string nextAnimationName = "None";
    private bool isPlaying = false;
    private int move = 0;
    private float prev_time = 0;
    private float waitingTime = 3f;
    private float waitingTime_ = 5f;
    void Start()
    {
        animationComponent = GetComponent<Animation>();
        ListNum = attackLists.Length;
        prev_time = Time.time;
    }

    void Update()
    {   
        float i = UnityEngine.Random.Range(waitingTime,waitingTime_);//出招時間
        print(nextAnimationName);
        PlayAnimation(nextAnimationName);
        if (!isPlaying)
        {
            nextAnimationName = decideNextAnimation();
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
    }

    string decideNextAnimation()
    {
        string nextAnimation = attackLists[move];
        move = (move + 1) % ListNum;
        return nextAnimation;
    }
    void AnimationComplete()
    {
        isPlaying = false;
    }
}
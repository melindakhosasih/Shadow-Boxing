using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveManager : MonoBehaviour
{
    private static moveManager instance;
    
    private bool jabBlockState;
    private string leftGloveState;
    private string rightGloveState;

    public triggerScript[] leftTriggers;
    public triggerScript[] rightTriggers;

    void Start()
    {

    }

    void Update()
    {
        leftGloveState = LeftGloveInstance.GetInstance().getState();
        rightGloveState = RightGloveInstance.GetInstance().getState();

        if(leftGloveState == "Jab Block" && rightGloveState == "Jab Block")
        {
            jabBlockState = true;
        }
        else
        {
            jabBlockState = false;
        }

        Focus();
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one move manager detected");
        }
        instance = this;
    }

    public static moveManager GetInstance()
    {
        return instance;
    }

    private void Focus()
    {  
        if(jabBlockState)
        {
            foreach (triggerScript trigger in leftTriggers)
            {
                if(trigger.triggerName != leftGloveState)
                {
                    trigger.Hide();
                }
                else{
                    trigger.Show();
                }
            }
            foreach (triggerScript trigger in rightTriggers)
            {
                if(trigger.triggerName != rightGloveState)
                {
                    trigger.Hide();
                }
                else{
                    trigger.Show();
                }
            }
        }
        else
        {
            if(leftGloveState == "Jab Block" || leftGloveState == "Neutral")
            {
                foreach (triggerScript trigger in leftTriggers)
                {
                    trigger.Show();
                }
            }
            else
            {
                foreach (triggerScript trigger in leftTriggers)
                {
                    if(trigger.triggerName != leftGloveState)
                    {
                        trigger.Hide();
                    }
                    else{
                        trigger.Show();
                    }
                }
            }
            if(rightGloveState == "Jab Block" || rightGloveState == "Neutral")
            {
                foreach (triggerScript trigger in rightTriggers)
                {
                    trigger.Show();
                }
            }
            else
            {
                foreach (triggerScript trigger in rightTriggers)
                {
                    if(trigger.triggerName != rightGloveState)
                    {
                        trigger.Hide();
                    }
                    else{
                        trigger.Show();
                    }
                }
            }
        }
    }
    
}
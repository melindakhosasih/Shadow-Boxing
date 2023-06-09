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
    public bool tutorialMode;

    private bool leftDisabled;
    private bool rightDisabled;

    void Start()
    {
        leftDisabled = false;
        rightDisabled = false;
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

    private void disableLeft()
    {
        leftDisabled = true;
    }

    private void enableLeft()
    {
        leftDisabled = false;
    }

    private void disableRight()
    {
        rightDisabled = true;
    }

    private void enableRight()
    {
        rightDisabled = false;
    }

    public void Focus()
    {  
        foreach (triggerScript trigger in leftTriggers)
        {   
            if(tutorialMode && EventManager_Backup.GetInstance().tutorialInProgress && EventManager_Backup.GetInstance().sideMode == 1)
            {
                trigger.Hide();
            }
            else if(trigger.triggerName == "Jab Block" && rightGloveState != "Neutral" && rightGloveState != "Jab Block")
            {
                trigger.Hide();
            }
            else if(leftGloveState == "Neutral" && trigger.isFirst)
            {  
                trigger.Show();
            }
            else if(leftGloveState == "Jab Block")
            {
                if(!jabBlockState && trigger.isFirst)
                {
                    trigger.Show();
                }
                else if(jabBlockState && leftGloveState == trigger.triggerName)
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(leftGloveState == "Jab 1")
            {
                if(leftGloveState == trigger.triggerName)
                {
                    trigger.Hide_Active();
                }
                else if(trigger.triggerName == "Jab 2")
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(leftGloveState == "Hook 1")
            {
                if(leftGloveState == trigger.triggerName)
                {
                    trigger.Hide_Active();
                }
                else if(trigger.triggerName == "Hook 2")
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(leftGloveState == trigger.triggerName)
            {
                trigger.Show();
            }
            else
            {
                trigger.Hide();
            }
        }
        foreach (triggerScript trigger in rightTriggers)
        {
            if(tutorialMode && EventManager_Backup.GetInstance().tutorialInProgress && EventManager_Backup.GetInstance().sideMode == 2)
            {
                trigger.Hide();
            }
            else if(trigger.triggerName == "Jab Block" && leftGloveState != "Neutral" && leftGloveState != "Jab Block")
            {
                trigger.Hide();
            }
            else if(rightGloveState == "Neutral" && trigger.isFirst)
            {   
                trigger.Show();
            }
            else if(rightGloveState == "Jab Block")
            {
                if(!jabBlockState && trigger.isFirst)
                {
                    trigger.Show();
                }
                else if(jabBlockState && rightGloveState == trigger.triggerName)
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(rightGloveState == "Jab 1")
            {
                if(rightGloveState == trigger.triggerName)
                {
                    trigger.Hide_Active();
                }
                else if(trigger.triggerName == "Jab 2")
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(rightGloveState == "Hook 1")
            {
                if(rightGloveState == trigger.triggerName)
                {
                    trigger.Hide_Active();
                }
                else if(trigger.triggerName == "Hook 2")
                {
                    trigger.Show();
                }
                else
                {
                    trigger.Hide();
                }
                
            }
            else if(rightGloveState == trigger.triggerName)
            {
                trigger.Show();
            }
            else
            {
                trigger.Hide();
            }
        }
    }

    public void updateTriggers(triggerScript[] selectedLeftTriggers, triggerScript[] selectedRightTriggers)
    {
        leftTriggers = selectedLeftTriggers;
        rightTriggers = selectedRightTriggers;
    }

    public bool getJabBlockState()
    {
        return jabBlockState;
    }
}
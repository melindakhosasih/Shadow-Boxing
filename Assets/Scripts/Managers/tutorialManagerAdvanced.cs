using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class tutorialManagerAdvanced : MonoBehaviour
{
    private static tutorialManagerAdvanced instance;

    public triggerScript[] leftTriggers;
    public triggerScript[] rightTriggers;
    public bool isTutorial = false;

    private triggerScript[] selectedLeftTriggers;
    private triggerScript[] selectedRightTriggers;

    public enum ModeSelection
    {
        All,
        Block,
        HookBlock,
        Jab,
        Hook,
        Attack,
        None
    }

    public ModeSelection selectedMode;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one tutorial manager detected");
        }
        instance = this;
    }

    public static tutorialManagerAdvanced GetInstance()
    {
        return instance;
    }

    void Start()
    {
        moveManager.GetInstance().tutorialMode = true;
    }

    void Update()
    {

    }

    private triggerScript[] Movements(triggerScript[] triggers)
    {
        triggerScript[] selectedTriggers = new triggerScript[0];
        List<triggerScript> selectedTriggersList = new List<triggerScript>();

        switch (selectedMode)
        {
            case ModeSelection.All:
                selectedTriggersList = new List<triggerScript>(triggers);
                break;
            case ModeSelection.Block:
                foreach (triggerScript trigger in triggers)
                {
                    if (trigger.triggerName == "Jab Block")
                    {
                        selectedTriggersList.Add(trigger);
                    }
                }
                break;
            case ModeSelection.HookBlock:
                foreach (triggerScript trigger in triggers)
                {
                    if (trigger.triggerName == "Hook Block")
                    {
                        selectedTriggersList.Add(trigger);
                    }
                }
                break;
            case ModeSelection.Jab:
                foreach (triggerScript trigger in triggers)
                {
                    if (trigger.triggerName == "Jab 1" || trigger.triggerName == "Jab 2")
                    {
                        selectedTriggersList.Add(trigger);
                    }
                }
                break;
            case ModeSelection.Hook:
                foreach (triggerScript trigger in triggers)
                {
                    if (trigger.triggerName == "Hook 1" || trigger.triggerName == "Hook 2")
                    {
                        selectedTriggersList.Add(trigger);
                    }
                }
                break;
            case ModeSelection.Attack:
                foreach (triggerScript trigger in triggers)
                {
                    if (trigger.triggerName == "Jab 1" || trigger.triggerName == "Jab 2" ||
                        trigger.triggerName == "Hook 1" || trigger.triggerName == "Hook 2")
                    {
                        selectedTriggersList.Add(trigger);
                    }
                }
                break;
            case ModeSelection.None:
                break;
            default:
                selectedTriggersList = new List<triggerScript>(triggers);
                break;
        }
        selectedTriggers = selectedTriggersList.ToArray();

        return selectedTriggers;
    } 

    private void disableTriggers(triggerScript[] triggers)
    {
        foreach (triggerScript trigger in triggers)
        {
            trigger.Hide();
        }
    }

    private IEnumerator StartTutorialCoroutine(ModeSelection selected)
    {
        selectedMode = selected;
        yield return null;

        if(tutorialManagerAdvanced.GetInstance().isTutorial) disableTriggers(leftTriggers);
        if(tutorialManagerAdvanced.GetInstance().isTutorial) disableTriggers(rightTriggers);
        
        selectedLeftTriggers = Movements(leftTriggers);
        selectedRightTriggers = Movements(rightTriggers);
        
        moveManager.GetInstance().updateTriggers(selectedLeftTriggers, selectedRightTriggers);

        LeftGloveInstance.GetInstance().resetState();
        RightGloveInstance.GetInstance().resetState();
    }

    public void StartTutorial(ModeSelection selected, bool tutorial)
    {
        isTutorial = tutorial;
        StartCoroutine(StartTutorialCoroutine(selected));
    }
}

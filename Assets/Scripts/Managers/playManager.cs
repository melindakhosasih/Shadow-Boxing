using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class playManager : MonoBehaviour
{
    private static playManager instance;

    public triggerScript[] leftTriggers;
    public triggerScript[] rightTriggers;

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

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one play manager detected");
        }
        instance = this;
    }

    public static playManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        moveManager.GetInstance().updateTriggers(leftTriggers, rightTriggers);
        moveManager.GetInstance().tutorialMode = false;
    }

}

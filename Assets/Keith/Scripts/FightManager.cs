using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    private FightManager instance;
    private bool defendPhase;

    void Awake()
    {
        if(instance != null)
        {
             Debug.LogWarning("more than one fight manager detected");
        }
        instance = this;
    }

    public FightManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

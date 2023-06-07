using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager instance;
    private int Phase = 1;

    public enum EnemyMode
    {
        Idle = 0,
        Block = 1,
        LeftHookBlock = 2,
        RightHookBlock = 3,
        LeftJab = -1,
        RightJab = -1,
        LeftHook = -3,
        RightHook = -4
        
    }

    public EnemyMode enemyMode {get; private set;}

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one tutorial manager detected");
        }
        instance = this;
    }

    public static TutorialManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        enemyMode = EnemyMode.Idle;
    }

    void Update()
    {

    }

    public void ChangeMode(int newMode)
    {
        enemyMode = (EnemyMode)newMode;
    }
}

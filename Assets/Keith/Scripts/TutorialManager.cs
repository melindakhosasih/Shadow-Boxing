using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private static TutorialManager instance;

    public enum EnemyMode
    {
        Idle = 0,
        Block = 1,
        LeftHookBlock = 2,
        RightHookBlock = 3,
        Attack = 4
    }

    private int Phase = 1;
    private int counter = 0;
    private bool tutorialInProgress;

    public EnemyMode enemyMode {get; private set;}
    public int tutorialMode{get; private set;} 

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
        tutorialMode = 0;
        tutorialInProgress = false;
    }

    void Update()
    {

    }

    public void ToggleTutorial(int newValue)
    {
        counter = 0;
        tutorialInProgress = !tutorialInProgress;
        if(tutorialInProgress) tutorialMode = newValue;
    }

    public bool GetTutorialStatus()
    {
        return tutorialInProgress;
    }

    public int GetCounter()
    {
        return counter;
    }

    public void ChangeMode(int newMode)
    {
        enemyMode = (EnemyMode)newMode;
    }

    public void IncrementCounter()
    {
        counter += 1;
        print("Counter" + counter);
        if(counter == 4)
        {
            EventManager.GetInstance().IncrementIndex();
        }
    }
}

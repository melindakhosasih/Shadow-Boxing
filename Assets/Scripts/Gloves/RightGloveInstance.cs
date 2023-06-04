using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGloveInstance : MonoBehaviour
{
    private static RightGloveInstance instance;
    private string state;

    void Start()
    {
        state = "Neutral";
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one right glove detected");
        }
        instance = this;
    }

    public static RightGloveInstance GetInstance()
    {
        return instance;
    }

    public void changeState(string newState)
    {
        state = newState;
    }

    public void resetState()
    {
        state = "Neutral";
    }

    public string getState()
    {
        return state;
    }
}

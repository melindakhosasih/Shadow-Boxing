using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGloveInstance : MonoBehaviour
{
    private static LeftGloveInstance instance;
    private string state;

    void Start()
    {
        state = "Neutral";
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one left glove detected");
        }
        instance = this;
    }

    public static LeftGloveInstance GetInstance()
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

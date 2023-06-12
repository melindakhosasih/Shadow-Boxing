using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    private static FightManager instance;
    private bool defendPhase;
    private bool isBlocking;

    public GameObject blockTrigger;
    public GameObject blockHitbox;

    void Awake()
    {
        if(instance != null)
        {
             Debug.LogWarning("more than one fight manager detected");
        }
        instance = this;
    }

    public static FightManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        isBlocking = false;
    }

    void Update()
    {
        checkBlock();
    }

    private void checkBlock()
    {
        if(isBlocking)
        {
            blockHitbox.SetActive(true);
        }
        else
        {
            blockHitbox.SetActive(false);
        }
    }

    public void OnBlock()
    {
        isBlocking = true;
    }

    public void OffBlock()
    {
        isBlocking = false;
    }
}

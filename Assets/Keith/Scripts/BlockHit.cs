using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    private int count = 0;
    private float lastTime;

    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        float currentTime = Time.time;

        if (currentTime - lastTime >= 2f)
        {
            EventManager.GetInstance().IncrementTimeCount();
            lastTime = currentTime;
        }
    }
}

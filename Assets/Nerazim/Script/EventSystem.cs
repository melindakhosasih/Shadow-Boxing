using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    private float prev_time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void XbuttonPressed()
    {
        print("X");
        if (Time.time - prev_time >= 1f)//做時間控制
        {
            prev_time = Time.time;
        }
    }
    public void YbuttonPressed()
    {
        print("Y");
        if (Time.time - prev_time >= 1f)
        {
            prev_time = Time.time;
        }
    }
    public void AbuttonPressed()
    {
        print("A");
        if (Time.time - prev_time >= 1f)
        {
            prev_time = Time.time;
        }
    }
    public void BbuttonPressed()
    {
        print("B");
        if (Time.time - prev_time >= 1f)
        {
            prev_time = Time.time;
        }
    }
}

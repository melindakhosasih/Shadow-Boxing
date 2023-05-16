using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//手把的動作，設定方法:到input action manager 新增一個action assets
//在 Complete XR Origin Set Up 底下的 Input Action Manager 新增 Player Input。
// Actions 為 Quest2Buttons
//設定 Behavior 為 Invoke Unity Events
public class HandAction : MonoBehaviour
{
    private float prev_time = 0;
    private GameObject Tutorial_EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial_EventSystem = GameObject.FindWithTag("EventSystem");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void XbuttonPressed()
    {
        print("X pressed!");
        if (Time.time - prev_time >= 1f)//做時間控制
        {
            prev_time = Time.time;
        }
        
    }
    public void YbuttonPressed()
    {
        print("Y pressed!");
        if (Time.time - prev_time >= 1f)//做時間控制
        {
            prev_time = Time.time;
        }
    }
    public void AbuttonPressed()
    {
        print("A pressed!");
        if (Time.time - prev_time >= 1f)//做時間控制
        {
            Tutorial_EventSystem.GetComponent<new_Tutorial>().sub_step += 1;
            prev_time = Time.time;
        }
    }
    public void BbuttonPressed()
    {
        print("B pressed!");
        if (Time.time - prev_time >= 1f)//做時間控制
        {
            prev_time = Time.time;
        }
    }
}

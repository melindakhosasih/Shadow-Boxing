using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//手把的動作，設定方法:到input action manager 新增一個action assets
//在 Complete XR Origin Set Up 底下的 Input Action Manager 新增 Player Input。
// Actions 為 Quest2Buttons
//設定 Behavior 為 Invoke Unity Events
public class HandAction : MonoBehaviour
{
    private float lastButtonPressTime = 0f;
    public float buttonCooldown = 1f;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void AbuttonPressed()
    {   
        if (Time.time - lastButtonPressTime >= buttonCooldown)
        {
            lastButtonPressTime = Time.time;
            print("A pressed!");

            EventManager.GetInstance().IncrementIndex();
        }
    }
    // public void BbuttonPressed()
    // {
    //     if (Time.time - lastButtonPressTime >= buttonCooldown)
    //     {
    //         lastButtonPressTime = Time.time;
    //         print("B pressed!");

    //         EventManager.GetInstance().DecrementIndex();
    //     }
    // }

    // public void XbuttonPressed()
    // {
    //     print("X pressed!");
    //     if (Time.time - prev_time >= 1f)//做時間控制
    //     {
    //         prev_time = Time.time;
    //     }
        
    // }
    // public void YbuttonPressed()
    // {
    //     print("Y pressed!");
    //     if (Time.time - prev_time >= 1f)//做時間控制
    //     {
    //         prev_time = Time.time;
    //     }
    // }
}

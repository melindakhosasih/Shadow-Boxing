using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class global // 不能繼承MonoBehaviour，不能掛在物件上面
{
    public static float volume;
    public static string prescene;
    public static string level;
    static global(){    //初始化，開啟應用程式時會執行一遍。
    volume=0.5f;          //初始化靜態類別成員
    prescene = "title";
    level = "Easy";
    }
}
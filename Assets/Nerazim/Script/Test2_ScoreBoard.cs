using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Test2_ScoreBoard : MonoBehaviour
{
    private GameObject Text_Round;
    private GameObject Text_Time;
    private GameObject Text_Score;
    public int Roundnum;
    public float RemainTime;
    public int Score;

    private string Remain_min;
    private int min;
    private string Remain_sec;
    private int sec;

    private int sec_;

    private bool canChange = true;
    // Start is called before the first frame update
    void Start()
    {
        Text_Round = transform.GetChild(0).gameObject;
        Text_Time = transform.GetChild(1).gameObject;
        Text_Score = transform.GetChild(2).gameObject;
        Roundnum = 1;
        Score = 0;
        Remain_min = "3";
        Remain_sec = "00";
        min = 3;
        sec = 0;
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        Text_Round.gameObject.GetComponent<TextMeshPro>().text = "Round : " + Roundnum;
        Text_Time.gameObject.GetComponent<TextMeshPro>().text = "Time : 0" + Remain_min + " : " + Remain_sec;
        Text_Score.gameObject.GetComponent<TextMeshPro>().text = "Score : " + Score;
        UpdateTime();
        if((min==-1))
        {
            Refresh();
        }
    }

    void UpdateTime()
    {
        sec_ = 60*(3-min) - (int)Time.time;
        print(sec_);
        print(min);
        print(canChange);
        if ((sec_==0)&&(canChange))
        {
            canChange = false;
            min = min - 1;
            Remain_min = min.ToString();
            Remain_sec = sec_.ToString();
        }
        else
        {
            Remain_sec = sec_.ToString();
            if (Remain_sec == "60")
            {
                Remain_sec = "00";
                Text_Time.gameObject.GetComponent<TextMeshPro>().text = "Time : 0" + (min+1).ToString() + " : " + Remain_sec;
            }
            else if (Remain_sec.Length == 1)
            {
                Remain_sec = "0" + sec_.ToString();
            }
        }

        if (sec_ != 0)
        {
            canChange = true;
        }
    }
    void Refresh()
    {
        Roundnum = Roundnum + 1;
        Score = 0;
        Remain_min = "3";
        Remain_sec = "00";
        min = 3;
        sec = 0;
        canChange = true;
    }
}

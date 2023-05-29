using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Test2_ScoreBoard : MonoBehaviour
{
    public bool GameStart = false;
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

    public float startTime;

    private bool endGame;

    private float roundTime = 10f;

    private int first_time = 3;

    private int min_d;

    private int time_30 = 0;
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
        min = 2;
        sec = 0;
        canChange = true;
        GameStart = false;
        endGame = false;
        roundTime = GameObject.FindWithTag("system").GetComponent<Test2_System>().round_time;
        print(roundTime);
        if (roundTime == 180)
        {
            min_d = 3;
            first_time = 3;
            time_30 = 0;
        }
        else if (roundTime == 120)
        {
            min_d = 2;
            first_time = 2;
            time_30 = 0;
        }
        else if (roundTime == 60)
        {
            min_d = 1;
            first_time = 1;
            time_30 = 0;
        }
        else if (roundTime == 30)
        {
            min_d = 0;
            first_time = 1;
            time_30 = 30;
        }

        min = min_d;
    }

    // Update is called once per frame
    void Update()
    {
        // print(roundTime);
        GameStart = GameObject.FindWithTag("system").GetComponent<Test2_System>().GameStart;
        endGame = GameObject.FindWithTag("system").GetComponent<Test2_System>().endGame;
        Text_Round.gameObject.GetComponent<TextMeshPro>().text = "Round " + Roundnum;
        Text_Time.gameObject.GetComponent<TextMeshPro>().text = "Time : 0" + Remain_min + " : " + Remain_sec;
        // Text_Score.gameObject.GetComponent<TextMeshPro>().text = "Score : " + Score;
        
        if (GameStart == true)
        {
            UpdateTime();
        }
        else
        {
            setStartTime();
        }
        if (endGame)
        {
            GameObject.FindWithTag("system").GetComponent<Test2_System>().endGame = false;
            Refresh();
        }
    }

    void setStartTime()
    {
        startTime = Time.time;
    }
    void UpdateTime()
    {
        sec_ = 60*(first_time-min) - ((int)Time.time-(int)startTime)-time_30;
        
        //print(sec_);
        //print(min);
        Remain_min = (min).ToString();
        //print(canChange);
        if ((sec_==0)&&(canChange))
        {
            canChange = false;
            min = min - 1;
            Remain_min = (min).ToString();
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
        
        if ((int)Time.time - (int)startTime == roundTime)
        {
            GameObject.FindWithTag("system").GetComponent<Test2_System>().GameStart= false;
            GameObject.FindWithTag("system").GetComponent<Test2_System>().endGame = true;
            GameObject.FindWithTag("system").GetComponent<Test2_System>().reset = true;
        }
    }
    void Refresh()
    {
        Roundnum = Roundnum + 1;
        Score = 0;
        //Remain_min = "3";
        //Remain_sec = "00";
        roundTime = GameObject.FindWithTag("system").GetComponent<Test2_System>().round_time;
        if (roundTime == 180)
        {
            min_d = 3;
            first_time = 3;
            time_30 = 0;
        }
        else if (roundTime == 120)
        {
            min_d = 2;
            first_time = 2;
            time_30 = 0;
        }
        else if (roundTime == 60)
        {
            min_d = 1;
            first_time = 1;
            time_30 = 0;
        }
        else if (roundTime == 30)
        {
            min_d = 0;
            first_time = 1;
            time_30 = 30;
        }

        min = min_d;
        sec = 0;
        canChange = true;
    }
}

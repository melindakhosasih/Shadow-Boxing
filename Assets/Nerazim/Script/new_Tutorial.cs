using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class new_Tutorial : MonoBehaviour
{
    public bool Mission1_Complete = false;
    public bool Mission2_Complete = false;
    public bool Mission3_Complete = false;
    public GameObject redCircle1;
    public GameObject redCircle2;
    public GameObject whiteCircle;
    public GameObject UI;
    public GameObject UI2;
    public GameObject ball;
    public GameObject ball1_;
    public GameObject ball2_;
    public int HitNumber = 0;
    private int time_;
    public int step = 0;
    public int sub_step = 0;//按鍵說明，預設按下A繼續
    public int mission_complete_number = 0;
    private float prev_time;
    string title1 = "按鍵說明";
    
    string title2 = "基本教學:";
    string mission1 = "移動訓練:移動到圈圈裡面";
    string mission2 = "打擊訓練:擊中固定的球體";
    string mission3 = "打擊訓練:擊中漂浮的球體";
    // Start is called before the first frame update
    void Start()
    {
        sub_step = 0;
        Mission1_Complete = false;
        Mission2_Complete = false;
        Mission3_Complete = false;
        ball1_.SetActive(false);
        ball2_.SetActive(false);
        redCircle1.SetActive(false);
        redCircle2.SetActive(false);
        whiteCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (step == 0)
        {
            if (sub_step == 0)
            {
                UI.gameObject.GetComponent<Text>().text = "歡迎來到Shadow Boxing! ";
                UI2.gameObject.GetComponent<Text>().text =  "       (press A....)";
            }
            if (sub_step == 1)
            {
                UI.gameObject.GetComponent<Text>().text = "接下來開始說明按鍵操作";
                UI2.gameObject.GetComponent<Text>().text = "        (press A....)";
            }
            else if (sub_step == 2)
            {
                UI.gameObject.GetComponent<Text>().text = "遊戲中透過連續按下兩次B鍵打開主選單 ";
                UI2.gameObject.GetComponent<Text>().text = "        (press A....)";
            }
            else if (sub_step == 3)
            {
                UI.gameObject.GetComponent<Text>().text = "接下來開始簡單的操作教學 ";
                UI2.gameObject.GetComponent<Text>().text = "        (press A....)";
            }
            if (sub_step == 4)
            {
                whiteCircle.SetActive(true);
                step = step + 1;
            }
        }
        else if (step == 1)
        {
            
            UI.gameObject.GetComponent<Text>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<Text>().text = mission1;
            if (Mission1_Complete)
            {
                mission_complete_number = mission_complete_number + 1;
                ball1_.SetActive(true);
                redCircle2.SetActive(true);
                step = step + 1;
            }
        }
        else if (step == 2)
        {
            UI.gameObject.GetComponent<Text>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<Text>().text = mission2 + "(0/1)";
            if (HitNumber == 1)
            {
                mission_complete_number = mission_complete_number + 1;
                redCircle2.SetActive(false);
                ball2_.SetActive(true);
                redCircle1.SetActive(true);
                step = step + 1;
            }
        }
        else if (step == 3)
        {
            
            UI.gameObject.GetComponent<Text>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<Text>().text = mission3 + "(0/1)";
            if (HitNumber == 2)
            {
                redCircle1.SetActive(false);
                mission_complete_number = mission_complete_number + 1;
                step = step + 1;
            }
        }
        else if (step == 4)
        {
            UI.gameObject.GetComponent<Text>().text = "訓練完成!";
            UI2.gameObject.GetComponent<Text>().text = "Congratulations!";
            prev_time = Time.time;
            step = step + 1;
        }
        else if (step == 5)
        {
            UI.gameObject.GetComponent<Text>().text = "訓練完成!";
            UI2.gameObject.GetComponent<Text>().text = "Congratulations!";
            if (Time.time - prev_time > 2f)
            {
                prev_time = Time.time;
                step = step + 1;
            }
        }
        else if (step == 6)
        {
            UI.gameObject.GetComponent<Text>().text = "3秒後將跳轉到主介面!";
            UI2.gameObject.GetComponent<Text>().text = "";
            prev_time = Time.time;
            step = step + 1;
        }
        else if (step == 7)
        {
            time_ = 3-((int)(Time.time - prev_time));
            if (time_ == 0)
            {
                time_ = 1;
            }
            UI.gameObject.GetComponent<Text>().text = time_ +" 秒後將跳轉到主介面!";
            UI2.gameObject.GetComponent<Text>().text = "";
            if (Time.time - prev_time > 3f)
            {
                step = step + 1;
            }
        }
        else if(step == 8)
        {
            SceneManager.LoadScene("main");
        }
    }
}

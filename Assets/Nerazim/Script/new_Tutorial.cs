using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class new_Tutorial : MonoBehaviour
{
    public bool Mission1_Complete = false;
    public bool Mission2_Complete = false;
    public bool Mission3_Complete = false;
    public GameObject redCircle1;
    public GameObject redCircle2;
    public GameObject UI;
    public GameObject UI2;
    public GameObject ball;
    public GameObject ball1_;
    public GameObject ball2_;
    public int HitNumber = 0;

    public int step = 0;
    public int sub_step = 0;
    public int mission_complete_number = 0;
    string title1 = "按鍵教學";
    
    string title2 = "基本教學:";
    string mission1 = "移動訓練:移動到圈圈裡面";
    string mission2 = "打擊訓練:擊中固定的球球";
    string mission3 = "打擊訓練:擊中漂浮的球球";
    // Start is called before the first frame update
    void Start()
    { 
        Mission1_Complete = false;
        Mission2_Complete = false;
        Mission3_Complete = false;
        ball1_.SetActive(false);
        ball2_.SetActive(false);
        redCircle1.SetActive(false);
        redCircle2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            UI.gameObject.GetComponent<Text>().text = title1;
            UI2.gameObject.GetComponent<Text>().text = "Welcome!";
            
            step = step + 1;
            
            
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
        }
    }
}

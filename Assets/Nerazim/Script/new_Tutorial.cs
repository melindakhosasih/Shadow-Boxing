using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class new_Tutorial : MonoBehaviour
{
    public GameObject videoBox;
    public GameObject videoBox_glove;
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
    
    string title2 = "Basic tutorial:";
    string mission1 = "movement tutorial : move into the white circle";
    string mission2 = "punch tutorial : hit the fixed ball";
    string mission3 = "punch tutorial : hit the floating ball";
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
        videoBox.SetActive(false);
        videoBox_glove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (step == 0)
        {
            if (sub_step == 0)
            { 
                UI.gameObject.GetComponent<TextMeshPro>().text = "Welcome to Shadow Boxing! ";
                UI2.gameObject.GetComponent<TextMeshPro>().text =  "       (press A....)";
            }
            if (sub_step == 1)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "The next is the button description";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 2)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "Open the main menu by pressing the B key twice in the game ";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 3)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "If the glove falls on the ground use the back button to pick it up ";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 4)
            {
                videoBox_glove.SetActive(true);
                UI.gameObject.GetComponent<TextMeshPro>().text = "";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 5)
            {
                videoBox_glove.SetActive(false);
                UI.gameObject.GetComponent<TextMeshPro>().text = "Then start the simple operation teaching ";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 6)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "";
                videoBox.SetActive(true);
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            if (sub_step == 7)
            {
                videoBox.SetActive(false);
                whiteCircle.SetActive(true);
                step = step + 1;
            }
        }
        else if (step == 1)
        {
            
            UI.gameObject.GetComponent<TextMeshPro>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = mission1;
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
            UI.gameObject.GetComponent<TextMeshPro>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = mission2 + "(0/1)";
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
            
            UI.gameObject.GetComponent<TextMeshPro>().text = title2+"("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = mission3 + "(0/1)";
            if (HitNumber == 2)
            {
                redCircle1.SetActive(false);
                mission_complete_number = mission_complete_number + 1;
                step = step + 1;
            }
        }
        else if(step == 4)
        {
            step = step + 1;
        }
        else if (step == 5)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Complete!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Congratulations!";
            prev_time = Time.time;
            step = step + 1;
        }
        else if (step == 6)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Complete!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Congratulations!";
            if (Time.time - prev_time > 2f)
            {
                prev_time = Time.time;
                step = step + 1;
            }
        }
        else if (step == 7)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "After 3 seconds, it will jump to the main menu!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "";
            prev_time = Time.time;
            step = step + 1;
        }
        else if (step == 8)
        {
            time_ = 5-((int)(Time.time - prev_time));
            if (time_ == 0)
            {
                time_ = 1;
            }
            UI.gameObject.GetComponent<TextMeshPro>().text = "After " + time_ +" seconds, it will jump to the main menu!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "";
            if (Time.time - prev_time > 5f)
            {
                step = step + 1;
            }
        }
        else if(step == 9)
        {
            SceneManager.LoadScene("main");
        }
    }
}

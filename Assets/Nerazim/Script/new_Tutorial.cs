using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class new_Tutorial : MonoBehaviour
{
    private static new_Tutorial instance;

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
    
    string mission1 = "Please move to the white circle";
    string mission2 = "punch tutorial : hit the fixed ball";
    string mission3 = "punch tutorial : hit the floating ball";

    public bool allowIncrement = false;
    private int counter;
    private int sideMode = 0;
    private bool blockNow = false;
    private bool tutorialInProgress;
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one tutorial detected");
        }
        instance = this;
    }

    public static new_Tutorial GetInstance()
    {
        return instance;
    }

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

        tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None);
        tutorialInProgress = false;
    }

    public void incrementCounter()
    {
        counter += 1;
        if(sideMode == 1) sideMode = 2;
        else if(sideMode == 2) sideMode = 1;
    }

    public int getSide()
    {
        return sideMode;
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
                UI.gameObject.GetComponent<TextMeshPro>().text = "The image to the right is the button description";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 2)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "Open the main menu by pressing the B key twice once in the game ";
                UI2.gameObject.GetComponent<TextMeshPro>().text = "        (press A....)";
            }
            else if (sub_step == 3)
            {
                UI.gameObject.GetComponent<TextMeshPro>().text = "If the glove falls on the ground use the button behind the controller to pick it up ";
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
                UI.gameObject.GetComponent<TextMeshPro>().text = "We will now begin the basic tutorial";
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
            
            UI.gameObject.GetComponent<TextMeshPro>().text = "Basic Tutorial: ("+mission_complete_number.ToString()+"/3)";
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
            UI.gameObject.GetComponent<TextMeshPro>().text = "Basic Tutorial: ("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = mission2;
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
            
            UI.gameObject.GetComponent<TextMeshPro>().text = "Basic Tutorial: ("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = mission3;
            if (HitNumber == 2)
            {
                redCircle1.SetActive(false);
                mission_complete_number = mission_complete_number + 1;
                step = step + 1;
            }
        }
        else if(step == 4) //Jab Block
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Jabs";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please raise your hand to the spheres";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Block);
                tutorialInProgress = true;
                blockNow = true;
                counter = 0;
                sideMode = 0;
            }
            if(counter == 1)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None);
                tutorialInProgress = false;
                step += 1; 
            }

            if(blockNow && moveManager.GetInstance().getJabBlockState())
            {
                counter += 1;
                blockNow = false;
            }
            else if(!blockNow && !moveManager.GetInstance().getJabBlockState())
            {
                blockNow = true;
            }
        }
        else if(step == 5) //Hook Block
        {
            if(sideMode == 1) UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Right Hook";
            else if (sideMode == 2) UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Left Hooks";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please raise your hand to the spheres";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.HookBlock);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
                allowIncrement = true;
            }
            if(counter == 2)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None);
                step += 1; 
                tutorialInProgress = false;
            }
        }
        else if(step == 6) //Jabs
        {
            if(sideMode == 1) UI.gameObject.GetComponent<TextMeshPro>().text = "Jab Right";
            else if (sideMode == 2) UI.gameObject.GetComponent<TextMeshPro>().text = "Jab Left";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please move your hand to the spheres";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Jab);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
                allowIncrement = true;
            }
            if(counter == 2)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None);
                step += 1; 
                tutorialInProgress = false;
            }
        }
        else if(step == 7) //Hooks
        {
            
            if(sideMode == 1) UI.gameObject.GetComponent<TextMeshPro>().text = "Hook Right";
            else if (sideMode == 2) UI.gameObject.GetComponent<TextMeshPro>().text = "Hook Left";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please move your hand to the spheres";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Hook);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
                allowIncrement = true;
            }
            if(counter == 2)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None);
                step += 1; 
                tutorialInProgress = false;
            }
        }
        else if (step == 8)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Complete!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Congratulations!";
            prev_time = Time.time;
            step = step + 1;

            tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.All);
        }
        else if (step == 9)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Complete!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Congratulations!";
            if (Time.time - prev_time > 2f)
            {
                prev_time = Time.time;
                step = step + 1;
            }
        }
        else if (step == 10)
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "After 3 seconds, it will jump to the main menu!";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "";
            prev_time = Time.time;
            step = step + 1;
        }
        else if (step == 11)
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
        else if(step == 12)
        {
            SceneManager.LoadScene("main");
        }
    }
}

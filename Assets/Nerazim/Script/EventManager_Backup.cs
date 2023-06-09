using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class EventManager_Backup : MonoBehaviour
{
    private static EventManager_Backup instance;

    public GameObject videoBox;
    public GameObject videoBox_glove;
    public bool Mission1_Complete = false;
    public bool Mission2_Complete = false;
    public bool Mission3_Complete = false;
    public GameObject redCircle1;
    public GameObject redCircle2;
    public GameObject whiteCircle;

    [Header("UI")]
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject UI2;

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

    public int sideMode = 0;
    private int counter;
    private float elapsedTime;
    public bool tutorialInProgress;
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one event manager detected");
        }
        instance = this;
    }

    public static EventManager_Backup GetInstance()
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

        tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None, true);
        tutorialInProgress = false;
    }

    public bool CheckString(string value, string targetValue)
    {
        if (targetValue != value)
        {
            targetValue = value;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= 3f)
        {
            return true;
        }

        return false;
    }

    public bool CheckBool(bool value, bool targetValue)
    {
        if (targetValue != value)
        {
            targetValue = value;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= 3f)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (step == 0)
        {
            if (sub_step == 0)
            { 
                UI.gameObject.GetComponent<TextMeshPro>().text = "Welcome to Shadow Boxing!";
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
                step += 4;
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
            }
        }
        else if (step == 1)
        {
            
            UI.gameObject.GetComponent<TextMeshPro>().text = "Basic Tutorial: ("+mission_complete_number.ToString()+"/3)";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please move to the white circle";
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
            UI2.gameObject.GetComponent<TextMeshPro>().text = "punch tutorial : hit the fixed ball";
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
            UI2.gameObject.GetComponent<TextMeshPro>().text = "punch tutorial : hit the floating ball";
            if (HitNumber == 2)
            {
                redCircle1.SetActive(false);
                mission_complete_number = mission_complete_number + 1;
                step = step + 1;
            }

            tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.All, false);
        }
        else if(step == 4) //Jab Block
        {
            UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Jabs";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please raise your hand to the spheres for " + (4 - Mathf.Ceil(elapsedTime))+ " seconds";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Block, true);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 0;
            }

            if(counter == 0)
            {
                if(CheckBool(moveManager.GetInstance().getJabBlockState(), true))
                {
                    counter += 1;
                }
            }
            if(counter == 1)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None, true);
                tutorialInProgress = false;
                step += 1; 
            }
        }
        else if(step == 5) //Hook Block
        {
            if(sideMode == 1) UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Right Hook";
            else if (sideMode == 2) UI.gameObject.GetComponent<TextMeshPro>().text = "Blocking Left Hooks";
            UI2.gameObject.GetComponent<TextMeshPro>().text = "Please raise your hand to the spheres for " + (4 - Mathf.Ceil(elapsedTime))+ " seconds";

            if(!tutorialInProgress)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.HookBlock, true);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
                elapsedTime = 0;
            }
            if(counter == 0)
            {
                if(CheckString(RightGloveInstance.GetInstance().getState(), "Hook Block"))
                {
                    counter += 1;
                    sideMode = 2;
                }
            }
            else if(counter == 1)
            {
                if(CheckString(LeftGloveInstance.GetInstance().getState(), "Hook Block"))
                {
                    counter += 1;
                    sideMode = 0;
                }
            }
            else if(counter == 2)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None, true);
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
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Jab, true);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
            }
            if(counter == 0)
            {
                if(RightGloveInstance.GetInstance().getState() == "Jab 2")
                {
                    counter += 1;
                    sideMode = 2;
                }
            }
            else if(counter == 1)
            {
                if(LeftGloveInstance.GetInstance().getState() == "Jab 2")
                {
                    counter += 1;
                    sideMode = 1;
                }
            }
            else if(counter == 2)
            {
                if(RightGloveInstance.GetInstance().getState() == "Jab 2")
                {
                    counter += 1;
                    sideMode = 2;
                }
            }
            else if(counter == 3)
            {
                if(LeftGloveInstance.GetInstance().getState() == "Jab 2")
                {
                    counter += 1;
                    sideMode = 0;
                }
            }
            if(counter == 4)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None, true);
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
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.Hook, true);
                tutorialInProgress = true;
                counter = 0;
                sideMode = 1;
            }
            if(counter == 0)
            {
                if(RightGloveInstance.GetInstance().getState() == "Hook 2")
                {
                    counter += 1;
                    sideMode = 2;
                }
            }
            else if(counter == 1)
            {
                if(LeftGloveInstance.GetInstance().getState() == "Hook 2")
                {
                    counter += 1;
                    sideMode = 1;
                }
            }
            else if(counter == 2)
            {
                if(RightGloveInstance.GetInstance().getState() == "Hook 2")
                {
                    counter += 1;
                    sideMode = 2;
                }
            }
            else if(counter == 3)
            {
                if(LeftGloveInstance.GetInstance().getState() == "Hook 2")
                {
                    counter += 1;
                    sideMode = 0;
                }
            }
            if(counter == 4)
            {
                tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.None, true);
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

            tutorialManagerAdvanced.GetInstance().StartTutorial(tutorialManagerAdvanced.ModeSelection.All, false);
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

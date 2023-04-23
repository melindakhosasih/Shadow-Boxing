using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BallMission : MonoBehaviour
{
    public int missionNumber = 0; //1=一個固定球球 2=很多固定球球 3=移動球球
    public bool endMission0 = true;
    public bool endMission1 = false;
    public bool endMission2 = false;
    public bool endMission3 = false;
    public int HitNumber = 0;
    private bool showUI2 = false;
    public GameObject ball;

    public GameObject UI;

    public GameObject UI2;
    // Start is called before the first frame update
    void Start()
    {
        HitNumber = 0;
        missionNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        string s = (HitNumber - 1).ToString();
        if ((missionNumber == 1)&&(endMission0))
        {
            endMission0 = false;
            GameObject ball1 = Instantiate(ball, new Vector3(0, 1.286f, 0),this.transform.rotation);
            ball1.gameObject.GetComponent<Float>().enabled = false;
            UI.gameObject.GetComponent<Text>().text = "Mission : (1/3)";
            UI2.gameObject.GetComponent<Text>().text = "Hit the ball("+HitNumber+"/1)!";
        }
        else if ((missionNumber == 2)&&(endMission1))
        {
            endMission1 = false;
            showUI2 = true;
            GameObject ball1 = Instantiate(ball, new Vector3(1, 1.286f, 2),this.transform.rotation);
            ball1.gameObject.GetComponent<Float>().enabled = false;
            GameObject ball2 = Instantiate(ball, new Vector3(0, 1.286f, 2),this.transform.rotation);
            ball2.gameObject.GetComponent<Float>().enabled = false;
            GameObject ball3 = Instantiate(ball, new Vector3(-1, 1.286f, 2),this.transform.rotation);
            ball3.gameObject.GetComponent<Float>().enabled = false;
            UI.gameObject.GetComponent<Text>().text = "Mission : (2/3)";
        }
        else if ((missionNumber == 3)&&(endMission2))
        {
            endMission2 = false;
            Instantiate(ball, new Vector3(0, 1.286f, 0),this.transform.rotation);
            UI.gameObject.GetComponent<Text>().text = "Mission : (3/3)";
            UI2.gameObject.GetComponent<Text>().text = "Hit the floating ball!";
        }
        else if ((missionNumber == 4)&&(endMission3))
        {
            endMission3 = false;
            Instantiate(ball, new Vector3(0, 0, 0),this.transform.rotation);
            UI.gameObject.GetComponent<Text>().text = "";
            UI2.gameObject.GetComponent<Text>().text = "Mission Complete!";
        }

        if ((missionNumber==1)&&(HitNumber == 1))//完成任務1
        {
            endMission1 = true;
            missionNumber = 2;
        }
        else if ((missionNumber==2)&&(HitNumber == 4))//完成任務2
        {
            showUI2 = false;
            endMission2 = true;
            missionNumber = 3;
        }
        else if ((missionNumber==3)&&(HitNumber == 5))//完成任務3
        {
            
            endMission3 = true;
            missionNumber = 4;
        }


        if (showUI2)
        {
            UI2.gameObject.GetComponent<Text>().text = "Hit the ball("+ s +"/3)!";
        }
        print(HitNumber);
    }
}

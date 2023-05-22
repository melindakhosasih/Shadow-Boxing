using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Test2_time : MonoBehaviour
{
    public GameObject Time_;
    private bool canChange = true;

    private float prev_time;

    public int round_time = 180;
    // Start is called before the first frame update
    void Start()
    {
        Time_.gameObject.GetComponent<TextMeshPro>().text = "03 : 00";
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - prev_time>1.5f)
        {
            canChange = true;
        }
        GameObject.FindWithTag("system").GetComponent<Test2_System>().round_time = round_time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "LeftHand")||(collision.transform.tag == "RightHand"))
        {
            if (canChange)
            {
                prev_time = Time.time;
                canChange = false;
                if(round_time==180)
                {
                    Time_.gameObject.GetComponent<TextMeshPro>().text = "02 : 00";
                    round_time = 120;
                }
                else if (round_time == 120)
                {
                    Time_.gameObject.GetComponent<TextMeshPro>().text = "01 : 00";
                    round_time = 60;
                }
                else if (round_time == 60)
                {
                    Time_.gameObject.GetComponent<TextMeshPro>().text = "00 : 30";
                    round_time = 30;
                }
                else if (round_time == 30)
                {
                    Time_.gameObject.GetComponent<TextMeshPro>().text = "03 : 00";
                    round_time = 180;
                }
            }
        }
    }
}

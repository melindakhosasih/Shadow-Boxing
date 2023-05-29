using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_Startbuttom : MonoBehaviour
{
    public GameObject time_text;

    

    private bool useHP = false;
    
    private float canChangeTime = 1f;//1秒後才能再更換

    private float prev_time;

    private bool canChange = true;
    // Start is called before the first frame update
    void Start()
    {
        useHP = false;
        
        prev_time = Time.time;
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (canChange == false)
        {
            if (Time.time - prev_time >= canChangeTime)
            {
                canChange = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "RightHand")||(collision.transform.tag == "LeftHand"))
        {
            print(this.transform.tag);
            if (this.transform.tag == "start_button")
            {
                GameObject.FindWithTag("system").GetComponent<Test2_System>().GameStart = true;
                GameObject.FindWithTag("system").GetComponent<Test2_System>().reset = true;
                if (collision.transform.tag == "LeftHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().leftHandShock();
                }
                else if (collision.transform.tag == "RightHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().rightHandShock();
                }
            }
            if ((this.transform.tag == "hp_button"))
            {
                prev_time = Time.time;
                canChange = false;
                
            }
            if ((this.transform.tag == "time_button"))
            {
                prev_time = Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (useHP == true)
            {
                useHP = false;
            }
            else
            {
                useHP = true;
            }

        if ((other.transform.tag == "RightHand")||(other.transform.tag == "LeftHand"))
        {
            print(this.transform.tag);
            if (this.transform.tag == "start_button")
            {
                GameObject.FindWithTag("system").GetComponent<Test2_System>().GameStart = true;
                GameObject.FindWithTag("system").GetComponent<Test2_System>().reset = true;
                if (other.transform.tag == "LeftHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().leftHandShock();
                }
                else if (other.transform.tag == "RightHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().rightHandShock();
                }
            }
            else if ((this.transform.tag == "hp_button")&&(canChange))
            {
                print("123456");
                prev_time = Time.time;
                canChange = false;
                if (useHP == true)
                {
                    useHP = false;
                }
                else if (useHP == false)
                {
                    useHP = true;
                }
            }
            else if ((this.transform.tag == "time_button")&&(canChange))
            {
                prev_time = Time.time;
            }
        }
    }
}

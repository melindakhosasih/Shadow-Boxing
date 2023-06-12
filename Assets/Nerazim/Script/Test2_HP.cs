using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_HP : MonoBehaviour
{   
    public GameObject Icon;
    private bool useHP = false;
    private bool use_Shock = true;
    private bool canChange = false;

    private float prev_time;
    // Start is called before the first frame update
    void Start()
    {
        useHP = false;
        Icon.SetActive(true);
        prev_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - prev_time>1.5f)
        {
            canChange = true;
        }

        if (use_Shock)
        {
            Icon.SetActive(true);
        }
        else
        {
            Icon.SetActive(false);
        }
        //print(canChange);
        GameObject.FindWithTag("system").GetComponent<Test2_System>().useHP = useHP;
        GameObject.FindWithTag("system").GetComponent<Test2_System>().use_Shock = use_Shock;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if ((other.transform.tag == "LeftHand")||(other.transform.tag == "RightHand"))
        {
            if (canChange)
            {
                
                prev_time = Time.time;
                canChange = false;
                use_Shock = !use_Shock;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "LeftHand")||(collision.transform.tag == "RightHand"))
        {
            if (canChange)
            {
                if (collision.transform.tag == "LeftHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().leftHandShock();
                }
                else if (collision.transform.tag == "RightHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().rightHandShock();
                }
                prev_time = Time.time;
                canChange = false;
                use_Shock = !use_Shock;
            }
        }
    }
}

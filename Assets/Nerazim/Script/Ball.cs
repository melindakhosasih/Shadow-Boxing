using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindWithTag("EventSystem").GetComponent<new_Tutorial>().HitNumber += 1;
        
        Destroy(this.gameObject);
        if (other.gameObject.tag == "RightHand")
        {
            GameObject.FindWithTag("EventSystem").GetComponent<new_Tutorial>().HitNumber += 1;
            print("RightHand Hit");
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "LeftHand")
        {
            GameObject.FindWithTag("EventSystem").GetComponent<new_Tutorial>().HitNumber += 1;
            print("LeftHand Hit");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "RightHand")
        {
            GameObject.FindWithTag("BallMission").GetComponent<BallMission>().HitNumber += 1;
            print("RightHand Hit");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "LeftHand")
        {
            GameObject.FindWithTag("BallMission").GetComponent<BallMission>().HitNumber += 1;
            print("LeftHand Hit");
            Destroy(this.gameObject);
        }
    }
}

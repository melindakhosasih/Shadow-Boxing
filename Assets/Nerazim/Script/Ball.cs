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

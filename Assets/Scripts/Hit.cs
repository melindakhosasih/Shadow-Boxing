using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy_RightHand")
        {
            print("Right Hit");
            other.gameObject.tag = "Enemy_RightHand_Inactive";
        }
        
        if(other.gameObject.tag == "Enemy_LeftHand")
        {
            print("Left Hit");
            other.gameObject.tag = "Enemy_LeftHand_Inactive";
        }
    }

    void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Enemy_RightHand_Inactive") other.gameObject.tag = "Enemy_RightHand";
        if(other.gameObject.tag == "Enemy_LeftHand_Inactive") other.gameObject.tag = "Enemy_LeftHand";
    }

}

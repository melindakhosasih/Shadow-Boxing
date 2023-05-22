using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetection : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(gameObject.tag == "Body") print("Hit!");
        else if(gameObject.tag == "LeftHand" || gameObject.tag == "RightHand") print("Block!");

        if(other.gameObject.tag == "Enemy_RightHand") other.gameObject.tag = "Enemy_RightHand_Inactive";
        
        if(other.gameObject.tag == "Enemy_LeftHand") other.gameObject.tag = "Enemy_LeftHand_Inactive";
    }

    void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Enemy_RightHand_Inactive") other.gameObject.tag = "Enemy_RightHand";
        if(other.gameObject.tag == "Enemy_LeftHand_Inactive") other.gameObject.tag = "Enemy_LeftHand";
    }

}

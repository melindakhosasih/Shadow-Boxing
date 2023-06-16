using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuchangescene : MonoBehaviour
{
    public string nextScene ="Tutorial";
    bool next = false;

    void OnCollisionEnter(Collision other)
    {
        if(!next && other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand"){ 
            next=true;
            GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        }
    }
}

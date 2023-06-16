using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuchangescene : MonoBehaviour
{
    public string nextScene ="Tutorial";

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand"){
            GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        }
    }
}

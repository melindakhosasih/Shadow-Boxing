using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuchangescene : MonoBehaviour
{
    public string nextScene ="Tutorial";
    bool next = false;
    void OnTriggerEnter(Collider other)
    {
        if(!next && other.gameObject.name == "Direct Interactor"){
            next=true;
            GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuchangescene : MonoBehaviour
{
    public string nextScene ="Tutorial";

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Direct Interactor"){
            GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        }
    }
}

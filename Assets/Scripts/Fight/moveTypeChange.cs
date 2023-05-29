using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTypeChange : MonoBehaviour
{
    public string type;
    public isFacingScript isFacing;

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "LeftHand")
        {
            if(type == "JabBlock") obj.gameObject.tag = "LeftJabBlock";
            else if(type == "HookBlock") obj.gameObject.tag = "LeftHookBlock";
            else if(type == "Jab") obj.gameObject.tag = "LeftJab";
            else if(type == "Hook") obj.gameObject.tag = "LeftHook";
        }
        else if(obj.gameObject.tag == "RightHand")
        {
            if(type == "JabBlock") obj.gameObject.tag = "RightJabBlock";
            else if(type == "HookBlock") obj.gameObject.tag = "RightHookBlock";
            else if(type == "Jab") obj.gameObject.tag = "RightJab";
            else if(type == "Hook") obj.gameObject.tag = "RightHook";
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == "LeftJabBlock" || 
        obj.gameObject.tag == "LeftHookBlock" || 
        obj.gameObject.tag == "LeftJab" || 
        obj.gameObject.tag == "LeftHook")
            obj.gameObject.tag = "LeftHand";
        if(obj.gameObject.tag == "RightJabBlock" || 
        obj.gameObject.tag == "RightHookBlock" || 
        obj.gameObject.tag == "RightJab" || 
        obj.gameObject.tag == "RightHook")
            obj.gameObject.tag = "RightHand";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFacingScript : MonoBehaviour
{
    public bool isFacing = false;

    void OnTriggerEnter(Collider obj)
    {  
        if(obj.gameObject.tag == "Body")
        {
            isFacing = true;
        }
        else
        {
            isFacing = false; 
        }
    }

    void OnTriggerExit(Collider obj)
    {  
        if(obj.gameObject.tag == "Body")
        {
            isFacing = false;
        }
    }
}

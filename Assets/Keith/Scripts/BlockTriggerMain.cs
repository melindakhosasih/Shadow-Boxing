using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTriggerMain : MonoBehaviour
{
    private int handCounter = 0;
    public GameObject body;

    void Start()
    {

    }

    void Update()
    {
        if(handCounter == 2)
        {
            body.SetActive(false);
        }
        else
        {
            body.SetActive(true);
        }   
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "LeftHand" || obj.gameObject.tag == "RightHand")
        {
            handCounter += 1;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == "LeftHand" || obj.gameObject.tag == "RightHand")
        {
            handCounter -= 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    private int handCounter = 0;

    void Start()
    {
        print(handCounter);
    }

    void Update()
    {
        if(handCounter == 2)
        {
            FightManager.GetInstance().OnBlock();
        }
        else
        {
            FightManager.GetInstance().OffBlock();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Enemy_LeftHand" || obj.gameObject.tag == "Enemy_RightHand")
        {
            EventManager.GetInstance().IncrementIndex();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jabCollision : MonoBehaviour
{
    public int num;
    public string type;
    public GameObject other;
    public tutorialManagerAdvanced TM;

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == type && num == 0)
        {
            other.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == type && num == 1)
        {
            other.SetActive(true);
            gameObject.SetActive(false);
            TM.trigger();
        }
    }
}

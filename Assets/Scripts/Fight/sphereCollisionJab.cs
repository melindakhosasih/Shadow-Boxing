using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollisionJab : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    public GameObject block1;
    public GameObject block2;

    public tutorialManagerAdvanced TM;

    public string tag1;
    public string tag2;

    public float threshhold = 2f;
    
    private float timer = 0f;
    
    private void Update()
    {
        if (target1.tag == tag1 && target2.tag == tag2)
        {
            timer += Time.deltaTime;

            if (timer >= threshhold)
            {
                block1.SetActive(false);
                block2.SetActive(false);
                TM.trigger();
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }
}

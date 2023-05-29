using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollision : MonoBehaviour
{
    public GameObject target;
    public tutorialManagerAdvanced TM;
    public string tag;
    public float threshhold = 2f;
    
    private float timer = 0f;
    
    private void Update()
    {
        if (target.tag == tag)
        {
            timer += Time.deltaTime;

            if (timer >= threshhold)
            {
                gameObject.SetActive(false);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitdetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Body")
        {
            GameObject.FindWithTag("Enemy").GetComponent<DodgeAnimator>().gotHit = true;
            print("Hit Body");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.tag == "Body")
        {
            GameObject.FindWithTag("Enemy").GetComponent<DodgeAnimator>().gotHit = true;
            print("Hit Body");
        }
    }
}

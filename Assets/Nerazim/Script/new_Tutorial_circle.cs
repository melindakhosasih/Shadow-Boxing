using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_Tutorial_circle : MonoBehaviour
{
    public GameObject circle;
    
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
        GameObject.FindWithTag("EventSystem").GetComponent<new_Tutorial>().Mission1_Complete = true;
        Destroy(circle);
    }
}

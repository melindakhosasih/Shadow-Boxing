using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position2 : MonoBehaviour
{
    public GameObject camera_offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = camera_offset.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuUIanimation : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, speed, 0.0f, Space.World);
    }
}
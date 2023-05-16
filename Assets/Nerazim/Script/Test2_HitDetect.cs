using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test2_HitDetect : MonoBehaviour
{
    public RawImage rawImage;
    public float fadeSpeed = 1;
    private float imageAlpha = 20f;
    public RectTransform rectTransform;
   
    // Start is called before the first frame update
    void Start()
    {
    
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.color =  Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hit body");
        if (other.transform.tag == "Body")
        {
            
            print("Hit Body");
            rawImage.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit body");
        if (collision.transform.tag == "Body")
        {
            
            print("Hit Body");
            rawImage.color = Color.red;
        }
    }
}
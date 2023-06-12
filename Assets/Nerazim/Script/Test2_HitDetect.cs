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

    public GameObject PlayerBody;

    private bool bodyDisappear = false;

    private float prev_time;
    // Start is called before the first frame update
    void Start()
    {
    
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        bodyDisappear = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rawImage.color =  Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.3f);
        if (bodyDisappear)
        {
            if (Time.time - prev_time >= 1f)
            {
                bodyDisappear = false;
                PlayerBody.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hit body");
        if (other.transform.tag == "Body")
        {
            
            print("Hit Body");
            rawImage.color = Color.red;
            GameObject.FindWithTag("system").GetComponent<Test2_System>().player_Got_hit = true;
        }
        else if (other.transform.tag == "GuardBlock")
        {
            
            PlayerBody.SetActive(false);
            bodyDisappear = true;
            prev_time = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit body");
        if (collision.transform.tag == "Body")
        {
            
            print("Hit Body");
            rawImage.color = Color.red;
            GameObject.FindWithTag("system").GetComponent<Test2_System>().player_Got_hit = true;
        }
        else if (collision.transform.tag == "Body")
        {
            bodyDisappear = true;
            PlayerBody.SetActive(false);
            prev_time = Time.time;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleclicksetting : MonoBehaviour
{
    float lastTimeClicked;
    float maxTimeBetweenClicks = 0.1f; // half a second
    void Start()
    {
        lastTimeClicked = 0f;
    }

    // Update is called once per frame
    void Update(){}  
    public void BButtonPressed(){
        float deltaTime = Time.time - lastTimeClicked;
        if(deltaTime < maxTimeBetweenClicks){
            GameObject.Find("script").GetComponent<changescene>().change("setting");
        }
        lastTimeClicked = Time.time;
    }
    public void XButtonPressed(){
        PlayerPosition playerPosition = new PlayerPosition();
        playerPosition.ResetPosition();
    }
}

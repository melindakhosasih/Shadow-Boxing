using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settingUIslider : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Image> icon;
    private float va;
    public List<AudioSource> audio;
    float playerx,playerz;
    GameObject player;
    public Text tmp;
    void Start()
    {
        player= GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        playerx= player.GetComponent<Transform>().position.x;
        playerz= player.GetComponent<Transform>().position.z;
        if (playerx<-0.5){
            changelevel("DIFFICULT");
        }
        else if (playerx> 0.5){
            changelevel("EASY");
        }
    }
    
    public void OnValueChanged(float newValue)
    {
        foreach (var au in audio)
        {
            au.volume = newValue;            
        }
        foreach (var im in icon)
        {
            im.GetComponent<RectTransform>().anchoredPosition = new Vector2(newValue*286.5f,-2.63f);           
        }
    }

    public void changelevel(string level){
        tmp.text = level;
    }
}

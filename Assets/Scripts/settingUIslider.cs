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
        //player.GetComponent<Transform>().position.x = 0f;
        //player.GetComponent<Transform>().position.z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerx= player.GetComponent<Transform>().position.x;
        playerz= player.GetComponent<Transform>().position.z;
        if (playerx<-0.5 || ((playerz<-0.5 || playerz>0.5) && playerx<=0)){
            changelevel("DIFFICULT");
        }
        else if (playerx>0.5 || ((playerz<-0.5 || playerz>0.5) && playerx>0)){
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
        float v = global.volume; //將全域變數存下來
        global.volume = newValue; //直接修改全域變數
    }

    public void changelevel(string level){
        tmp.text = level;
    }

    public void changescene(){
        GameObject.Find("script").GetComponent<changescene>().change(global.prescene);
    }
}

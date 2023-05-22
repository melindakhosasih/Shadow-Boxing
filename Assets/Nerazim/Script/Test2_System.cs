using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Test2_System : MonoBehaviour
{
    public bool GameStart = false;

    public bool endGame = false;

    public GameObject settingBoard;

    public GameObject scoreBoard;

    public GameObject enemy;
    
    public RawImage rawImage;
    
    public bool reset = false;
    
    public float fadeSpeed = 2.5f;

    public int round_time = 180;
    public bool useHP = false;
    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        endGame = false;
        settingBoard.SetActive(true);
        scoreBoard.SetActive(false);
        enemy.transform.position = new Vector3(1000,10000,1000);
        reset = false;
        round_time = 180;
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.color =  Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        if (reset)
        {
            reset = false;
            objectSetting();
        }
        //print(round_time);
        //print(useHP);
    }

    void objectSetting()//設定場上物件
    {
        if (GameStart)
        {
            resetPosition();
            settingBoard.SetActive(false);
            scoreBoard.SetActive(true);
            scoreBoard.GetComponent<Test2_ScoreBoard>().startTime = Time.time;
            enemy.SetActive(true);
            
        }
        else
        {
            settingBoard.SetActive(true);
            scoreBoard.SetActive(false);
            enemy.SetActive(false);
        }
    }

    void resetPosition()
    {
        enemy.transform.position = new Vector3(0,0,1.541f);
        
    }
}

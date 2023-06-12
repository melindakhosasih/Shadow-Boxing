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

    public string difficulity = "Easy";

    public bool player_Got_hit = false;

    public bool player_camera_need_to_rotate = false;

    public float prev_time;

    public string direction = "Right";

    public bool use_Shock = true;
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
        difficulity = "Easy";
        player_Got_hit = false;
        player_camera_need_to_rotate = false;//
        prev_time = -3f;
        direction = "Right";
        use_Shock = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player_Got_hit == true)//不讓玩家鏡頭連續轉動
        {
            if (Time.time - prev_time > 3f)
            {
                prev_time = Time.time;
                player_camera_need_to_rotate = true;
                
            }
            player_Got_hit = false;
        }
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
            
            settingBoard.SetActive(false);
            scoreBoard.SetActive(true);
            scoreBoard.GetComponent<Test2_ScoreBoard>().startTime = Time.time;
            enemy.SetActive(true);
            resetPosition();
            difficulitySetting();
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
        enemy.transform.position = new Vector3(0,1.6f,1.541f);
        
    }

    void difficulitySetting()
    {
        if (difficulity == "Easy")
        {
            GameObject T = GameObject.FindWithTag("Enemy");
            T.GetComponent<Test2>().qHitCooldown = 3.5f;
            T.GetComponent<Test2>().sHitCooldown = 3f;
        }
        else if (difficulity == "Medium")
        {
            GameObject T = GameObject.FindWithTag("Enemy");
            T.GetComponent<Test2>().qHitCooldown = 2.5f;
            T.GetComponent<Test2>().sHitCooldown = 2f;
        }
        else if (difficulity == "Hard")
        {
            GameObject T = GameObject.FindWithTag("Enemy");
            T.GetComponent<Test2>().qHitCooldown = 1.5f;
            T.GetComponent<Test2>().sHitCooldown = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animation ani;
    
    public string [] attackLists;

    public string[] defendLists;

    private int ListNum;

    private int defListNum;

    private string attackAni;

    private string defendAni;

    private bool canHit;

    private float prev_time;

    private float atkCooldown = 5f;

    public float qHitCooldown = 2f;

    public float sHitCooldown = 5f;
    public bool move = false;

    public bool playerHit = false;

    public GameObject playerBody;

    private string dif;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        canHit = false;
        ListNum = attackLists.Length;
        defListNum = defendLists.Length;
        prev_time = Time.time;
        move = false;
        playerHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print(defendAni);
        dif = GameObject.FindWithTag("system").GetComponent<Test2_System>().difficulity;
        
        if (playerHit)
        {
            playerHit = false;
            defendAni = selectNextAnimation("def");
            playAnimation(defendAni);
            if (defendAni == "Dodge")
            {
                defendAni = "Waiting";
            }
        }
        else if (canHit)
        {
            attackAni = selectNextAnimation("atk");
            playAnimation(attackAni);
        }
        else
        {
            
            playAnimation(defendAni);
        }
        
        
        if (Time.time - prev_time > atkCooldown)
        {
            canHit = true;
            prev_time = Time.time;
        }
    }

    void playAnimation(string action)
    {
        
        if (action != "got_punch")
        {
            if (ani.isPlaying||move)
            {
                return;
            }
        }
        
        if (action == "got_punch")
        {
            float probablity = 0f;
            if (dif == "Easy")
            {
                probablity = 30f;
            }
            else if (dif == "Medium")
            {
                probablity = 20f;
            }
            else if (dif == "Hard")
            {
                probablity = 10f;
            }
            float prob = Random.Range(0.0f, 100.0f);
            if (prob > probablity)
            {
                return;
            }
            
        }
        ani.Play(action);
        if (((action == "Waiting")||(action == "Dodge"))||(action=="Guard"))
        {
            this.GetComponent<Test2_move>().hitAniPlay = false;
            playerBody.SetActive(false);
        }
        else
        {
            this.GetComponent<Test2_move>().hitAniPlay = true;
            playerBody.SetActive(true);
        }
        
        if (action == "HookRight")
        {
            atkCooldown = qHitCooldown;
        }
        else if (action == "Combo")
        {
            atkCooldown = sHitCooldown;
        }
        else if (action == "Hook_Left")
        {
            atkCooldown = qHitCooldown;
        }
        else if (action == "Jab_Right")
        {
            atkCooldown = qHitCooldown-0.5f;
        }
        canHit = false;
    }
    string selectNextAnimation(string type)
    {
        if (type == "atk")
        {
            int rand = Random.Range(0,ListNum);
            return attackLists[rand];
        }
        else if (type == "def")
        {
            int rand = Random.Range(0,defListNum);
            return defendLists[rand];
        }

        return "Waiting";
    }

    public void Play_Got_Punch_Ani()
    {
       
        playAnimation("got_punch");
        canHit = false;
    }

    public void checkDifficulity(string action)
    {
        
        if (action == "got_punch")
        {
            string dif = GameObject.FindWithTag("system").GetComponent<Test2_System>().difficulity;
            float probablity = 0f;
            if (dif == "Easy")
            {
                probablity = 30f;
            }
            else if (dif == "Medium")
            {
                probablity = 20f;
            }
            else if (dif == "Hard")
            {
                probablity = 10f;
            }
            float prob = Random.Range(0.0f, 100.0f);
            if (prob > probablity)
            {
                return;
            }
        }
    }
}

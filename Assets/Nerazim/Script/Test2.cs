using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private Animation ani;
    
    public string [] attackLists;

    private int ListNum;

    private string attackAni;

    private bool canHit;

    private float prev_time;

    private float atkCooldown = 5f;

    public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        canHit = false;
        ListNum = attackLists.Length;
        prev_time = Time.time;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canHit)
        {
            attackAni = selectNextAnimation();
            playAnimation(attackAni);
        }
        else
        {
            
            playAnimation("Waiting");
        }
        
        
        if (Time.time - prev_time > atkCooldown)
        {
            canHit = true;
            prev_time = Time.time;
        }
    }

    void playAnimation(string action)
    {
        if (ani.isPlaying||move)
        {
            return;
        }

        ani.Play(action);
        if (action == "Waiting")
        {
            this.GetComponent<Test2_move>().hitAniPlay = false;
        }
        else
        {
            this.GetComponent<Test2_move>().hitAniPlay = true;
        }
        
        if (action == "HookRight")
        {
            atkCooldown = 2f;
        }
        else if (action == "Combo")
        {
            atkCooldown = 5f;
        }
        else if (action == "Hook_Left")
        {
            atkCooldown = 2f;
        }
        else if (action == "Jab_Right")
        {
            atkCooldown = 1.5f;
        }
        canHit = false;
    }
    string selectNextAnimation()
    {
        int rand = Random.Range(0,ListNum);
        return attackLists[rand];
    }
    
    
}

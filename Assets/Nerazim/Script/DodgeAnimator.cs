using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DodgeAnimator : MonoBehaviour
{
    Animator animator;
    public GameObject UI;
    private float prev_time = 0f;
    private float prev_time2 = 0f;
    private int i;
    private int DodgeTime = 0;
    private bool rand = false;
    public bool gotHit = true;
    private bool block = false;
    private bool StartHit = false;
    private bool canAttack = false;

    public bool OutOfRange = false;
    // Start is called before the first frame update
    void Start()
    {
        DodgeTime = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        print(rand);
        if (Time.time - prev_time >= 5f)//5秒攻擊一次
        {
            canAttack = true;
            prev_time = Time.time;
            gotHit = false;
            StartHit = true;
        }

        if (canAttack)//如果可以攻擊
        {
            if (Time.time - prev_time >= 1f)//給unity1秒判斷可以攻擊
            {
                canAttack = false;
            }
            animator.SetBool("Hit", true);//攻擊
        }
        else
        {
            animator.SetBool("Hit", false);
        }

        if ((StartHit)&&(Time.time - prev_time > 3f))//執行攻擊3秒後檢查有無擊中
        {
            if (gotHit == false)//如果沒被擊中
            {
                if (DodgeTime <= 2)
                {
                    DodgeTime += 1;//閃躲次數+1
                }
                
            }

            StartHit = false;
            gotHit = true;//繼續下一輪判斷
        }

        if (OutOfRange)
        {
            gotHit = true;
        }
        //print(i);
        UI.gameObject.GetComponent<Text>().text = "Dodge in the circle("+DodgeTime+"/3)";
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAnimator : MonoBehaviour
{
    Animator animator;

    private float prev_time = 0f;
    private float prev_time2 = 0f;
    private int i;
    private bool rand = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time - prev_time > 1f)
        {
            prev_time = Time.time;
            i = UnityEngine.Random.Range( 0, 1000 );
        }
        
        if (i > 800)
        {
            animator.SetBool("Hit", true);
        }
        else
        {
            animator.SetBool("Hit", false);
        }
        
        print(i);
        
        
    }
}

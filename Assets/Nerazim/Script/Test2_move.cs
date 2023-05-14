using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_move : MonoBehaviour
{
    public GameObject target;
    private Animation ani;
    private Vector2 v2Target;
    private Vector2 v2;
    private float distance;

    public bool hitAniPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        hitAniPlay = false;
        ani = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        if (!hitAniPlay)
        {
            MoveToPlayer();
        }
        
    }
    void playAnimation(string action)
    {
        this.GetComponent<Test2>().move = true;
        //if (ani.isPlaying)
        //{
        //    return;
        //}

        ani.Play(action);
    }

    void MoveToPlayer()
    {
        calcDistance();
        if (distance > 1f)
        {
            Vector3 D = new Vector3(this.transform.position.x - target.transform.position.x, 0,
                this.transform.position.z - target.transform.position.z).normalized;
            this.transform.Translate(D*Time.deltaTime);
            playAnimation("move_forward");
        }
        else
        {
            this.GetComponent<Test2>().move = false;
        }
    }
    void LookAtPlayer()
    {
        transform.LookAt(new Vector3(target.transform.position.x,this.transform.position.y,target.transform.position.z));
    }
    void calcDistance()
    {
        v2Target = new Vector2(target.transform.position.x, target.transform.position.z);
        v2 = new Vector2(transform.position.x, transform.position.z);
        distance = (v2Target - v2).magnitude;
    }
}

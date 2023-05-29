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

    public bool restart = false;//重製回原始位置

    public bool Game_start = false;
    // Start is called before the first frame update
    void Start()
    {
        hitAniPlay = false;
        ani = GetComponent<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Game_start = GameObject.FindWithTag("system").GetComponent<Test2_System>().GameStart;
        if (Game_start)
        {
            canMove();
            LookAtPlayer();
            if (!hitAniPlay)
            {
                MoveToPlayer();
            }
        }
        else
        {
            playAnimation("Waiting");
            dontMove();
        }
        
        if (restart)
        {
            restart = false;
        }
    }

    void dontMove()
    {
        this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
            RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | 
                                                               RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void canMove()
    {
        this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

    }
    void resetPosition()
    {
        this.transform.position = new Vector3(0,0,1.541f);
        this.transform.rotation = new Quaternion(0, 1, 0, 0);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 rotateValue;
    public bool got_hit = false;
    public float time = 0;
    public float back_time = 0;
    public float rotate_speed = 2f;
    public float rotate_time;
    public GameObject camera;
    private bool camera_need_rotate = false;
    void Start()
    {
        got_hit = true;
        rotate_speed = 3f;
        rotate_time = 45f;
        camera_need_rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        got_hit = GameObject.FindWithTag("system").GetComponent<Test2_System>().player_camera_need_to_rotate;
        if (got_hit)
        {
            camera_need_rotate = true;
            GameObject.FindWithTag("system").GetComponent<Test2_System>().player_camera_need_to_rotate = false;
        }
        if (camera_need_rotate)
        {
            string direction = GameObject.FindWithTag("system").GetComponent<Test2_System>().direction;
            if (direction == "Right")
            {
                if (time <= rotate_time)
                {
                    rotateValue = new Vector3(-1*rotate_speed,-1*rotate_speed, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    time = time + 1*rotate_speed;
                }
                else if((time >rotate_time)&&(back_time<=rotate_time))
                {
                    rotateValue = new Vector3(1*rotate_speed,1*rotate_speed, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    back_time = back_time + 1*rotate_speed;
                }
                else if (back_time>rotate_time)
                {
                    camera_need_rotate = false;
                    time = 0;
                    back_time = 0;
                }
            }
            else if(direction=="Left")
            {
                if (time <= rotate_time)
                {
                    rotateValue = new Vector3(-1*rotate_speed,1*rotate_speed, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    time = time + 1*rotate_speed;
                }
                else if((time >rotate_time)&&(back_time<=rotate_time))
                {
                    rotateValue = new Vector3(1*rotate_speed,-1*rotate_speed, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    back_time = back_time + 1*rotate_speed;
                }
                else if (back_time>rotate_time)
                {
                    camera_need_rotate = false;
                    time = 0;
                    back_time = 0;
                }
            }
            else if(direction=="Up")
            {
                if (time <= rotate_time)
                {
                    rotateValue = new Vector3(1*rotate_speed,0, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    time = time + 1*rotate_speed;
                }
                else if((time >rotate_time)&&(back_time<=rotate_time))
                {
                    rotateValue = new Vector3(-1*rotate_speed,0, 0);
                    transform.eulerAngles = transform.eulerAngles - rotateValue;
                    back_time = back_time + 1*rotate_speed;
                }
                else if (back_time>rotate_time)
                {
                    camera_need_rotate = false;
                    time = 0;
                    back_time = 0;
                }
            }
        }
        
    }
}

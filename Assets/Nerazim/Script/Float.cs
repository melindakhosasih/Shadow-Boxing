using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Float : MonoBehaviour
{
    private float radian = 0;

    public float perRadian = 2f; //速度

    private float radius = 0.6f; //半徑

    private Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        radian += perRadian*Time.deltaTime;
        float dy = Mathf.Cos(radian) * radius ;
        transform.position = oldPos + new Vector3(0, dy, 0);
    }
}

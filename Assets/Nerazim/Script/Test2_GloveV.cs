using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Test2_GloveV : MonoBehaviour
{
    private float speed;

    private Vector3 curPos;
    private Vector3 lastPos;

    private float detectSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        curPos = this.transform.position;
        lastPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Findspeed() > detectSpeed)
        {
            GameObject.FindWithTag("Enemy").GetComponent<Test2>().playerHit = true;
        }
    }

    float Findspeed()
    {
        curPos = this.transform.position;
        float _speed = (Vector3.Magnitude(curPos - lastPos) / Time.deltaTime);
        lastPos = curPos;
        return _speed;
    }
}

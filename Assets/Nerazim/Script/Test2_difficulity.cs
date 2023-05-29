using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Test2_difficulity : MonoBehaviour
{
    public GameObject difficulity_;
    public string difficulity;
    private float prev_time;
    private bool canChange = true;
    // Start is called before the first frame update
    void Start()
    {
        difficulity = "Easy";
        difficulity_.gameObject.GetComponent<TextMeshPro>().text = "  "+difficulity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - prev_time>1.5f)
        {
            canChange = true;
        }
        GameObject.FindWithTag("system").GetComponent<Test2_System>().difficulity = difficulity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "LeftHand")||(collision.transform.tag == "RightHand"))
        {
            if (canChange)
            {
                if (collision.transform.tag == "LeftHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().leftHandShock();
                }
                else if (collision.transform.tag == "RightHand")
                {
                    GameObject.FindWithTag("system").GetComponent<shock>().rightHandShock();
                }
                prev_time = Time.time;
                canChange = false;
                if(difficulity=="Easy")
                {
                    difficulity = "Medium";
                    difficulity_.gameObject.GetComponent<TextMeshPro>().text = difficulity;
                }
                else if(difficulity=="Medium")
                {
                    difficulity = "Hard";
                    difficulity_.gameObject.GetComponent<TextMeshPro>().text = "  "+difficulity;
                }
                else if(difficulity=="Hard")
                {
                    difficulity = "Easy";
                    difficulity_.gameObject.GetComponent<TextMeshPro>().text = "  "+difficulity;
                }
            }
        }
    }
}

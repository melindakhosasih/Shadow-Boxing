using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if ((other.transform.tag == "LeftHand")||(other.transform.tag == "RightHand"))
        {
            SceneManager.LoadScene("main");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "LeftHand")||(collision.transform.tag == "RightHand"))
        {
            SceneManager.LoadScene("main");
        }
    }
}

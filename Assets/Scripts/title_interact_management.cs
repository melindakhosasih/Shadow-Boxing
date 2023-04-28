using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_interact_management : MonoBehaviour
{
    public string nextScene ="Tutorial";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if(other.gameObject.tag=="LeftHand")
        {
            print("Left Hit");
        }
        else if(other.gameObject.tag=="RightHand")
        {
            print("Right Hit");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Direct Interactor"){
            Debug.Log("Next Scenes");
            SceneManager.LoadScene(nextScene);
        }
    }
}

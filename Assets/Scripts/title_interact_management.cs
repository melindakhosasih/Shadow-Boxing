using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_interact_management : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Direct Interactor"){
            Debug.Log("Next Scenes");
        }
    }
}

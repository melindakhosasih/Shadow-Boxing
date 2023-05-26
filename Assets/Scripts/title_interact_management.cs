using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_interact_management : MonoBehaviour
{
    [SerializeField] private Transform shatterTransform;
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    public string nextScene ="Tutorial";
    // Start is called before the first frame update
    
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
        if(other.gameObject.name == "Direct Interactor"){
            //shatterTransform.gameObject.SetActive(true);
            firstPersonCamera.enabled = false;
            overheadCamera.enabled = true;
            Invoke("change", 0.5f);
        }
    }
    void change(){
        GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        CancelInvoke("change");
    }
}

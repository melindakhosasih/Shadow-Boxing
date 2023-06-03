using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title_interact_management : MonoBehaviour
{
    [SerializeField] private Transform shatterTransform;
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public AudioClip effect;
    public AudioSource audioSource;
    public Image black2;

    public string nextScene ="Tutorial";
    // Start is called before the first frame update
    void Start(){
        audioSource.volume=global.volume;
    }
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
            GameObject.Find("script").GetComponent<fade>().imagefadein(black2,0.5f, 0.01f);
            Invoke("change", 0.5f);
        }
    }
    void change(){
        GameObject.Find("script").GetComponent<changescene>().change(nextScene);
        audioSource.PlayOneShot(effect, 10F);
        CancelInvoke("change");
    }
}

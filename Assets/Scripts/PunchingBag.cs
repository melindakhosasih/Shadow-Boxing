using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    public AudioClip punchAudioClip;
    public GameObject [] steps;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        print("collide punching bag sound");
        audioSource.clip = punchAudioClip;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameanimation : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = global.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

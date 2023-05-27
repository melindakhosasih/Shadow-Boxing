using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video_Player : MonoBehaviour
{
    public RawImage image;
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        image.texture = video.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

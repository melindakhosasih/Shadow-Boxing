using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameanimation : MonoBehaviour
{
    public AudioSource audioSource;
    public SpriteRenderer UI;
    float Hue, range;
    // Start is called before the first frame update
    void Start()
    {
        Hue=0.05f;
        range = 0.02f;
        StartCoroutine(UIcolor(UI));
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator UIcolor(SpriteRenderer image){
        while(true){
            Debug.Log("here");
            Hue += range;
            if(Hue > 0.95 || Hue <0.05) range = -range ;
            image.color = Color.HSVToRGB(Hue, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

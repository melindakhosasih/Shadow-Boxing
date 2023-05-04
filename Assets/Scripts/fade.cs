using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void scenefadein(float speed,float wait){
        image = GameObject.Find("black").GetComponent<Image>();
        StartCoroutine(fadeoutanimation(speed,wait));
    }
    public void scenefadeout(float speed,float wait){
        image = GameObject.Find("black").GetComponent<Image>();
        StartCoroutine(fadeinanimation(speed,wait));
    }

    IEnumerator fadeinanimation(float speed,float wait){
        while(image.color.a<1f){
            image.color = colorfadein(speed, image.color);
            yield return new WaitForSeconds(wait);
        }
    }

    IEnumerator fadeoutanimation(float speed,float wait){
        while(image.color.a>0f){
            image.color = colorfadeout(speed, image.color);
            yield return new WaitForSeconds(wait);
        }
    }

    public Color colorfadein(float speed, Color NewColor)
    {
        NewColor.a = NewColor.a + Time.deltaTime * speed; 
        return NewColor;
        
    }

    public Color colorfadeout(float speed, Color NewColor)
    {
        NewColor.a = NewColor.a - Time.deltaTime * speed; 
        return NewColor;
    }
}

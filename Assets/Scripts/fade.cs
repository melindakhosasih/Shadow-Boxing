using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void imagefadein(Image i, float speed,float wait){
        image = i;
        StartCoroutine(fadeinanimation(image,speed,wait));
    }
    
    public void scenefadein(float speed,float wait){
        image = GameObject.Find("black").GetComponent<Image>();
        StartCoroutine(fadeoutanimation(image,speed,wait));
    }
    public void scenefadeout(float speed,float wait){
        image = GameObject.Find("black").GetComponent<Image>();
        StartCoroutine(fadeinanimation(image,speed,wait));
    }

    IEnumerator fadeinanimation(Image i, float speed,float wait){
        while(i.color.a<1f){
            i.color = colorfadein(speed, i.color);
            yield return new WaitForSeconds(wait);
        }
    }

    IEnumerator fadeoutanimation(Image i, float speed,float wait){
        while(i.color.a>0f){
            i.color = colorfadeout(speed, i.color);
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

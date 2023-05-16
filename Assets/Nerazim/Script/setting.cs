using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue, volumnslidewidth;

    public Image volumnimage, volumnicon1, volumnicon2;

    void Start()
    {
        //Initiate the Slider value to half way
        m_MySliderValue = 0.5f;
        //Fetch the AudioSource from the GameObject
        //m_MyAudioSource = GetComponent<AudioSource>();
        //Play the AudioClip attached to the AudioSource on startup
        //m_MyAudioSource.Play();
        volumnslidewidth = 152.4f;
        m_MyAudioSource.volume = m_MySliderValue;
        setUI(volumnimage);
    }

    void setUI(Image ui)
    {
        //ui.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 72/2, 0);
        RectTransform rt = ui.GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(volumnslidewidth*m_MySliderValue - volumnslidewidth/2, rt.offsetMax.y);   
        volumnicon1.GetComponent<RectTransform>().anchoredPosition = new Vector2(volumnslidewidth*m_MySliderValue, 0);
        volumnicon2.GetComponent<RectTransform>().anchoredPosition = new Vector2(volumnslidewidth*m_MySliderValue, 0);
        //rt.offsetMax = new Vector2(72/2, rt.offsetMax.y);        
    }


}

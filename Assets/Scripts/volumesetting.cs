using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumesetting : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    // Start is called before the first frame update

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        //musicSlider.onValueChanged.AddListener(SetMusicVolume);
        Debug.Log("here");
    }

    public void SetMusicVolume(float value)
    {
                Debug.Log("have?");
        Debug.Log(value);
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);
    }
}

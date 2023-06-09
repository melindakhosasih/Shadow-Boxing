using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    [Header("UI")]
    [SerializeField] private TMP_Text textFirst;
    [SerializeField] private TMP_Text textSecond;
    [SerializeField] private Image img;
    [SerializeField] private VideoPlayer video;

    public string[] textFirstSequence;
    public string[] textSecondSequence;
    public Sprite[] imgSequence;
    public VideoClip[] videoSequence;
    public GameObject videoBox;
    public GameObject UI;

    private int time_;
    private int idx = 0;
    private int textFirstIdx = 0;
    private int textSecondIdx = 0;
    private int imgIdx = 0;
    private int videoIdx = 0;
    private float elapsedTime;
    private bool showImage = true;
    private bool showVideo = false;
    private float prev_time;

    public int sideMode = 0;
    public bool tutorialInProgress;
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one event manager detected");
        }
        instance = this;
    }

    public static EventManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        tutorialInProgress = false;
    }

    public void IncrementIndex()
    {
        idx += 1;
        adjustValues();
    }

    public void DecrementIndex()
    {
        if(idx != 0) idx -= 1;
        else idx = 0;
        adjustValues();
    }

    private void adjustValues()
    {
        switch(idx)
        {
            case 0: //Introduction
                break;
            case 1: //Main Menu
                textFirstIdx += 1;
                break;
            case 2: //Get Ready
                textFirstIdx += 1;
                break;
            case 3: //Block
                showVideo = true;
                showImage = false;
                textFirstIdx += 1;
                break;
            case 4: //Block Practice
                UI.SetActive(false);
                break;
            case 5: //Jab
                UI.SetActive(true);
                textFirstIdx += 1;
                videoIdx += 1;
                break;
            case 6: //Jab Practice
                UI.SetActive(false);
                break;
            case 7: //Hook
                UI.SetActive(true);
                textFirstIdx += 1;
                videoIdx += 1;
                break;
            case 8: //Hook Practice
                UI.SetActive(false);
                break;
            case 9: //Finish Tutorial
                UI.SetActive(true);
                showVideo = false;
                textFirstIdx += 1;
                textSecondIdx += 1;
                break;
            default:
                break;
        }
    }

    public bool CheckString(string value, string targetValue)
    {
        if (targetValue != value)
        {
            targetValue = value;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= 3f)
        {
            return true;
        }

        return false;
    }

    public bool CheckBool(bool value, bool targetValue)
    {
        if (targetValue != value)
        {
            targetValue = value;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= 3f)
        {
            return true;
        }

        return false;
    }

    void Update()
    { 
        //Image
        if(!showImage || imgIdx >= imgSequence.Length)
        {
            img.gameObject.SetActive(false);
        }
        else
        {
            img.gameObject.SetActive(true);
            img.sprite = imgSequence[imgIdx];
        }
        //Video
        if(!showVideo || videoIdx >= videoSequence.Length)
        {
            videoBox.SetActive(false);
        }
        else
        {
            videoBox.SetActive(true);
            video.clip = videoSequence[videoIdx];
        }
        //FirstRowText
        if(textFirstIdx < textFirstSequence.Length)
        {
            textFirst.text = textFirstSequence[textFirstIdx];
        }
        else
        {
            textFirst.text = "";
        }
        //SecondRowText
        if(textSecondIdx < textSecondSequence.Length)
        {
            textSecond.text = textSecondSequence[textSecondIdx];
        }
        else
        {
            textSecond.text = "";
        }
    }
}

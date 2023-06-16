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
    [SerializeField] private TMP_Text textInfo;
    [SerializeField] private Image img;
    [SerializeField] private VideoPlayer video;

    public Sprite[] imgSequence;
    public VideoClip[] videoSequence;
    public GameObject videoBox;
    public GameObject UI;

    private int timeCount;
    private int idx = 0;
    

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
        UpdateUI();
    }

    public void IncrementIndex()
    {
        idx += 1;
        UpdateUI();
    }

    public void IncrementTimeCount()
    {
        if(timeCount == 3)
        {
            IncrementIndex();
            return;
        }
        timeCount += 1;
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        switch(idx)
        {
            case 4:
                textSecond.text = "Jab the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 6:
                textSecond.text = "Left Hook the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 8:
                textSecond.text = "Right Hook the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 10:
                textSecond.text = "Block for " + (4 - timeCount).ToString() + "/3 seconds";
                break;
        }
        
    }

    void UpdateUI()
    {
        switch(idx)
        {
            case 0: //Introduction
                ExecuteTutorial();
                img.gameObject.SetActive(true);
                img.sprite = imgSequence[0];

                videoBox.SetActive(false);
                textInfo.gameObject.SetActive(false);

                textFirst.text = "Welcome to Shadow Boxing VR!";
                textSecond.text = "Press A to Continue...";
                break;
            case 1: //Main Menu
                textFirst.text = "Above are the configurations of the controllers";
                break;
            case 2: //Get Ready
                textFirst.text = "We will now begin the basic tutorial";
                break;
            case 3: //Jab
                videoBox.SetActive(true);
                video.clip = videoSequence[0];

                textInfo.gameObject.SetActive(true);
                textInfo.text = "Jab: A straight attack directly at the enemy, either hands are useable.";

                img.gameObject.SetActive(false);

                textFirst.gameObject.SetActive(false);
                break;
            case 4: //Jab Practice
                ExecuteTutorial(1);

                videoBox.SetActive(false);
                textInfo.gameObject.SetActive(false);
                textSecond.text = "Jab the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 5: //Left Hook
                ExecuteTutorial();

                videoBox.SetActive(true);
                video.clip = videoSequence[1];

                textInfo.gameObject.SetActive(true);
                textInfo.text = "Left Hook: A punch thrown in a circular motion with the left hand, the hand should land at the enemy's side.";

                textSecond.text = "Press A to Continue...";
                break;
            case 6: //Left Hook Practice
                ExecuteTutorial(2);

                videoBox.SetActive(false);
                textInfo.gameObject.SetActive(false);
                textSecond.text = "Left Hook the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 7: //Right Hook
                ExecuteTutorial();

                videoBox.SetActive(true);
                video.clip = videoSequence[2];

                textInfo.gameObject.SetActive(true);
                textInfo.text = "Right Hook: A punch thrown in a circular motion with the right hand, the hand should land at the enemy's side.";

                textSecond.text = "Press A to Continue...";
                break;
            case 8: //Right Hook Practice
                ExecuteTutorial(3);

                videoBox.SetActive(false);
                textInfo.gameObject.SetActive(false);
                textSecond.text = "Right Hook the Opponent " + TutorialManager.GetInstance().GetCounter() + "/2";
                break;
            case 9: //Block
                ExecuteTutorial();

                videoBox.SetActive(true);
                video.clip = videoSequence[3];

                textInfo.gameObject.SetActive(true);
                textInfo.text = "Block: A defensive stance done by raising both your hands to eye level. In this game, this prevents all attacks but is not true in real life";

                textSecond.text = "Press A to Continue...";
                break;
            case 10: //Block Practice
                timeCount = 0;
                videoBox.SetActive(false);
                textInfo.gameObject.SetActive(false);
                textFirst.gameObject.SetActive(false);
                textSecond.text = "Block for " + 3 + "/3 seconds";
                break;
            case 11: //Finish Tutorial
                textFirst.text = "Congratulations, you have finished the tutorial";
                textSecond.text = "Press 'A' to enter the game...";
                break;
            case 12:
                break;    
            default:
                break;
        }
    }

    private void ExecuteTutorial(int tutorialValue = 0)
    {
        EnemyBehaviourTutorial.GetInstance().ResetPosition(tutorialValue);
        TutorialManager.GetInstance().ToggleTutorial(tutorialValue);
    }

    void Update()
    { 
        
    }
}

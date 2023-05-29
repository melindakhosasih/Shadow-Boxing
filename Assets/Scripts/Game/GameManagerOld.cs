using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerOld : MonoBehaviour
{
    public GameObject timeGameObject;
    public GameObject playerScoreGameObject;
    public GameObject enemyScoreGameObject;
    // private TextMeshPro time;
    private Text timeString;
    private Text playerScoreString;
    private Text enemyScoreString;
    private int curTime;
    private int duration = 180;
    private string timeMin;
    private string timeSec;
    private int playerScore = 0;
    private int enemyScore = 0;
    private bool gameOver = false;
    // Start is called before the first frame update

    void Awake(){
        // time = timeGameObject.GetComponent<TextMeshPro>();
        timeString = timeGameObject.GetComponent<Text>();
        playerScoreString = playerScoreGameObject.GetComponent<Text>();
        enemyScoreString = enemyScoreGameObject.GetComponent<Text>();
    }
    void Start()
    {
        // initialize time duration
        curTime = duration;
        timeString.text = getTime(curTime);
        InvokeRepeating("decreaseTime", 1.0f, 1.0f);

        // initialize score
        playerScoreString.text = playerScore.ToString();
        enemyScoreString.text = enemyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update time
        timeString.text = getTime(curTime);

        if (gameOver) {
            changeScene("Tutorial");
        }
    }

    string getTime(int t) {
        timeMin = string.Format("{0:00}", t / 60);
        timeSec = string.Format("{0:00}", t % 60);
        return timeMin + ":" + timeSec;
    }

    void decreaseTime() {
        if (curTime > 0) {
            curTime -= 1;
        } else {
            gameOver = true;
        }
    }

    void changeScene(string scene) {
        global.prescene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public void updateEnemyScore(int x) {
        enemyScore += x;
        enemyScoreString.text = enemyScore.ToString();
    }

    public void updatePlayerScore(int x) {
        playerScore += x;
        playerScoreString.text = playerScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerScoreGameObject;
    public GameObject enemyScoreGameObject;
    private TextMeshPro playerScoreString;
    private TextMeshPro enemyScoreString;
    private int playerScore = 0;
    private int enemyScore = 0;
    private bool playerLeftPunching = false;
    private bool playerRightPunching = false;
    private bool enemyLeftPunching = false;
    private bool enemyRightPunching = false;

    void Awake(){
        playerScoreString = playerScoreGameObject.GetComponent<TextMeshPro>();
        enemyScoreString = enemyScoreGameObject.GetComponent<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScoreString.text = playerScore.ToString();
        enemyScoreString.text = enemyScore.ToString();
        playerLeftPunching = false;
        playerRightPunching = false;
        enemyLeftPunching = false;
        enemyRightPunching = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateEnemyScore(int x) {
        enemyScore += x;
        enemyScoreString.text = enemyScore.ToString();
    }

    public void updatePlayerScore(int x) {
        playerScore += x;
        playerScoreString.text = playerScore.ToString();
    }

    public bool isPlayerLeftPunch() {
        return playerLeftPunching;
    }

    public bool isPlayerRightPunch() {
        return playerRightPunching;
    }

    public bool isEnemyLeftPunch() {
        return enemyLeftPunching;
    }

    public bool isEnemyRightPunch() {
        return enemyRightPunching;
    }

    public void setPlayerLeftPunch(bool state) {
        playerLeftPunching = state;
    }

    public void setPlayerRightPunch(bool state) {
        playerRightPunching = state;
    }

    public void setEnemyLeftPunch(bool state) {
        enemyLeftPunching = state;
    }

    public void setEnemyRightPunch(bool state) {
        enemyRightPunching = state;
    }
}

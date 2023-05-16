using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider) {
        if (gameObject.tag == "Enemy_LeftHand") {
            if(collider.other.tag == "Player") {
                gameManager.updateEnemyScore(1);
            }
        } else if(gameObject.tag == "Enemy_RightHand") {
            if(collider.other.tag == "Player") {
                gameManager.updateEnemyScore(1);
            }
        }
    }
}

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

    // void OnCollisionEnter(Collision collider) {
    //     if (gameObject.tag == "Enemy_LeftHand" && !gameManager.isEnemyLeftPunch()) {
    //         // if(collider.collider.tag == "Player") {
    //         if(collider.collider.tag == "Body") {
    //             // print("enemy hit player");
    //             gameManager.setEnemyLeftPunch(true);
    //             gameManager.updateEnemyScore(1);
    //         }
    //     } else if(gameObject.tag == "Enemy_RightHand" && !gameManager.isEnemyRightPunch()) {
    //         // if(collider.collider.tag == "Player") {
    //         if(collider.collider.tag == "Body") {
    //             // print("enemy hit player");
    //             gameManager.setEnemyRightPunch(true);
    //             gameManager.updateEnemyScore(1);
    //         }
    //     }
    // }

    // void OnCollisionExit(Collision collider) {
    //     if (gameObject.tag == "Enemy_LeftHand") {
    //         // if(collider.collider.tag == "Player") {
    //         if(collider.collider.tag == "Body") {
    //             // print("enemy hit player");
    //             gameManager.setEnemyLeftPunch(false);
    //         }
    //     } else if(gameObject.tag == "Enemy_RightHand") {
    //         // if(collider.collider.tag == "Player") {
    //         if(collider.collider.tag == "Body") {
    //             // print("enemy hit player");
    //             gameManager.setEnemyRightPunch(false);
    //         }
    //     }
    // }

    void OnTriggerEnter(Collider other) {
        if (gameObject.tag == "Enemy_LeftHand" && !gameManager.isEnemyLeftPunch()) {
            // if(collider.collider.tag == "Player") {
            if(other.GetComponent<Collider>().tag == "Body") {
                // print("enemy hit player");
                gameManager.setEnemyLeftPunch(true);
                gameManager.updateEnemyScore(1);
            }
            // else if (other.GetComponent<Collider>().tag == "LeftHand") {
            //     other.transform.tag = "Player_Block_Left";
            //     print("change tag");
            // } else if (other.GetComponent<Collider>().tag == "RightHand") {
            //     other.transform.tag = "Player_Block_Right";
            //     print("change tag");
            // } 
        } else if(gameObject.tag == "Enemy_RightHand" && !gameManager.isEnemyRightPunch()) {
            // if(collider.collider.tag == "Player") {
            if(other.GetComponent<Collider>().tag == "Body") {
                // print("enemy hit player");
                gameManager.setEnemyRightPunch(true);
                gameManager.updateEnemyScore(1);
            }
            // else if (other.GetComponent<Collider>().tag == "Player_Block_Left") {
            //     other.transform.tag = "LeftHand";
            //     print("set back tag");
            // } else if (other.GetComponent<Collider>().tag == "Player_Block_Right") {
            //     other.transform.tag = "RightHand";
            //     print("set back tag");
            // } 
        }
    }

    void OnTriggerExit(Collider other) {
        if (gameObject.tag == "Enemy_LeftHand") {
            // if(collider.collider.tag == "Player") {
            if(other.GetComponent<Collider>().tag == "Body") {
                gameManager.setEnemyLeftPunch(false);
            }
            // else if (other.GetComponent<Collider>().tag == "LeftHand" || other.GetComponent<Collider>().tag == "RightHand") {
            //     other.transform.tag = "Enemy_LeftHand";
            // } 
        } else if(gameObject.tag == "Enemy_RightHand") {
            // if(collider.collider.tag == "Player") {
            if(other.GetComponent<Collider>().tag == "Body") {
                gameManager.setEnemyRightPunch(false);
            }
            // else if (other.GetComponent<Collider>().tag == "LeftHand" || other.GetComponent<Collider>().tag == "RightHand") {
            //     other.transform.tag = "Enemy_RightHand";
            // } 
        }
    }
}

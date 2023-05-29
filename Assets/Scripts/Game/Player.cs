using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    // void OnCollisionEnter(Collision other) {
    //     if (gameObject.tag == "LeftHand" && !gameManager.isPlayerLeftPunch()) {
    //         if(other.collider.tag == "Enemy") {
    //             // print("player hit enemy");
    //             gameManager.setPlayerLeftPunch(true);
    //             gameManager.updatePlayerScore(1);
    //         }
    //     } else if(gameObject.tag == "RightHand") {
    //         if(other.collider.tag == "Enemy" && !gameManager.isPlayerRightPunch()) {
    //             // print("player hit enemy");
    //             gameManager.setPlayerRightPunch(true);
    //             gameManager.updatePlayerScore(1);
    //         }
    //     }
    // }

    // void OnCollisionExit(Collision other) {
    //     if (gameObject.tag == "LeftHand") {
    //         if(other.collider.tag == "Enemy") {
    //             gameManager.setPlayerLeftPunch(false);
    //         }
    //     } else if(gameObject.tag == "RightHand") {
    //         if(other.collider.tag == "Enemy") {
    //             gameManager.setPlayerRightPunch(false);
    //         }
    //     }
    // }
    void OnTriggerEnter(Collider other) {
        if (gameObject.tag == "LeftHand" && !gameManager.isPlayerLeftPunch()) {
            if(other.GetComponent<Collider>().tag == "Enemy") {
                // print("player hit enemy");
                gameManager.setPlayerLeftPunch(true);
                gameManager.updatePlayerScore(1);
            }
        } else if(gameObject.tag == "RightHand") {
            if(other.GetComponent<Collider>().tag == "Enemy" && !gameManager.isPlayerRightPunch()) {
                // print("player hit enemy");
                gameManager.setPlayerRightPunch(true);
                gameManager.updatePlayerScore(1);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (gameObject.tag == "LeftHand") {
            if(other.GetComponent<Collider>().tag == "Enemy") {
                gameManager.setPlayerLeftPunch(false);
            }
        } else if(gameObject.tag == "RightHand") {
            if(other.GetComponent<Collider>().tag == "Enemy") {
                gameManager.setPlayerRightPunch(false);
            }
        }
    }
}

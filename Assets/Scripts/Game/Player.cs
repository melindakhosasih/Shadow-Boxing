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

    void OnCollisionEnter(Collision collider) {
        // print(collider.other.tag);
        if (gameObject.tag == "LeftHand") {
            if(collider.other.tag == "Enemy") {
                gameManager.updatePlayerScore(1);
            }
        } else if(gameObject.tag == "RightHand") {
            if(collider.other.tag == "Enemy") {
                gameManager.updatePlayerScore(1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private int enemyState;

    public int ID;

    void Start()
    {

    }
    
    void Update()
    {
        enemyState = EnemyBehaviourTutorial.GetInstance().State;
        if(enemyState == 0 || enemyState != ID)
        {
            Show();
        }
        else{
            Hide();
        }
    }

    void Hide()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void Show()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "LeftHand" || obj.gameObject.tag == "RightHand")
        {
            TutorialManager.GetInstance().IncrementCounter();
        }
        
    }

    void OnTriggerExit(Collider obj)
    {
        if(obj.gameObject.tag == "LeftHand" || obj.gameObject.tag == "RightHand")
        {
            // TutorialManager.GetInstance().ChangeMode(0);
        }
    }
}

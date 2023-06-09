using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private int EnemyState;

    public int ID;

    void Start()
    {

    }
    
    void Update()
    {
        EnemyState = EnemyBehaviourTutorial.GetInstance().State;
        if(EnemyState == 0 || EnemyState != ID)
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

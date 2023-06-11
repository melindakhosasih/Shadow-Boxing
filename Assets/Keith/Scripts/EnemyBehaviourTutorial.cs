using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTutorial : MonoBehaviour
{
    private static EnemyBehaviourTutorial instance;
    private Animator Anim;

    public int State {get; private set;}

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("more than one enemy behaviour manager detected");
        }
        instance = this;
    }

    public static EnemyBehaviourTutorial GetInstance()
    {
        return instance;
    }

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        State = (int)TutorialManager.GetInstance().enemyMode;
        Anim.SetInteger("Mode", State);

        int randomInteger = Random.Range(0, 4 + 1);
        Anim.SetInteger("Rand", randomInteger);
    }
}

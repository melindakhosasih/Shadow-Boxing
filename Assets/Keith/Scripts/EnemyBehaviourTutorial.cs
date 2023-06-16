using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTutorial : MonoBehaviour
{
    private static EnemyBehaviourTutorial instance;
    private Animator Anim;
    private bool Move;
    private Vector3 lookHere; 
    private Vector2 enemyLocation;
    private Vector2 playerLocation;
    private float distance;
    private bool tooFar;

    public GameObject player;
    public Vector3 eulerOffset = new Vector3(0f, 30f, 0f);
    public float distanceTresh = 1.2f;
    public float distanceTolerance = 0.1f;
    public float movementSpeed = 0.5f;
    public float delay = 2.0f;
    
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
        Act();   
    }

    public void LookAtPlayer()
    {
        gameObject.transform.LookAt(lookHere);
        gameObject.transform.rotation *= Quaternion.Euler(eulerOffset);
    }

    public void ResetPosition(int value)
    {   
        if(value == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        transform.position = new Vector3(0f, 0.9f, 1.5f);
    }

    void MoveToPlayer()
    {
        float currentY = transform.position.y;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 targetPosition = player.transform.position - (direction * distanceTresh);
        targetPosition.y = currentY;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        Anim.SetInteger("Mode", 5);
    }

    void MoveAwayFromPlayer()
    {
        float currentY = transform.position.y;
        Vector3 direction = (transform.position - player.transform.position).normalized;
        Vector3 targetPosition = player.transform.position + (direction * distanceTresh);
        targetPosition.y = currentY;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        Anim.SetInteger("Mode", 5);
    }

    void Act()
    {
        CheckDistance();

        Anim.SetInteger("Mode", 0);
        State = (int)TutorialManager.GetInstance().enemyMode;
        
        if (distance > distanceTresh + distanceTolerance)
        {
            StartCoroutine(WaitForSecondsCoroutine(delay));
            MoveToPlayer();
        }
        else if (distance < distanceTresh - distanceTolerance)
        {
            StartCoroutine(WaitForSecondsCoroutine(delay));
            MoveAwayFromPlayer();
        }
        else
        {
            int tutorialMode = TutorialManager.GetInstance().tutorialMode;
            print(tutorialMode + " " + State);
            
            if(tutorialMode == 4)
            {
                Anim.SetInteger("Mode", tutorialMode);
                Anim.SetInteger("Rand", 0);
            }
            else
            {
                Anim.SetInteger("Mode", State);
            }
            
        }
        LookAtPlayer();
    }

    void CheckDistance()
    {
        enemyLocation = new Vector2(transform.position.x, transform.position.z);
        playerLocation = new Vector2(player.transform.position.x, player.transform.position.z);
        distance = (playerLocation - enemyLocation).magnitude;

        lookHere = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    IEnumerator WaitForSecondsCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

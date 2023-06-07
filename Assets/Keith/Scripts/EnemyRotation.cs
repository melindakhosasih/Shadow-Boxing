using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Transform playerTransform;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(playerTransform);
    }
}

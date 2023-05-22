using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameObjectToFollow;
    public float followDistance = 2.0f;
    public float followSpeed = 1.0f;

    void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, gameObjectToFollow.transform.position);
        if (distance > followDistance)
        {
            Vector3 direction = (enemy.transform.position - gameObjectToFollow.transform.position).normalized;
            direction.y = 0.0f;
            Vector3 newPosition = enemy.transform.position - direction * followSpeed * Time.deltaTime;
            enemy.transform.position = newPosition;
        }
        Vector3 positionToFace = gameObjectToFollow.transform.position;
        positionToFace.y = 1;
        enemy.transform.LookAt(positionToFace);
    }
}

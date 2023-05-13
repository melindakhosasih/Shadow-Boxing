using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour
{
    public GameObject interactableObject;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = interactableObject.transform.position + positionOffset;
        transform.rotation = interactableObject.transform.rotation * Quaternion.Euler(rotationOffset);
    }
}

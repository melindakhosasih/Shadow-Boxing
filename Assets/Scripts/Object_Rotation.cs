using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotation : MonoBehaviour
{
    public Transform targetObject;

    void Update()
    {
        transform.rotation = targetObject.rotation;
    }
}

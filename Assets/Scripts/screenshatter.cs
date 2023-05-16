using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshatter : MonoBehaviour
{

private void Awake(){
    Vector3 explosionPosition = new Vector3(45.833f, 2.719f, 24.064f);
    foreach(Transform child in transform){
        if(child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody)){
            childRigidbody.AddExplosionForce(10f, explosionPosition, 10f);
        }
    }
}    
}

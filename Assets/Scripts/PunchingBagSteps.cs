using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunchingBagSteps : MonoBehaviour
{
    private string step;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro childText = this.gameObject.GetComponentInChildren<TextMeshPro>();
        if (childText != null) {
            step = childText.text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(step == "1") {   // Left Hand
            if(other.gameObject.CompareTag("LeftHand")) {
                Destroy(this.gameObject);
            }
        } else if(step == "2") {
            if(other.gameObject.CompareTag("RightHand")) {
                Destroy(this.gameObject);
            }
        }
    }
}

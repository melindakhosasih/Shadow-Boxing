using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class shock : MonoBehaviour
{
    // Start is called before the first frame update
    public XRBaseController left_hand,right_hand;
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time < 3f)
        {
            //leftHandShock();
            //rightHandShock();
        }
    }

    public void leftHandShock()
    {
        
        left_hand.SendHapticImpulse(1.0f, 0.25f);
    }
    public void rightHandShock()
    {
        
        right_hand.SendHapticImpulse(1.0f, 0.25f);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeDetect : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position.z>1.4f)&&(this.transform.position.z<4f)&&(this.transform.position.x<0.1f)&&(this.transform.position.x>-2.6f))
        {
            circle1.SetActive(true);
            circle2.SetActive(false);
            GameObject.FindWithTag("Enemy").GetComponent<DodgeAnimator>().OutOfRange = false;
        }
        else
        {
            circle1.SetActive(false);
            circle2.SetActive(true);
            GameObject.FindWithTag("Enemy").GetComponent<DodgeAnimator>().OutOfRange = true;
        }
    }
}

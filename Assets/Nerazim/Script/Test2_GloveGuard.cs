using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2_GloveGuard : MonoBehaviour
{
    public GameObject Guardblock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.transform.localEulerAngles.z );
        if ((this.transform.localEulerAngles.z > 70) && (this.transform.localEulerAngles.z < 110))
        {
            Guardblock.SetActive(true);
        }
        else
        {
            Guardblock.SetActive(false);
        }
    }
}

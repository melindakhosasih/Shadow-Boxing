using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    string nextscene;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<fade>().scenefadein(0.3f , 0.01f);
    }


    public void change(string scene){
        nextscene = scene;
        this.GetComponent<fade>().scenefadeout(1f, 0.01f);
        Invoke("next", 4f);
    }

    void next(){
        SceneManager.LoadScene(nextscene);
        CancelInvoke("next");
    }
}

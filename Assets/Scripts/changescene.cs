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
        this.GetComponent<fade>().musicfadein(0.01f , 0.1f, 0, global.volume);
    }


    public void change(string scene){

        nextscene = scene;
        this.GetComponent<fade>().scenefadeout(1f, 0.01f);
        this.GetComponent<fade>().musicfadeout(0.05f , 0.1f, global.volume,0);
        Invoke("next", 4f);
    }

    void next(){
        global.prescene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nextscene);
        CancelInvoke("next");
    }
}

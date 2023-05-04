using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<fade>().scenefadein(0.3f , 0.01f);
    }

    public void change(string nextScene){
        this.GetComponent<fade>().scenefadeout(0.3f, 0.01f);
        SceneManager.LoadScene(nextScene);
    }
}

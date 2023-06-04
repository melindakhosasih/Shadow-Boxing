using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public string triggerName;
    public bool isLeft;
    public bool isFirst;
    public bool isMain;

    private MeshRenderer Renderer;
    private bool Active;
    private string targetGloveTag;

    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        if(tutorialManagerAdvanced.GetInstance().isTutorial) Renderer.enabled = true;
        else Renderer.enabled = false;
        Active = true;

        if(isLeft) targetGloveTag = "LeftHand";
        else targetGloveTag = "RightHand";
    }

    public void Hide()
    {
        if(tutorialManagerAdvanced.GetInstance().isTutorial) Renderer.enabled = false;
        Active = false;
    }

    public void Hide_Active()
    {
        if(tutorialManagerAdvanced.GetInstance().isTutorial) Renderer.enabled = false;
    }

    public void Show()
    {
        if(tutorialManagerAdvanced.GetInstance().isTutorial) Renderer.enabled = true;
        Active = true;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(Active)
        {
            if(obj.gameObject.tag == targetGloveTag && isLeft)
            {
                LeftGloveInstance.GetInstance().changeState(triggerName);
                if(new_Tutorial.GetInstance().allowIncrement && isMain) new_Tutorial.GetInstance().incrementCounter();
            }
            else if(obj.gameObject.tag == targetGloveTag && !isLeft)
            {
                RightGloveInstance.GetInstance().changeState(triggerName);
                if(new_Tutorial.GetInstance().allowIncrement && isMain) new_Tutorial.GetInstance().incrementCounter();
            }
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if(Active)
        {
            if(obj.gameObject.tag == targetGloveTag && isLeft)
            {
                LeftGloveInstance.GetInstance().resetState();
                // Show();
            }
            else if(obj.gameObject.tag == targetGloveTag && !isLeft)
            {
                RightGloveInstance.GetInstance().resetState();
                // Show();
            } 
        }
    }

}

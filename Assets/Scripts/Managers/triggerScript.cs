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
        Renderer.enabled = false;
        Active = false;
        if(isLeft && LeftGloveInstance.GetInstance().getState() == triggerName)
        {
            LeftGloveInstance.GetInstance().resetState();
        }
        else if(!isLeft && RightGloveInstance.GetInstance().getState() == triggerName)
        {
            RightGloveInstance.GetInstance().resetState();
        }
    }

    public void Hide_Active()
    {
        Renderer.enabled = false;
    }

    public void Show()
    {
        if(tutorialManagerAdvanced.GetInstance().isTutorial) Renderer.enabled = true;
        else Renderer.enabled = false;
        Active = true;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(Active)
        {
            if(obj.gameObject.tag == targetGloveTag && isLeft)
            {
                LeftGloveInstance.GetInstance().changeState(triggerName);
            }
            else if(obj.gameObject.tag == targetGloveTag && !isLeft)
            {
                RightGloveInstance.GetInstance().changeState(triggerName);
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
            }
            else if(obj.gameObject.tag == targetGloveTag && !isLeft)
            {
                RightGloveInstance.GetInstance().resetState();
            } 
        }
    }

}

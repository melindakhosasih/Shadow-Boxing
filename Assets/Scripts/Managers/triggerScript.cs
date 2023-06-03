using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public string triggerName;
    public bool isLeft;

    private MeshRenderer Renderer;
    private bool Active;
    private string targetGloveTag;

    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        Active = true;

        if(isLeft) targetGloveTag = "LeftHand";
        else targetGloveTag = "RightHand";
    }

    public void Hide()
    {
        Renderer.enabled = false;
        Active = false;
    }

    public void Show()
    {
        Renderer.enabled = true;
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
                LeftGloveInstance.GetInstance().changeState("Neutral");
            }
            else if(obj.gameObject.tag == targetGloveTag && !isLeft)
            {
                RightGloveInstance.GetInstance().changeState("Neutral");
            } 
        }
        
    }

}

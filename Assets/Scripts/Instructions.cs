using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Instructions : MonoBehaviour
{
    public GameObject window;
    public TMP_Text textDisplay;
    public Image img;

    public List<string> texts;

    private float writingSpeed = 0;

    private int index;
    private int charIndex;

    private bool started;
    private bool waitForNext;

    private void Start()
    {
        ToggleWindow(true);
        GetText(0);
        started = true;
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    private void GetText(int i)
    {
        index = i;
        charIndex = 0;
        textDisplay.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndText()
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        ToggleWindow(false);        
    }
    
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);
        string currentText = texts[index];
        textDisplay.text += currentText[charIndex];
        charIndex++;
        if(charIndex < currentText.Length)
        {
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }        
    }

    private void Update()
    {
        if (!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            waitForNext = false;
            index++;
            if(index < texts.Count)
            {
                GetText(index);
            }
            else
            {
                EndText();
            }            
        }
    }
}

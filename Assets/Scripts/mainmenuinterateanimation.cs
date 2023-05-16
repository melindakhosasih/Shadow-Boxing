using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainmenuinterateanimation : MonoBehaviour
{
    public List<TextMeshProUGUI> text;
    float dilate, changedilate;
    // Start is called before the first frame update
    void Start()
    {
        dilate = -0.19f;
        changedilate=0.1f / text.Count;
        foreach (var puchtext in text)
        {
            StartCoroutine(punch(puchtext));
        }
    }

    IEnumerator punch(TextMeshProUGUI puchtext)
    {
        while(true){
            if(dilate < -0.19 || dilate > 0.63f) changedilate = -changedilate;
            puchtext.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate);
            dilate += changedilate;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

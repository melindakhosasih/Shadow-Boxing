using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class titleanimation : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro text;
    float dilate, changedilate;
    public TextMeshProUGUI tmp;
    public Light light1, light2, light3;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        dilate = -0.19f;
        changedilate=0.1f;
        StartCoroutine(punch());
    }

    IEnumerator punch()
    {
        while(true){
            if(dilate < -0.19 || dilate > 0.63f) changedilate = -changedilate;
            this.tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate);
            dilate += changedilate;
            yield return new WaitForSeconds(0.01f);
        }
    }
}

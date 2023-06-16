using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainmenuinterateanimation : MonoBehaviour
{
    public List<TextMeshProUGUI> text;
    float dilate, changedilate;
    public Light lt;

    public Color colorStart =  new Color(0f,0f,1f);
    public Color colorEnd = new Color(1f,0f,0f);
    public Color orignalcolor = new Color(1f,1f,1f);
    Color now;
    int time = 0;
    public float duration = 1000F;

    // Start is called before the first frame update
    void Start()
    {
        lt.color= colorStart;
        now = colorEnd;
        dilate = -0.19f;
        changedilate=0.1f / text.Count;
        foreach (var puchtext in text)
        {
            StartCoroutine(punch(puchtext));
        }
    }
    void Update(){
        time++;
        float lerp = time / duration;
        // Debug.Log(lerp);
        
        // if(now == colorEnd) {
        //     if(lt.color == colorStart){
        //         now = colorStart;
        //         time=0;
        //     }
        //     else{
        //         lt.color = Color.Lerp(now,colorStart,lerp);
        //     }
        // }
        // else if(now == colorStart){
        //     if(lt.color == colorEnd){
        //         now = colorEnd;
        //         time=0;
        //     }
        //     else{
        //         lt.color = Color.Lerp(now,colorEnd,lerp);
        //     }
        // }
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

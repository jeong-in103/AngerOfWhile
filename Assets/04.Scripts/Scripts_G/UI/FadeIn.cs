using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public float animTime = 2f;         

    private Image fadeImage;            

    private float start = 1f;           
    private float end = 0f;             
    private float time = 0f;            

    private bool isPlay = false;     

    void Awake()
    {
       
        fadeImage = GetComponent<Image>();
    }

  
    public void Start()
    {
       
        if (isPlay == true)
            return;

        StartCoroutine("PlayFadeIn");
    }



    IEnumerator PlayFadeIn()
    {
        
        isPlay = true;

      
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
           
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            
            fadeImage.color = color;

            yield return null;
        }

        isPlay = false;
    }

}
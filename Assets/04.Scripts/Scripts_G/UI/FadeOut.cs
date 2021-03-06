using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float animTime = 2f;

    private Image fadeImage;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private bool isPlay = false;

    public GameObject MainCanvas;
    public GameObject ClearCanvas;
    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFadeAnim()
    {
        if (isPlay == true)
            return;

        StartCoroutine("PlayFadeOut");
    }


    IEnumerator PlayFadeOut()
    {
        isPlay = true;

        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);

            fadeImage.color = color;

            yield return null;
        }

        isPlay = false;

        MainCanvas.SetActive(false);
        ClearCanvas.SetActive(true);
    }




}
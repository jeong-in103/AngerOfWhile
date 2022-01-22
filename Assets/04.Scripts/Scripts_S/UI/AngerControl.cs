using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AngerControl : MonoBehaviour
{
    public Image angerImage;

    private void OnEnable()
    {
        angerImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (angerImage.fillAmount < 0)
        {
            return;
        }
        else if(angerImage.fillAmount == 1f)
        {
            // Anger (Effect + Motion)

            // After
            angerImage.fillAmount = 0f;
        }
        else
        {
            angerImage.fillAmount -= Time.deltaTime /30; //G:1초에 angerGauge -1 감소부분
        }
    }
}

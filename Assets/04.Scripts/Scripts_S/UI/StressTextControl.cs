using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class StressTextControl : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    public float blinkTime;
    public float unBlinkTime;
    private float currentTime;

    Coroutine blinkCoroutine;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        if (currentTime < blinkTime)
        {
            currentTime += Time.deltaTime;
            tmp.color = new Color(1, 1, 1, 0);
        }
        else if (currentTime > blinkTime && currentTime < unBlinkTime)
        {
            currentTime += Time.deltaTime;
            tmp.color = new Color(1, 1, 1, 1);
        }
        else
        {
            currentTime = 0;
        }
    }
}

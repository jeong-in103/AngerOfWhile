using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBarControl : MonoBehaviour
{
    private Slider slider;

    public float speed;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime * speed;
        if (slider.value == 0)
        {
            slider.value = slider.maxValue;
            // HP -1
            // 다시 시작
        }
    }
}

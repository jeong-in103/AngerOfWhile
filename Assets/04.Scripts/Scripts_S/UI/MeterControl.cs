using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterControl : MonoBehaviour
{
    private Text meterText;
    private float meter;

    void Awake()
    {
        meterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        meter += Time.deltaTime / 30;
        meterText.text = meter.ToString("F2") + "m";
    }
}

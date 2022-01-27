using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
    public Material mat;

    public Color startColor;
    public Color sunsetColor;
    public Color nightColor;

    private Color currentColor;

    public float colorSpeed;

    public bool morning;
    public bool sunset;
    public bool night;

    private int nextColor;
    private int multiple;
    [SerializeField]
    private int changeColorScore = 2000;
    private void Start()
    {
        nextColor = 0;
        multiple = 1;
    }
    void LateUpdate()
    {
        if (GameManager.score !=0 && GameManager.score >= changeColorScore * multiple)
        {
            multiple++;
            nextColor++;
        }
        
        switch(nextColor % 3)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;

        }

        if (morning)
        {
            currentColor = Color.Lerp(currentColor, startColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
        if (sunset)
        {
            currentColor = Color.Lerp(currentColor, sunsetColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
        if (night)
        {
            currentColor = Color.Lerp(currentColor, nightColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
    public Material mat;

    public Color startColor;
    public Color PoisonColor;
    public Color nightColor;

    private Color currentColor;

    public float colorSpeed;

    public bool morning;
    public bool poison;
    public bool night;

    private int nextColor;
    private int multiple;

    //게임 Totaㅣ 점수 대략 :170,150  게임 내 3등분해서 바다 색 조절
    [SerializeField]
    private int changeColorScore = 50000;

    WaitForSeconds wait = new WaitForSeconds(10f);

    Coroutine changeWater;
    private void Start()
    {
        nextColor = 0;
        multiple = 1;

        mat.SetColor("_TopDarkColour", startColor);
        currentColor = startColor;
    }

    private void LateUpdate()
    {
        CheckScore();

        
        if (morning)
        {
            currentColor = Color.Lerp(currentColor, startColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
        if (poison)
        {
            currentColor = Color.Lerp(currentColor, PoisonColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
        if (night)
        {
            currentColor = Color.Lerp(currentColor, nightColor, Time.smoothDeltaTime * colorSpeed);
            mat.SetColor("_TopDarkColour", currentColor);
        }
        
    }
    public void CheckScore()
    {
        //색 변경 체크
        if (GameManager.score >= changeColorScore * multiple)
        {
            multiple++;
            nextColor++;

            StartCoroutine(ChangeWater(nextColor));
        }
    }
    IEnumerator ChangeWater(int type)
    {
        while (true)
        {
            if (type == 0)
            {
                currentColor = Color.Lerp(currentColor, startColor, Time.smoothDeltaTime * colorSpeed);
                mat.SetColor("_TopDarkColour", currentColor);

                if (currentColor == startColor)
                    break;
            }
            else if (type == 1)
            {
                currentColor = Color.Lerp(currentColor, nightColor, Time.smoothDeltaTime * colorSpeed);
                mat.SetColor("_TopDarkColour", currentColor);

                if (currentColor == nightColor)
                    break;
            }
            else if (type == 2)
            {
                currentColor = Color.Lerp(currentColor, PoisonColor, Time.smoothDeltaTime * colorSpeed);
                mat.SetColor("_TopDarkColour", currentColor);

                if (currentColor == PoisonColor)
                    break;
            }
            yield return null;
        }
    }
}

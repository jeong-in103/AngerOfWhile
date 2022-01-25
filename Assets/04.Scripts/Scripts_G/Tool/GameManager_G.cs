using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_G : MonoBehaviour
{
    

    public Slider angerSlider;
    

    public Text currentMeter;
    public Text currentScore;
    public Text finalMeter;
    public Text finalScore;
    public GameObject endingCanvas;
    public GameObject clearCanvas;
    public float meter;
    public int score;
    public float angerValue;

    [SerializeField]
    private float pastMeter = 0;
   
    
    void Start()
    {
        angerSlider.value = 0; //G: 0으로 초기화 해서 시작할 것 
    }

    // Update is called once per frame
    void Update()
    {
        MeterUpdate();
        AngerUpdate();
        ScoreUpdate();
    }

    private void AngerUpdate()
    {
        angerValue = angerSlider.value;
        if (angerSlider.value>0)
            angerSlider.value -= Time.deltaTime; //G:1초에 angerGauge -1 감소부분
        
           
         if(angerSlider.value == 100)
        { }
                
        
    }

    private void MeterUpdate() //G:미터기 업데이트 추후 수정
    {
        if (endingCanvas.activeSelf  == false && clearCanvas.activeSelf == false)
        {
            meter += Time.deltaTime / 10;
            currentMeter.text = meter.ToString("F2") + "m";
        }
        else if(endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            finalMeter.text = meter.ToString("F2") + "m";
        }

       
    }

    private void ScoreUpdate()  //G: 점수 업데이트 (미터에 따른 점수 추가 O | 아이템에 따른 점수 추가 X | 장애물에 따른 점수 감소 X)
    {
       
        if (meter - pastMeter >= 1f)
        {
            pastMeter = meter;
            score += 50;
           
        }
        currentScore.text = score.ToString();
        if (endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            finalScore.text = score.ToString();
        }
    }
}

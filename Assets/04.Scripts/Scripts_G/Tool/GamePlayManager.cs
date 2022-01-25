using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static bool newUpdate;

    public Slider angerSlider;

    public Text currentMeter;
    public Text currentScore;
    public Text finalMeter;
    public Text finalScore;
    public GameObject endingCanvas;
    public GameObject clearCanvas;
    public GameObject AngerFriends;
    public float meter;

    [SerializeField]
    private float pastMeter = 0;
    
    void Start()
    {
        GameManager.score = 0;
        GameManager.angerValue = 0f;

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
        angerSlider.value = GameManager.angerValue;
        if (angerSlider.value>0)
            angerSlider.value -= Time.deltaTime; //G:1초에 angerGauge -1 감소부분
        
           
        if(angerSlider.value == 100)
        {
            AngerFriends.gameObject.SetActive(true);
            angerSlider.value = 0f;
        }
      
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
            GameManager.score += 50;
           
        }
        currentScore.text = GameManager.score.ToString();
        if (endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            finalScore.text = GameManager.score.ToString();
        }
    }
}

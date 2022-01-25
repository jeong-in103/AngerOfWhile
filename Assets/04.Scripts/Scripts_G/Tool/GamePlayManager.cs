using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
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

    public bool test;
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
        if (GameManager.angerValue >= 100)
        {
            AngerFriends.gameObject.SetActive(true);
            angerSlider.value = 0f;
            GameManager.angerValue = 0f;
        }

        GameManager.angerValue -= Time.deltaTime; //G:1초에 angerGauge -1 감소부분
        GameManager.angerValue = Mathf.Clamp(GameManager.angerValue, 0, 100); //최소 최대
    }

    private void MeterUpdate() //G:미터기 업데이트 추후 수정
    {
        if (endingCanvas.activeSelf  == false && clearCanvas.activeSelf == false)
        {
            meter += Time.deltaTime * 0.1f;
            currentMeter.text = meter.ToString("F2");
        }
        else if(endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            finalMeter.text = meter.ToString("F2");
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

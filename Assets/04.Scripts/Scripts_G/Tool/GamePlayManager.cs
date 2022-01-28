using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    //[SerializeField]
    //private SoundManager soundManager;

    public Slider angerSlider;
    public Slider stressSlider;

    public Text currentMeter;
    public Text currentScore;
    public Text finalMeter;
    public Text finalScore;
    public Text bestScore;
    private string KeyString = "BestRecord";
    public GameObject newRecord;
    public GameObject endingCanvas;
    public GameObject clearCanvas;
    public GameObject AngerFriends;
    public float meter;

    [SerializeField]
    private ScoreUp highLightScore;

    [SerializeField]
    private float pastMeter = 0;
    [SerializeField]
    private int countHighlightScore = 0;

    private bool stressWait;

    void Start()
    {
        GameManager.score = 0;
        GameManager.angerValue = 0f;
       
        GameManager.bestScore = PlayerPrefs.GetInt("BestRecord", 0);
        GameManager.stress = false;
        GameManager.endGame = false;

        angerSlider.value = 0; //G: 0으로 초기화 해서 시작할 것 
        stressSlider.value = 0;

        stressWait = false;
    }

    // Update is called once per frame
    void Update()
    {
        MeterUpdate();
        GaugeUpdate();
        ScoreUpdate();
    }

    private void LateUpdate()
    {
        if (GameManager.endGame)
        {
            endingCanvas.SetActive(true);
        }
    }

    private void GaugeUpdate()
    {
        if (!GameManager.endGame)
        {
            if (GameManager.angerValue > 0)
            {
                AngerUpdate();
            }
            else
            {
                StressUpdate();
            }
        }
    }
    private void AngerUpdate()
    {
        angerSlider.gameObject.SetActive(true);
        stressSlider.gameObject.SetActive(false);//StestBar Off
        stressSlider.value = 0;

        angerSlider.value = GameManager.angerValue;

        if (GameManager.angerValue >= 100)
        {
            AngerFriends.gameObject.SetActive(true);
            angerSlider.value = 30f;
            GameManager.angerValue = 25f;
        }

        GameManager.angerValue -= Time.deltaTime * 4f; //G:1초에 angerGauge -5 감소부분
        GameManager.angerValue = Mathf.Clamp(GameManager.angerValue, 0, 100); //최소 최대
    }

    private void StressUpdate()
    {
        angerSlider.gameObject.SetActive(false);
        stressSlider.gameObject.SetActive(true);//StresBar On

        if (!stressWait)
        {
            stressSlider.value += Time.deltaTime;
            if (stressSlider.value == stressSlider.maxValue)
            {
                stressSlider.value = stressSlider.minValue;
                GameManager.stress = true;// HP -1
                stressWait = true;
                // 무적시간에 맞게 2초 후 다시 시작

            }
        }
        else
        {
            Invoke(nameof(StressWaitEnd), 2f);
        }
    }

    private void MeterUpdate() 
    {
        if (endingCanvas.activeSelf  == false && clearCanvas.activeSelf == false)
        {
            meter += Time.deltaTime * 0.1f;
            currentMeter.text = meter.ToString("F0");
        }
        else if(endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            finalMeter.text = meter.ToString("F0");
        }
    }

    private void ScoreUpdate()  //G: 점수 업데이트 (미터에 따른 점수 추가 O | 아이템에 따른 점수 추가 X | 장애물에 따른 점수 감소 X)
    {
        if (meter - pastMeter >= 1f)
        {
            pastMeter = meter;
            GameManager.score += 50;
            ScoreHighlight();
        }
        currentScore.text = GameManager.score.ToString();
        if (endingCanvas.activeSelf == true || clearCanvas.activeSelf == true)
        {
            if (GameManager.score > GameManager.bestScore)
            {
                PlayerPrefs.SetInt(KeyString, GameManager.score);
                newRecord.SetActive(true);
                GameManager.bestScore = GameManager.score;
            }
             finalScore.text = GameManager.score.ToString();
            bestScore.text = GameManager.bestScore.ToString();
            PlayerPrefs.Save();
        }
    }

    public void ScoreHighlight()
    {
        if (GameManager.score > 0 && GameManager.score / 1000 > countHighlightScore)
        {
            countHighlightScore = (int)(GameManager.score / 1000);
            currentScore.gameObject.SetActive(false);
            highLightScore.ScoreAccent(GameManager.score, currentScore.gameObject);
            //soundManager.ScoreHighlightSound();
        }
    }

    private void StressWaitEnd()
    {
        stressWait = false;
    }
}

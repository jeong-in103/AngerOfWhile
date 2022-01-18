using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_G : MonoBehaviour
{
    public Slider angerSlider;
    public Image angerFill;
    public Text meterText;
    public Text scoreText;

    public float meter;
    public int score;

    [SerializeField]
    private float pastMeter = 0;

    //[SerializeField]
    //private int time;

    // Start is called before the first frame update

    void Start()
    {
        angerSlider.value = 100; //G: 0으로 초기화 해서 시작할 것 
    }

    // Update is called once per frame
    void Update()
    {
        MeterUpdate();
        AngerUpdate();
        

    }

    private void AngerUpdate()
    {
        if(angerSlider.value>0)
            angerSlider.value -= Time.deltaTime; //G:1초에 angerGauge -1 감소부분
        if(angerSlider.value <100)
        { }
            //G: 고래 공격 성공하면 +20부분
         if(angerSlider.value == 100)
        { }
                //G: 궁극기 써지는 부분
        
    }

    private void MeterUpdate() //G:미터기 업데이트 추후 수정
    {
        meter += Time.deltaTime / 20;
        meterText.text = meter.ToString("F2") + "m";
       
        ScoreUpdate();

    }

    private void ScoreUpdate()  //G: 점수 업데이트 (미터에 따른 점수 추가 O | 아이템에 따른 점수 추가 X | 장애물에 따른 점수 감소 X)
    {
        if (meter - pastMeter >= 1f)
        {
            pastMeter = meter;
            score += 50;
            scoreText.text = score.ToString();
            
        }
    }
}

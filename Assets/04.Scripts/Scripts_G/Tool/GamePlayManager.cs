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

        angerSlider.value = 0; //G: 0���� �ʱ�ȭ �ؼ� ������ �� 
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
            angerSlider.value -= Time.deltaTime; //G:1�ʿ� angerGauge -1 ���Һκ�
        
           
        if(angerSlider.value == 100)
        {
            AngerFriends.gameObject.SetActive(true);
            angerSlider.value = 0f;
        }
      
    }

    private void MeterUpdate() //G:���ͱ� ������Ʈ ���� ����
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

    private void ScoreUpdate()  //G: ���� ������Ʈ (���Ϳ� ���� ���� �߰� O | �����ۿ� ���� ���� �߰� X | ��ֹ��� ���� ���� ���� X)
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

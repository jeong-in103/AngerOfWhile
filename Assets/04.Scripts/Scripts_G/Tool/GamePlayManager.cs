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
        if (GameManager.angerValue >= 100)
        {
            AngerFriends.gameObject.SetActive(true);
            angerSlider.value = 0f;
            GameManager.angerValue = 0f;
        }

        GameManager.angerValue -= Time.deltaTime; //G:1�ʿ� angerGauge -1 ���Һκ�
        GameManager.angerValue = Mathf.Clamp(GameManager.angerValue, 0, 100); //�ּ� �ִ�
    }

    private void MeterUpdate() //G:���ͱ� ������Ʈ ���� ����
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

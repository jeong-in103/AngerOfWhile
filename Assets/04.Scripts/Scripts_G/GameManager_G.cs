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
        angerSlider.value = 100; //G: 0���� �ʱ�ȭ �ؼ� ������ �� 
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
            angerSlider.value -= Time.deltaTime; //G:1�ʿ� angerGauge -1 ���Һκ�
        if(angerSlider.value <100)
        { }
            //G: �� ���� �����ϸ� +20�κ�
         if(angerSlider.value == 100)
        { }
                //G: �ñر� ������ �κ�
        
    }

    private void MeterUpdate() //G:���ͱ� ������Ʈ ���� ����
    {
        meter += Time.deltaTime / 20;
        meterText.text = meter.ToString("F2") + "m";
       
        ScoreUpdate();

    }

    private void ScoreUpdate()  //G: ���� ������Ʈ (���Ϳ� ���� ���� �߰� O | �����ۿ� ���� ���� �߰� X | ��ֹ��� ���� ���� ���� X)
    {
        if (meter - pastMeter >= 1f)
        {
            pastMeter = meter;
            score += 50;
            scoreText.text = score.ToString();
            
        }
    }
}

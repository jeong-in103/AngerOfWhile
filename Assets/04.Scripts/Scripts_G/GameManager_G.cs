using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_G : MonoBehaviour
{
    public Slider angerSlider;
    public Image angerFill;

    private int curTime;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        angerSlider.value = 100; //G: 0으로 초기화 해서 시작할 것 
    }

    // Update is called once per frame
    void Update()
    {
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
}

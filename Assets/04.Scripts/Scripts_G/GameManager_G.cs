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
        angerSlider.value = 100; //G: 0���� �ʱ�ȭ �ؼ� ������ �� 
    }

    // Update is called once per frame
    void Update()
    {
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
}

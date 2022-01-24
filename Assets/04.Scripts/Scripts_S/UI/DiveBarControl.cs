using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiveBarControl : MonoBehaviour
{
    // Component
    public Transform target;
    public Image gage; //������ �̹���

    // Variable
    [Range(0f, 1f)]
    public float diveTimeSpeed = 0.5f; //��� �ð� �ӵ�
    [Range(250, 350)]
    public float height = 300f;

    private float diveBarTime; //��� �ð�

    private bool dive; // ��� üũ

    // Property
    public bool Diving { get { return dive; } }

    private void OnEnable()
    {
        //�ʱ�ȭ
        dive = true;
        gage.fillAmount = 1f;
        diveBarTime = 1f;
        StartCoroutine(GageOver());
    }

    private void OnDisable()
    {
        //�ʱ�ȭ + �ڷ�ƾ ����
        dive = false;
        StopCoroutine(GageOver());
    }
    private void Update()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(target.transform.position);
        transform.position = playerPosition + new Vector3(0f, height, 0f);
            
    }
    // ��� ������ �ڷ�ƾ
    IEnumerator GageOver()
    {
        while (diveBarTime >= 0f)
        {
            diveBarTime -= Time.deltaTime * diveTimeSpeed;
            gage.fillAmount = diveBarTime;
            yield return null;
        }
        OffDiveBar();
    }
    
    public void OnDiveBar()
    {
        gameObject.SetActive(true);
    }

    public void OffDiveBar()
    {
        gameObject.SetActive(false);
    }
}

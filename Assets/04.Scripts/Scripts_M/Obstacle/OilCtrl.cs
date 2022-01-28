using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCtrl : MonoBehaviour
{
    private Renderer oilRenderer;

    private float removeSpeed;
    private float floatTime;

    IEnumerator coroutine;

    void Awake()
    {
        oilRenderer = GetComponent<Renderer>();

        OilReset();

        removeSpeed = 1f;
    }

    private void OnEnable()
    {
        OilReset();
    }

    public void OilDisappear()
    {
        OilReset();
        coroutine = RemoveOil();
        StartCoroutine(coroutine);
    }

    public void StopOilDisappear()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator RemoveOil()
    {
        while (floatTime > -1)
        {
            floatTime -= removeSpeed * Time.deltaTime;
            if(floatTime <= -1)
            {
                floatTime = -0.99f;
            }
            oilRenderer.material.SetFloat("_floatTime", floatTime);
            yield return null;
        }
    }

    private void OilReset()
    {
        floatTime = 1;
        oilRenderer.material.SetFloat("_floatTime", floatTime);
    }
}

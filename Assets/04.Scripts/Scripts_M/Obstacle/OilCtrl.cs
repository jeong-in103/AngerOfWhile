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
        
    }

    public void OilDisappear()
    {
        coroutine = RemoveOil();
        StartCoroutine(coroutine);
        OilReset();
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

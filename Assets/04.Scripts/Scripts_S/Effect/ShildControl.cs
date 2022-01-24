using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildControl : MonoBehaviour
{
    private Renderer renderer;

    public float shildBrokenSpeed; //½¯µå ºÎ¼­Áü ½Ã°£
    private float shildBrokenValue; //½¯µå ºÎ¼­Áü ½Ã°£

    private float disolveMin;
    private float disolveMax;

    void Awake()
    {
        renderer = GetComponent<Renderer>();

        disolveMin = -0.1f;
        disolveMax = 0.5f;
    }
    private void OnEnable()
    {
        shildBrokenValue = disolveMax;
    }


    public void OnBroken(bool active)
    {
        StartCoroutine(SheildBroken(active));
    }
    //º¸È£¸· ±úÁü
    IEnumerator SheildBroken(bool active)
    {
        while (shildBrokenValue >= disolveMin)
        {
            shildBrokenValue = Mathf.Lerp(shildBrokenValue, disolveMin-0.01f, Time.smoothDeltaTime * shildBrokenSpeed);
            renderer.material.SetFloat("_DisolveEdgeThickness", shildBrokenValue); // 0.6f ~ -0.2f DisolveEdgeThickness
            Debug.Log("ÇÏ´ÂÁß" + shildBrokenValue);
            yield return null;
        }
        Debug.Log("End");
        shildBrokenValue = disolveMax;
        renderer.material.SetFloat("_DisolveEdgeThickness", disolveMax);
        if (!active)
        {
            gameObject.SetActive(false);
        }
    }
}

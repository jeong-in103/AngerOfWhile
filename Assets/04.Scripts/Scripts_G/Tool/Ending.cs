using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public static Ending Instance;

    public GameObject mainCanvas;
    public GameObject endingCanvas;
    public GameObject uiCamera;
    // Start is called before the first frame update
    void Start()
    {
        uiCamera.SetActive(true);
        mainCanvas.SetActive(false);
        Invoke("ActiveScore",4);
    }

    public void ActiveScore()
    {
        endingCanvas.SetActive(true);
    }

}

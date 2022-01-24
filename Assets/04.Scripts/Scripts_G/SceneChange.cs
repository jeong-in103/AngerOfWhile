using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{    
    
    public GameObject start;
    public GameObject close;
    public GameObject mainCanvas;
    public GameObject endingCanvas;
    public GameObject clearCanvas;
   

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene_G");
    }

    public void RestartButton()
    { 
        SceneManager.LoadScene("MainScene_G");
    }

    public void CloseButton()
    {
         SceneManager.LoadScene("Start_G");
    }


}

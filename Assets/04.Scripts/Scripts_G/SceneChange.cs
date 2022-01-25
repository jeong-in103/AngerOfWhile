using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject start;

    public void StartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Start_G");
    }

    public void CloseButton()
    {
        SceneManager.LoadScene("Start_G");
    }
}
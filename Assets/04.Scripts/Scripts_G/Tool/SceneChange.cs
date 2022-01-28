using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void CloseButton()
    {
        SceneManager.LoadScene("Start_G");
    }
}

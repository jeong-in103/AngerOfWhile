using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    // Manager
    SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.Instance;
    }

    private void OnEnable()
    {
        soundManager.OnBGM(0); //Main BGM ON       
    }
}

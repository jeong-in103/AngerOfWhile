using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("오디오 소스")]
    public AudioSource bgmAudio;
    public AudioSource playAudio;

    [Header("BGM")]
    public AudioClip[] bgms;

    [Header("UI 효과음")]
    public AudioClip buttonClick;
    public AudioClip scoreOn;

    [Header("고래 소리")]
    public AudioClip attack;
    public AudioClip damage;

    [Header("물 소리")]
    public AudioClip underWater;

    [Header("아이템 효과음")]
    public AudioClip heal;
    public AudioClip helmat;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }
    public void OnBGM(int num)
    {
        bgmAudio.clip = bgms[num]; //0. Main 1.Play 2.Over 3.Clear
        bgmAudio.Play();
    }

    public void UISound()
    {
        playAudio.volume = 1f;
        playAudio.PlayOneShot(buttonClick);
    }
    public void AttackSound()
    {
        playAudio.volume = 0.5f;
        playAudio.PlayOneShot(attack);
    }

    public void DamageSound()
    {
        if(playAudio.clip != damage)
        {
            playAudio.Stop();
        }
        if (!playAudio.isPlaying)
        {
            playAudio.volume = 0.8f;
            playAudio.PlayOneShot(damage);
        }
    }

    public void UnderWaterSound()
    {
        if (!playAudio.isPlaying)
        {
            playAudio.volume = 0.8f;
            playAudio.PlayOneShot(underWater);
        }
    }

    public void AidKitSound()
    {
        playAudio.volume = 0.5f;
        playAudio.PlayOneShot(heal);
    }

    public void HelmatSound()
    {
        playAudio.volume = 0.8f;
        playAudio.PlayOneShot(helmat);
    }
}

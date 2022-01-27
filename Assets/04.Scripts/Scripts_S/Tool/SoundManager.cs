using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("����� �ҽ�")]
    public AudioSource bgmAudio;
    public AudioSource playAudio;

    [Header("BGM")]
    public AudioClip[] bgms;

    [Header("UI ȿ����")]
    public AudioClip buttonClick;
    public AudioClip scoreOn;

    [Header("�� �Ҹ�")]
    public AudioClip attack;
    public AudioClip damage;

    [Header("�� �Ҹ�")]
    public AudioClip underWater;

    [Header("������ ȿ����")]
    public AudioClip heal;
    public AudioClip helmat;

    [Header("���� ȿ����")]
    public AudioClip scoreHighlight;

    //BGM �ʱ�ȭ
    private void BgmInit()
    {
        bgmAudio.spatialBlend = 0f;
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
        BgmInit(); //���� -> ���ݽ�

        playAudio.Stop();
        playAudio.volume = 0.5f;
        playAudio.PlayOneShot(attack);
        
    }

    public void DamageSound()
    {
        BgmInit(); //���� -> �ǰݽ�

        playAudio.Stop();
        if (!playAudio.isPlaying)
        {
            playAudio.volume = 0.7f;
            playAudio.PlayOneShot(damage);
        }
    }

    public void UnderWaterSound()
    {
        playAudio.Stop();
        playAudio.volume = 1f;
        playAudio.PlayOneShot(underWater);
        bgmAudio.spatialBlend = 0.8f; //���� ������ �ֱ�

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

    public void ScoreHighlightSound()
    {
        playAudio.volume = 0.8f;
        playAudio.PlayOneShot(scoreHighlight);
    }
}

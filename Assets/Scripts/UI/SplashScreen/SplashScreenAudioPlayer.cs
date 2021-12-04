using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenAudioPlayer : MonoBehaviour
{
    public void PlaySplashAudio1()
    {
        AudioManager.Instance.PlaySoundOneShot("SplashScreenAudio1");
    }
    public void PlaySplashAudio2()
    {
        AudioManager.Instance.PlaySoundOneShot("SplashScreenAudio2");
    }
    public void PlayBGM()
    {
        AudioManager.Instance.PlaySound("BGM1");
    }
}

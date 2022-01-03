using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickManager : MonoBehaviour
{
    public void PlayAudio()
    {
        GameAudioManager.Instance.PlaySoundOneShot("ButtonClick");
    }
}

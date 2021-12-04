using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickManager : MonoBehaviour
{
    public void PlayAudio()
    {
        AudioManager.Instance.PlaySoundOneShot("ButtonClick");
    }
}

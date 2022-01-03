using UnityEngine;

public class BattleStartAnimationEventManager : MonoBehaviour
{
    [SerializeField]
    private string clash_sound1_Name, clash_sound2_Name, three, two, one, letsGo;
    public void PlaySound(string soundName)
    {
        GameAudioManager.Instance.PlaySoundOneShot(soundName);
    }
}

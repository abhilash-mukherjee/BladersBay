using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPlay_SD : MonoBehaviour
{
    public List<UIElementsPopupManager > levelsUINew_SDs;
    [SerializeField]
    private bool isPlayClick = true;
    [SerializeField]
    private GameObject infoButton,profile;
    [SerializeField]
    private LevelButtonFillAnimationManager LevelButtonFillAnimationManager;

    [SerializeField]
    private Image background;
    public void StartUIPopUpPopDown(bool isReversed){
        isPlayClick = !isPlayClick;
        // infoButton.SetActive(isPlayClick);
        // profile.SetActive(isPlayClick);
        background.enabled = isPlayClick;
        LevelButtonFillAnimationManager.StartLevelFillAnimation();
        foreach(var levelsUINew_SD in levelsUINew_SDs){
            levelsUINew_SD.AnimateUIStart(isReversed);
        }
    }
}

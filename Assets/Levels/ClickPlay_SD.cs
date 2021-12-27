using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlay_SD : MonoBehaviour
{
    public List<LevelsUINew_SD> levelsUINew_SDs;
    [SerializeField]
    private bool isPlayClick = true;
    [SerializeField]
    private GameObject iObject;
    public void ClickEventUI(bool isReversed){
        isPlayClick = !isPlayClick;
        iObject.SetActive(isPlayClick);
        foreach(var levelsUINew_SD in levelsUINew_SDs){
            levelsUINew_SD.AnimateUIStart(isReversed);
        }
    }
}

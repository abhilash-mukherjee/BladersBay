using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlay_SD : MonoBehaviour
{
    public List<LevelsUINew_SD> levelsUINew_SDs;
    public void ClickEventUI(bool isReversed){
        foreach(var levelsUINew_SD in levelsUINew_SDs){
            levelsUINew_SD.AnimateUIStart(isReversed);
            // levelsUINew_SD.timeElapsed = 0f;
        }
    }
}

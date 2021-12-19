using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlay_SD : MonoBehaviour
{
    public List<MovementDisable_SD> movementDisable_SDs;
    public List<MovementEnable_SD> movementEnable_SDs;
    public MovementScale_SD Levels;
    public MovementDescale_SD DeLevels;

    GameObject reference;

    void Update(){
        Debug.Log(Levels.enabled);
        if(!Levels.enabled) Levels.timeElapsed = 0f;
        if(!DeLevels.enabled) DeLevels.timeElapsed = 0f;
    }

    public void ClickEvent(){
        Levels.enabled = true;
        DeLevels.enabled = false;
        for(int i=0;i<movementDisable_SDs.Count;i++){
            movementDisable_SDs[i].timeElapsed = 0f;
        }
        for(int i=0;i<movementDisable_SDs.Count;i++){
            movementDisable_SDs[i].enabled = true;
            movementEnable_SDs[i].enabled = false;
        }
    }

    public void ClickBackEvent(){
        DeLevels.enabled = true;
        Levels.enabled = false;
        for(int i=0;i<movementDisable_SDs.Count;i++){
            movementEnable_SDs[i].timeElapsed = 0f;
        }
        for(int i=0;i<movementEnable_SDs.Count;i++){
            movementDisable_SDs[i].enabled = false;
            movementEnable_SDs[i].enabled = true;
        }
    }
}

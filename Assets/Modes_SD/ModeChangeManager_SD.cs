using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChangeManager_SD : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> changeEvalutor_SDs;
    public BeyBladeStateController activeState;
    public float speed = 10f;
    public void DisplayManager(float change){
        foreach(GameObject b in changeEvalutor_SDs){
            ModeChangeEvalutor_SD gameObjectEvalutor = b.GetComponent<ModeChangeEvalutor_SD>();
            if(gameObjectEvalutor.beyBladeStateName == activeState.CurrentState.StateName){
                if(gameObjectEvalutor.loader.fillAmount == 1f){
                    StartCoroutine(TransitionEffect(gameObjectEvalutor.transitionEffect));
                    gameObjectEvalutor.logo.GetComponent<Image>().color = new Color(255,255,255,255);
                }
                else{
                gameObjectEvalutor.loader.fillAmount += change;
                }
                

            }
        }
    }

    IEnumerator TransitionEffect(GameObject transitionEffect){
        transitionEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        transitionEffect.SetActive(false);
    }
}

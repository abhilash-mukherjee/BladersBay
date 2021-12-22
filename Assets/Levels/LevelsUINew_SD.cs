using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsUINew_SD : MonoBehaviour
{
    public Vector3 start,end;
    public bool isScale;
    public float timeElapsed;

    // public bool isReversed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AnimateUIStart(bool isReversed){
        gameObject.SetActive(true);
        if(isReversed){
            StartCoroutine(AnimateUIReverse());
        }
        else{
            StartCoroutine(AnimateUI());
        }
        // StartCoroutine(AnimateUI());
        // StartCoroutine(AnimateUIReverse());
    }


    IEnumerator AnimateUI(){
        Vector3 startPos = start;
        Vector3 endPos = end;
        Vector3 trans = isScale ? transform.localScale : transform.localPosition;
        
        while(trans != endPos){
            // if(trans.ToString("F8") == endPos.ToString("F8") ){
            //     Debug.Log("Detected" + gameObject.name);
            // }
            if(isScale){
                
                transform.localScale = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localScale;
            }else{
                transform.localPosition = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localPosition;
            }
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        timeElapsed = 0;
        if(!isScale){
            gameObject.SetActive(false);
        }
    }

    IEnumerator AnimateUIReverse(){
        Vector3 trans = isScale ? transform.localScale : transform.position;
        Vector3 startPos = end;
        Vector3 endPos = start;
        while(trans != endPos){
            if(isScale){
                transform.localScale = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localScale;
            }else{
                transform.localPosition = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localPosition;
            }
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        timeElapsed = 0;
        if(isScale){
            gameObject.SetActive(false);
        }
    }


}

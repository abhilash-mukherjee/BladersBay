using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateModesUI_SD : MonoBehaviour
{
    float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate(float val){
        StartCoroutine(AnimateUI(val));
    }

    IEnumerator AnimateUI(float val){
        float start = gameObject.GetComponent<Image>().fillAmount;
        while(gameObject.GetComponent<Image>().fillAmount <= val){
            gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(start,val,timeElapsed);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCard_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transitionGameObject;
    public float timeElapsed = 0f;

    public float scaleElapsed = 0f;
    void Start()
    {
        transitionGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableManager(){
        StartCoroutine(Animate());
    }

    IEnumerator Animate(){
        scaleElapsed = 0f;
        while(transform.localScale != Vector3.zero){
            transform.localScale = Vector3.Lerp(Vector3.one,Vector3.zero,scaleElapsed);
            scaleElapsed += Time.deltaTime * 0.8f;

            yield return null;
        }

        scaleElapsed = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnmationLeftRight_SD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject left,right;

    [Range(0f,4f)]
    public float rate = 0;
    private float timeElapsed = 0;
    void Start()
    {
        // StartCoroutine(LeftRightSliderDesign());
    }

    void Update(){
        rate += Time.deltaTime;
        left.gameObject.transform.localPosition = Vector3.Lerp(new Vector3(-1866f,0,0),new Vector3(-134.67f,0,0),rate);
        right.gameObject.transform.localPosition = Vector3.Lerp(new Vector3(2024f,0,0),new Vector3(292.67f,0,0),rate);
    }
//-1866
    // IEnumerator LeftRightSliderDesign(){
    //     while(timer > 0){
    //     left.gameObject.transform.localPosition = Vector3.Lerp(new Vector3(-1866f,0,0),new Vector3(-134.67f,0,0),timeElapsed/3);
    //     timeElapsed += Time.deltaTime;
    //     timer --;
    //     yield return null;
    //     }
    // }
}

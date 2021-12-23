using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange_SD : MonoBehaviour
{
    // Start is called before the first frame update
    int count = 0;
    public List<GameObject> modes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightClick(){
        Debug.Log(count);
        foreach(GameObject mode in modes){
            mode.SetActive(false);
        }
        count = (count+1) % (modes.Count);
        modes[count].SetActive(true);
    }

    public void LeftClick(){
        foreach(GameObject mode in modes){
            mode.SetActive(false);
        }
        if(count <= 0){
            count = modes.Count -1;
        }
        else{
            count --;
        }

        modes[count].SetActive(true);
    }

}

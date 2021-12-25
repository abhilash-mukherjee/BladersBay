using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile_SD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool isGameObjectVisible = false;
    [SerializeField]
    GameObject text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visible(){
        gameObject.SetActive(true);
        if(text)
            text.SetActive(false);
    }

    public void Invisible(){
        gameObject.SetActive(false);
        if(text)
            text.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingIsland_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public BoolVariable isActive;
    [SerializeField]
    private GameObject image;
    private void Start()
    {
        image.SetActive(!isActive.Value);
    }
}

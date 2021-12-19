using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUI_SD : MonoBehaviour
{
    public List<LevelUI_SD> levelNumberChild;
    public List<LevelUI_SD> connectingChild;
    float timeElapsed = 0;
    bool shouldFill = false;
    public int index = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelChanging(int index)
    {
        for (int i = 1; i < index; i++)
        {
            levelNumberChild[i-1].GetComponent<LevelUI_SD>().displayUI.fillAmount = 1f;
            if (i != 1)
                connectingChild[i - 2].GetComponent<LevelUI_SD>().displayUI.fillAmount = 1f;
        }
        if (index == 1) StartCoroutine(FillStroke(0));
        else StartCoroutine(FillConnectingStroke(index - 2));
    }


    IEnumerator FillStroke(int index)
    {
        float timeElapsed = levelNumberChild[index].GetComponent<LevelUI_SD>().timeElapsed;
        while (levelNumberChild[index].GetComponent<LevelUI_SD>().displayUI.fillAmount < 1f)
        {
            levelNumberChild[index].GetComponent<LevelUI_SD>().displayUI.fillAmount = levelNumberChild[index].GetComponent<LevelUI_SD>().timeElapsed;
            levelNumberChild[index].GetComponent<LevelUI_SD>().timeElapsed += Time.deltaTime;
            yield return null;
        }

        levelNumberChild[index].GetComponent<LevelUI_SD>().isFilled = true;
        levelNumberChild[index].GetComponent<LevelUI_SD>().timeElapsed = 0f;

    }

    IEnumerator FillConnectingStroke(int index)
    {
        Debug.Log(index);
        while (connectingChild[index].GetComponent<LevelUI_SD>().displayUI.fillAmount < 1f)
        {
            connectingChild[index].GetComponent<LevelUI_SD>().displayUI.fillAmount = connectingChild[index].GetComponent<LevelUI_SD>().timeElapsed;
            connectingChild[index].GetComponent<LevelUI_SD>().timeElapsed += Time.deltaTime;
            yield return null;
        }

        connectingChild[index].GetComponent<LevelUI_SD>().isFilled = true;
        connectingChild[index].GetComponent<LevelUI_SD>().timeElapsed = 0f;
        StartCoroutine(FillStroke(index + 1));
    }
}

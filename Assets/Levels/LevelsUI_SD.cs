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
        LevelChanging(10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelChanging(int index)
    {
        for (int i = 1; i < index; i++)
        {
            levelNumberChild[i-1].displayUI.fillAmount = 1f;
            levelNumberChild[i-1].centerUI.gameObject.SetActive(true);
            // levelNumberChild[i-1].displayText.color = new Color()
            if (i != 1)
                connectingChild[i - 2].displayUI.fillAmount = 1f;
        }
        if (index == 1) StartCoroutine(FillStroke(0));
        else StartCoroutine(FillConnectingStroke(index - 2));
    }


    IEnumerator FillStroke(int index)
    {
        float timeElapsed = levelNumberChild[index].timeElapsed;
        while (levelNumberChild[index].displayUI.fillAmount < 1f)
        {
            levelNumberChild[index].displayUI.fillAmount = levelNumberChild[index].timeElapsed;
            levelNumberChild[index].timeElapsed += Time.deltaTime;
            yield return null;
        }

        levelNumberChild[index].centerUI.gameObject.SetActive(true);

        levelNumberChild[index].isFilled = true;
        levelNumberChild[index].timeElapsed = 0f;

    }

    IEnumerator FillConnectingStroke(int index)
    {
        Debug.Log(index);
        while (connectingChild[index].displayUI.fillAmount < 1f)
        {
            connectingChild[index].displayUI.fillAmount = connectingChild[index].timeElapsed;
            connectingChild[index].timeElapsed += Time.deltaTime;
            yield return null;
        }

        connectingChild[index].isFilled = true;
        connectingChild[index].timeElapsed = 0f;
        StartCoroutine(FillStroke(index + 1));
    }
}

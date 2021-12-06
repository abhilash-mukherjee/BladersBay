using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_SD_Animate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject timerUI, versus, lowerPart, upperPart;
    int timer = 3;
    private float timeElapsed = 0, rate = 0;

    void Start()
    {
        StartCoroutine(TimerUpdateText());
        StartCoroutine(TimerUpdateSliderDesign());
    }

    IEnumerator TimerUpdateSliderDesign()
    {
        while (timer > 0)
        {
            lowerPart.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 0.5f, timeElapsed / 3);
            upperPart.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 0.5f, timeElapsed / 3);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }



    IEnumerator TimerUpdateText()
    {
        while (timer > 0)
        {
            timerUI.GetComponent<Text>().text = timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
        timerUI.transform.parent.gameObject.SetActive(false);
        timerUI.SetActive(false);
        versus.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        // versus.gameObject.SetActive(false);

    }

    void Update()
    {
        if (versus.activeSelf)
        {
            versus.gameObject.transform.localScale = Vector3.Lerp(new Vector3(2f, 2f, 2f), new Vector3(0.3604286f, 0.3604286f, 0.3604286f), rate*4f);
            rate += Time.deltaTime;
        }
    }

}

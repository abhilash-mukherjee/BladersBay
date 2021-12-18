using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateIconUIHolder : MonoBehaviour
{
    [SerializeField]
    private BeyBladeStateName beyBladeStateName;
    [SerializeField]
    private StateData StateData;
    [SerializeField]
    private Image loader;
    [SerializeField]
    private Image logo;
    [SerializeField]
    private GameObject transitionEffect;
    [SerializeField]
    [Range(0f, 10f)]
    private float coroutineTime;
    private bool isCharged = false;
    private bool isCoroutineCalled = false;
    private void Update()
    {
        DisplayUI();
    }

    private void Start()
    {
        if (StateData.IsLocked)
            gameObject.SetActive(false);
    }
    public void DisplayUI()
    {
        if (loader.fillAmount >= 1f)
        {
            if (isCoroutineCalled || isCharged)
                return;
            isCharged = true;
            isCoroutineCalled = true;
            StartCoroutine(TransitionEffect(transitionEffect));
            logo.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            isCharged = false;
            loader.fillAmount = StateData.CurrentAvailabilityIndex / StateData.ThresholdStateAvailabiltyIndex;
        }
    }

    IEnumerator TransitionEffect(GameObject transitionEffect)
    {
        Debug.Log("Coroutine called");
        transitionEffect.SetActive(true);
        yield return new WaitForSeconds(coroutineTime);
        transitionEffect.SetActive(false);
        isCoroutineCalled = false;
    }
}

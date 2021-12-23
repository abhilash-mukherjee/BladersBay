using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHealthBar, enemyHealthBar, VS;
    public void StartAnimationAfterEventRecieved(float _time)
    {
        StartCoroutine(CallEnableHealthBarsFunction(_time));
    }
    IEnumerator CallEnableHealthBarsFunction(float _time)
    {
        yield return new WaitForSeconds(_time);
        EnableHealthBars();
    }
    private void EnableHealthBars()
    {
        playerHealthBar.SetActive(true);
        enemyHealthBar.SetActive(true);
        VS.SetActive(true);
    }
}

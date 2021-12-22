using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPopUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player, winMessege, looseMessege;
    private bool m_hasPlayerWon = false;
    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += CheckIfWonOrLost;
        ParabolaController.OnParabolaReachedDestination += PopUpMessege;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= CheckIfWonOrLost;
        ParabolaController.OnParabolaReachedDestination += PopUpMessege;
    }

    private void PopUpMessege()
    {
        if (m_hasPlayerWon) winMessege.SetActive(true);
        else looseMessege.SetActive(true);
    }

    private void CheckIfWonOrLost(GameObject _winner, GameObject _looser)
    {
        if (_winner == player) m_hasPlayerWon = true;
        else m_hasPlayerWon = false;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStarter : MonoBehaviour
{
    [SerializeField]
    private GameEvent OnMatchStarted;
    [SerializeField]
    private float startMatchTime = 3f;
    private void Awake()
    {
        StartCoroutine(StartMatch(startMatchTime));
    }

    IEnumerator StartMatch(float _time)
    {
        yield return new WaitForSeconds(_time);
        OnMatchStarted.Raise();
    }
}

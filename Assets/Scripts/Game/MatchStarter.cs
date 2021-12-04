using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStarter : MonoBehaviour
{
    public delegate void MatchStartHandler(GameObject _beyBlade);
    public static event MatchStartHandler OnMatchStarted;
    [SerializeField]
    private GameObject player, enemy;
    [SerializeField]
    private GameObject healthSystem,playerHealthBar, enemyHealthBar;
    [SerializeField]
    private float startMatchTime = 3f;
    private void Awake()
    {
        StartCoroutine(StartMatch(startMatchTime));
    }

    IEnumerator StartMatch(float _time)
    {
        yield return new WaitForSeconds(_time);
        healthSystem.SetActive(true);
        playerHealthBar.SetActive(true);
        enemyHealthBar.SetActive(true);
        playerHealthBar.GetComponent<HealthDisplayManager>().SetBeyBlade(player);
        enemyHealthBar.GetComponent<HealthDisplayManager>().SetBeyBlade(enemy);
    }
}

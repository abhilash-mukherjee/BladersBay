using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player, Enemy;
    [SerializeField]
    private Vector3 playerInitialPos, enemyInitialPos;
    private void Awake()
    {
        Enemy.SetActive(false);
        Player.SetActive(false);
    }
    public void SpawnBeyBladesAfteEventRecieved(float _time)
    {
        StartCoroutine(CallSpawnBeyBladeFunction(_time));
    }
    IEnumerator CallSpawnBeyBladeFunction(float _time)
    {
        yield return new WaitForSeconds(_time);
        SpawnBeyBlades();
    }
    private void SpawnBeyBlades()
    {
        Player.SetActive(true);
        Player.transform.position = playerInitialPos;
        Enemy.SetActive(true);
        Enemy.transform.position = enemyInitialPos;
    }

}

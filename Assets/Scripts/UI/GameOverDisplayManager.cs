using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverDisplayManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI UIText1,UIText2;
    [SerializeField]
    private Vector3 maxScale =  Vector3.one* 0.66f;
    [SerializeField]
    private float lerpSpeed = 10f;
    [SerializeField]
    private string playerWinMessege1 = "Congrat's !!!";
    [SerializeField]
    private string playerWinMessege2 = "You Won";
    [SerializeField]
    private string enemyWinMessege1 = "Game Over...";
    [SerializeField]
    private string enemyWinMessege2 = "Enemy Won";
    private bool hasPoppedUpGameOver = false;
    private bool shouldPoopUpGameOver = false;
    private void OnEnable()
    {
        StaminaManager.OnDied += DisplayGameOver;
    }

   
    private void OnDisable()
    {
        StaminaManager.OnDied -= DisplayGameOver; 
    }
    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }
    public void PlayAgain()
    {
        GameSceneManager.Instance.LoadScene("GamePlay");
    }

    private void Update()
    {
        LerpGameOverScale();
    }

    private void LerpGameOverScale()
    {
        
        if (transform.localScale.magnitude >= maxScale.magnitude || hasPoppedUpGameOver)
        {
            hasPoppedUpGameOver = true;
            return;
        }
        if(shouldPoopUpGameOver)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.unscaledDeltaTime * lerpSpeed);
        }

    }

    public void DisplayGameOver(GameObject _gameObject)
    {
        if (hasPoppedUpGameOver)
            return;
        if(_gameObject.CompareTag("Enemy"))
        {
            UIText1.text = playerWinMessege1;
            UIText2.text = playerWinMessege2;
        }
        if(_gameObject.CompareTag("Player"))
        {
            UIText1.text = enemyWinMessege1;
            UIText2.text = enemyWinMessege2;
        }
        shouldPoopUpGameOver = true;
    }
}

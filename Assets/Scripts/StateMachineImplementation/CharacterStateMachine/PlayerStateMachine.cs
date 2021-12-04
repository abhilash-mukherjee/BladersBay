using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK;
using JMRSDK.InputModule;
using System;

[RequireComponent(typeof(InputController))]
public class PlayerStateMachine : CharacterStateMachine
{
    private void Awake()
    {
        gameObject.AddComponent<BalanceState>();
        state = GetComponent<BalanceState>();
        state.Enter(GetComponent<BeyBladeParameters>().SafeDistance);
    }
    private void OnEnable()
    {
         InputController.OnSwiped += RespondToSwipe;
    }
    private void OnDisable()
    {
        InputController.OnSwiped -= RespondToSwipe;
    }

    private void RespondToSwipe(SwipeStatus.SwipeMode _mode, GameObject _gameObject)
    {
        if (_gameObject != gameObject)
            return;
       
        switch (_mode)
        {
            case SwipeStatus.SwipeMode.UP_SWIPE:
                OnSwipeUp();
                break;
            case SwipeStatus.SwipeMode.LEFT_SWIPE:
                OnSwipeLeft();
                break;
            case SwipeStatus.SwipeMode.RIGHT_SWIPE:
                OnSwipeRight();
                break;
            default:
                return;

        }
    }

    void KeyBoardInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.AddComponent<BalanceState>();
            var _newState = GetComponent<BalanceState>();
            ChangeState(_newState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.AddComponent<AttackState>();
            var _newState = GetComponent<AttackState>();
            ChangeState(_newState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.AddComponent<DefenceState>();
            var _newState = GetComponent<DefenceState>();
            ChangeState(_newState);
        }

    }


    public void OnSwipeLeft()
    {
        Debug.Log("Defence Mode");
        gameObject.AddComponent<DefenceState>();
        var _newState = GetComponent<DefenceState>();
        ChangeState(_newState);
        
    }

    public void OnSwipeRight()
    {
        Debug.Log("Attack Mode");
        gameObject.AddComponent<AttackState>();
        var _newState = GetComponent<AttackState>();
        ChangeState(_newState);
    }

    public void OnSwipeUp()
    {
        Debug.Log("Balance Mode");
        gameObject.AddComponent<BalanceState>();
        var _newState = GetComponent<BalanceState>();
        ChangeState(_newState);
    }

}

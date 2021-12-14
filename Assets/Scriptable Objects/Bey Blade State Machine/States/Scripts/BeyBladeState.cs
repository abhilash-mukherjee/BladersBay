using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New State", menuName = "State Machine / State")]
public class BeyBladeState : ScriptableObject
{
    [SerializeField]
    protected BeyBladeAction[] actions;
    [SerializeField]
    protected BeyBladeTransition[] transitions;
    [SerializeField]
    protected BeyBladeStateName stateName;
    public BeyBladeStateName StateName { get => stateName; }

    [SerializeField]
    private Color sceneGizmoColor = Color.gray; 
    public Color SceneGizmoColor { get => sceneGizmoColor; }

    public void UpdateState(BeyBladeStateController _stateController)
    {
        DoAction(_stateController);
        CheckTransitions(_stateController);
    }

    private void DoAction(BeyBladeStateController _stateController)
    {
        if (actions == null) return;
        if (actions.Length == 0) return;
        for (int i = 0; i < actions.Length; i++) actions[i].Act(_stateController);
    }

    private void CheckTransitions(BeyBladeStateController _stateController)
    {
        if (transitions == null) return;
        if (transitions.Length == 0) return;
        for (int i = 0; i < transitions.Length; i++)
        {
            bool _decissionSucceded = EvaluateAllDecissions(transitions[i], _stateController);
            if (_decissionSucceded)
            {
                //Debug.Log("True. Transitioning to " + transitions[i].TrueState + " from" + this.name);
                _stateController.TransitionToState(transitions[i].TrueState);
                break;
            }
            else
            {
                // Debug.Log("False. Transitioning to " + transitions[i].FalseState + " from" + this.name);
                _stateController.TransitionToState(transitions[i].FalseState);
            }
        }
    }

    private bool EvaluateAllDecissions(BeyBladeTransition _beyBladeTransition, BeyBladeStateController _stateController)
    {
        var _decissions = _beyBladeTransition.Decissions;
        if (_decissions == null)
            return false;
        else if (_decissions.Length == 0)
            return false;
        else
        {
            for (int i = 0; i < _decissions.Length; i++)
            {
                if (_decissions[i].Decide(_stateController) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }

}

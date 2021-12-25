using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New aI State", menuName ="AI / AI State")]
public class AIState : MonoBehaviour
{
    [SerializeField]
    private List<AIAction> actions;

    public void UpdateState(StateController _enemyStateController,StateController _playerStateController, AIController _AIController )
    {

    }
}


public abstract class AIAction : ScriptableObject
{
    public abstract void Act(StateController _enemyStateController, StateController _playerStateController, AIController _AIController);
}
public abstract class AIDecission : ScriptableObject
{
    public abstract bool Decide(StateController _enemyStateController, StateController _playerStateController, AIController _AIController);
}

[System.Serializable]
public class AITransition
{
    [SerializeField]
    private AIDecission[] decissions;
    public BeyBladeStateName TrueStateName, FalseStateName;

    public bool AllDecissionsSucced(StateController _stateController, State _state)
    {
        if (decissions == null)
            return false;
        else if (decissions.Length == 0)
            return false;
        else
        {
            for (int i = 0; i < decissions.Length; i++)
            {
                
            }
            return true;
        }
    }
}

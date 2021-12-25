using UnityEngine;

public class AIController: InputController
{
    [SerializeField]
    private KeyCode attackTrigger, defenceTrigger, staminaTrigger, balanceTrigger;
    [SerializeField]
    private GameEvent attackTriggerEvent, defenceTriggerEvent, staminaTriggerEvent, balanceTriggerEvent;
    [SerializeField]
    private StateController enemyStateController, playerStateController;
    private AIState m_CurrentState;
    private void Update()
    {
        m_CurrentState.UpdateState(enemyStateController, playerStateController,this);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState: MonoBehaviour
{

    protected BeyBladeParameters beyBladeParameters;
    protected StaminaManager staminaManager;
    protected CharacterStateMachine stateMachine;
    protected GameObject player;
    private void Awake()
    {
        beyBladeParameters = GetComponent<BeyBladeParameters>();
        stateMachine = GetComponent<CharacterStateMachine>();
        staminaManager = GetComponent<StaminaManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void Enter(float _safeDistance)
    {
    }
    public virtual void TakeDamage(float _dmg)
    {
        
    }

    public virtual void DoDamage( CharacterStateMachine _enemyStateMachine)
    {
    }

    public virtual float CalculateMovementMultiplier()
    {
        return 0;
    }

    public virtual float CalculateStaminaLoss()
    {
        return 0;
    }
    public virtual Vector3 Move(float _safeDistance)
    {
        return Vector3.zero;
    }


    public virtual IEnumerator AIModeSwitch(float _time, float _safeDistance)
    {
        yield return null;
    }

    protected virtual void NewAttackState()
    {

    }
    protected virtual void NewDefenceState()
    {

    }
    protected virtual void NewBalanceState()
    {

    }
}

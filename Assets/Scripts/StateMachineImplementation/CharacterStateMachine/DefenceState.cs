﻿using System.Collections;
using UnityEngine;

public class DefenceState: CharacterState
{
    public override void Enter(float _safeDistance)
    {
        beyBladeParameters.CurentMode = "Defence Mode";
        var uIDisplay = FindObjectOfType<ModeUIDisplayManager>();
        if (uIDisplay != null) uIDisplay.ChangeSprite(1);
        if (gameObject.CompareTag("Enemy"))
            StartCoroutine(AIModeSwitch(Random.Range(beyBladeParameters.stateChangeGapLow, beyBladeParameters.stateChangeGapHigh), _safeDistance));
    }
    public override void TakeDamage(float _dmg)
    {
        var _selfDamage = beyBladeParameters.defenceMode_SelfDamage;
        staminaManager.ReduceStamina(_dmg * _selfDamage);
    }

    public override void DoDamage(CharacterStateMachine _enemyStateMachine)
    {
        var _enemyDmg = beyBladeParameters.defenceMode_EnemyDamage;
        _enemyStateMachine.TakeDamage(_enemyDmg);
    }
    public override float CalculateMovementMultiplier()
    {
        return beyBladeParameters.defenceMode_MovementMultiplier;
    }
    public override IEnumerator AIModeSwitch(float _time, float _safeDistance)
    {
        yield return new WaitForSeconds(_time);
        Debug.Log($"Inside Mode Swtch of {gameObject}");
        var _seperation = player.transform.position - transform.position;
        if (player.GetComponent<BeyBladeParameters>().CurentMode == "Attack Mode")
        {
            if (_seperation.magnitude <= _safeDistance)
            {
                int _rand = Random.Range(0, 4);
                if (_rand == 0)
                    NewAttackState();
                else 
                    NewDefenceState();
            }
            else
            {
                int _rand = Random.Range(0, 4);
                if (_rand == 0)
                    NewAttackState();
                else if (_rand == 1)
                    NewBalanceState();
                else
                    NewDefenceState();
            }
        }
        if (player.GetComponent<BeyBladeParameters>().CurentMode == "Defence Mode")
        {
            if (_seperation.magnitude <= _safeDistance)
            {
                int _rand = Random.Range(0, 2);
                if (_rand == 0)
                    NewDefenceState();
                else
                    NewBalanceState();
            }
            else
            {
                int _rand = Random.Range(0, 4);
                if (_rand == 0)
                    NewDefenceState();
                else
                    NewBalanceState();

            }
        }
        if (player.GetComponent<BeyBladeParameters>().CurentMode == "Balance Mode")
        {
            int _rand = Random.Range(0, 3);
            if (_rand == 0)
                NewAttackState();
            else if (_rand == 1)
                NewDefenceState();
            else
                NewBalanceState();
        }
        StartCoroutine(AIModeSwitch(Random.Range(beyBladeParameters.stateChangeGapLow, beyBladeParameters.stateChangeGapHigh), _safeDistance));
    }

    protected override void NewAttackState()
    {
        Destroy(this);
        gameObject.AddComponent<AttackState>();
        var arr = GetComponents<AttackState>();
        stateMachine.ChangeState(arr[arr.Length - 1]);
    }

    protected override void NewDefenceState()
    {
        Destroy(this);
        gameObject.AddComponent<DefenceState>();
        var arr = GetComponents<DefenceState>();
        stateMachine.ChangeState(arr[arr.Length - 1]);
    }

    protected override void NewBalanceState()
    {
        Destroy(this);
        gameObject.AddComponent<BalanceState>();
        var arr = GetComponents<BalanceState>();
        stateMachine.ChangeState(arr[arr.Length - 1]);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StateController))]
public class BeyBladeHealthManager : MonoBehaviour
{
    public delegate void AttackManager(StateController _stateController, float _collisionIndex);
    public static event AttackManager OnBeyBladeAttacked;
    [SerializeField]
    private StateController stateController;
    [SerializeField]
    private FloatReference maxHealth;
    [SerializeField][Tooltip("The constant tat gets multiplied to damage value")]
    [Range(0f,10f)]
    private float damageConstant = 5f;
    [SerializeField]
    [Tooltip("The constant tat gets multiplied to stamina value")]
    private float staminaConstant;
    [SerializeField]
    private FloatVariable currentHealth;
    [SerializeField]
    private GameEvent gameEvent;

    private void Awake()
    {
        CollisionManager.OnBeyBladesCollidedNormally += HandleHealthAfterCollision;
        currentHealth.Value = maxHealth.Value;
    }

    private void OnDisable()
    {
        CollisionManager.OnBeyBladesCollidedNormally -= HandleHealthAfterCollision;
    }

    private void Update()
    {
        currentHealth.Value += stateController.CurrentState.Data.StaminaValue * Time.deltaTime * staminaConstant;
    }
    private  void HandleHealthAfterCollision(INormalCollision _Collision)
    {
        if (_Collision.IsAttacker(gameObject) == false && _Collision.IsVictim(gameObject) == false)
        {
            Debug.Log("Neither Attacker Nor Victim");
            return;
        }
        else if(_Collision.IsVictim (gameObject))
        {
            var _attacker = _Collision.GetAttacker(gameObject);
            if(_attacker == null)
            {
                return;
            }

            float _dmg = CalculateDamageWhileDefending(_Collision.CollisionIndex, _attacker);
            currentHealth.Value -= _dmg;

        }
        else if (_Collision.IsAttacker(gameObject))
        {
            var _victim = _Collision.GetVictim(gameObject);
            if (_victim == null)
            {
                return;
            }
            RaiseAttackEvent(_Collision.CollisionIndex);
            float _dmg = CalculateDamageWhileAttacking(_Collision.CollisionIndex, _victim);
            currentHealth.Value -= _dmg;
        }
        gameEvent.Raise();
    }

    private void RaiseAttackEvent(float collisionIndex)
    {
        OnBeyBladeAttacked?.Invoke(stateController,collisionIndex);
    }

    private float CalculateDamageWhileAttacking(float _collisionIndex, GameObject _victim)
    {
        float _dmg = damageConstant * _victim.GetComponent<StateController>().CurrentState.Data.DefenceValue * stateController.CurrentState.Data.DamageValue * _collisionIndex;
        return _dmg;
    }

    private float CalculateDamageWhileDefending(float _collisionIndex, GameObject _attacker)
    {
        float _dmg = damageConstant * _attacker.GetComponent<StateController>().CurrentState.Data.AttackValue * stateController.CurrentState.Data.DamageValue * _collisionIndex;
        return _dmg;
    }

}


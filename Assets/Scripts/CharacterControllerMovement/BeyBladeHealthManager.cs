using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeHealthManager : MonoBehaviour
{
    public delegate void HealthChangeHandler(float _currentHealth, float _maxHealth, GameObject _beyBladeObject);
    public static event HealthChangeHandler OnHealthChanged;
    [SerializeField]
    private List<CollisionType> collisionTypes = new List<CollisionType>();
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private BeyBladeValues beyBladeValues;
    [SerializeField][Tooltip("The constant tat gets multiplied to damage value")]
    [Range(0f,10f)]
    private float damageConstant = 5f;
    [SerializeField]
    [Tooltip("The constant tat gets multiplied to stamina value")]
    private float staminaConstant;
    private float m_currentHealth;
    public float CurrentHealth{ get => m_currentHealth; }
    private float CurrentHealth_Private 
    {
        get => m_currentHealth;
        set 
        {
            if (value >= maxHealth)
                m_currentHealth = maxHealth;
            else if (value <= 0f)
                m_currentHealth = 0f;
            else
                m_currentHealth = value;
            OnHealthChanged?.Invoke(m_currentHealth, maxHealth,gameObject);
        }
    }

    private void Awake()
    {
        CollisionManager.OnBeyBladesCollided += HandleHealthAfterCollision;
        CurrentHealth_Private = maxHealth;
    }

    private void OnDisable()
    {
        CollisionManager.OnBeyBladesCollided -= HandleHealthAfterCollision;
    }

    private void Update()
    {
        CurrentHealth_Private += beyBladeValues.StaminaValue * Time.deltaTime * staminaConstant;
    }
    private void HandleHealthAfterCollision(BeyBladeCollision _Collision)
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
            CurrentHealth_Private -= _dmg;

        }
        else if (_Collision.IsAttacker(gameObject))
        {
            var _victim = _Collision.GetVictim(gameObject);
            if (_victim == null)
            {
                return;
            }
            float _dmg = CalculateDamageWhileAttacking(_Collision.CollisionIndex, _victim);
            CurrentHealth_Private -= _dmg;
        }
    }

    private float CalculateDamageWhileAttacking(float _collisionIndex, GameObject _victim)
    {
        Debug.Log($"Collision index = {_collisionIndex}");
        float _dmg = damageConstant * _victim.GetComponent<BeyBladeValues>().DefenceValue * beyBladeValues.DamageValue * _collisionIndex;
        return _dmg;
    }

    private float CalculateDamageWhileDefending(float _collisionIndex, GameObject _attacker)
    {
        Debug.Log($"Collision index = {_collisionIndex}");
        float _dmg = damageConstant * _attacker.GetComponent<BeyBladeValues>().AttackValue * beyBladeValues.DamageValue * _collisionIndex;
        return _dmg;
    }
}

[System.Serializable]
public class CollisionType
{
    public string Type;
    public float AngleDifferenceUpperLimit;
    public float CollisionIndex;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State Values", menuName = "State Machine / State Values")]
public class StateValues : ScriptableObject
{
    [SerializeField]
    private BeyBladeStateName stateName;
    [SerializeField]
    [Range(0, 1)]
    protected float attackValue;
    [SerializeField]
    [Range(0, 1)]
    protected float defenceValue;
    [SerializeField]
    [Range(0, 1)]
    protected float staminaValue;
    [SerializeField]
    [Range(0, 1)]
    protected float damageValue;
    [SerializeField]
    protected float speed;
    public float AttackValue { get => attackValue; }
    public float DefenceValue { get => defenceValue; }
    public float StaminaValue { get => staminaValue; }
    public float DamageValue { get => damageValue; }
    public float Speed { get => speed; }
    public BeyBladeStateName StateName { get => stateName; }
}

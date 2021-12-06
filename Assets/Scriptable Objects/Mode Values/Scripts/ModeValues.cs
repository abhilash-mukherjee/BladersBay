using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mode Values", menuName = "Mode Values")]
public class ModeValues : ScriptableObject
{
    [SerializeField]
    protected string modeID;
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
    [SerializeField]
    protected InputGestures.SwipeMode swipeMode;
    [SerializeField]
    protected float thresholdModeAvailabilityIndex;
    [SerializeField]
    protected ModeAvailability modeAvailability;
    protected float m_modeAvailabilityIndex;
    public float AttackValue { get => attackValue; }
    public float DefenceValue { get => defenceValue; }
    public float StaminaValue { get => staminaValue; }
    public float DamageValue { get => damageValue; }
    public float Speed { get => speed; }
    public bool IsModeAvailable { get => modeAvailability.IsModeAvailable; }
    public InputGestures.SwipeMode SwipeMode { get => swipeMode; }
}

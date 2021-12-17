
using UnityEngine;

[CreateAssetMenu(fileName = "New State Values", menuName = "State Machine / State Values")]
public class StateData : ScriptableObject
{
    [SerializeField]
    private BeyBladeStateName stateName;
    [SerializeField]
    private bool isLocked;
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
    [Range(0f, 1f)]
    private float stateReplenishmentRate;
    [SerializeField]
    [Range(0f, 0.001f)]
    private float stateDepletionRate;
    [SerializeField]
    private float startingStateAvailabiltyIndx, thresholdStateAvailabiltyIndex, minimumStateAvailabiltyIndex;

    private float m_currentAvailabilityIndex;

    public float StateReplenishmentRate { get => stateReplenishmentRate; }
    public float StateDepletionRate { get => stateDepletionRate; }
    public float AttackValue { get => attackValue; }
    public float DefenceValue { get => defenceValue; }
    public float StaminaValue { get => staminaValue; }
    public float DamageValue { get => damageValue; }
    public float Speed { get => speed; }
    public BeyBladeStateName StateName { get => stateName; }
    public float CurrentAvailabilityIndex 
    { 
        get => m_currentAvailabilityIndex;
        set
        {
            if (value <= 0f) 
            { 
                m_currentAvailabilityIndex = 0f; 
                return; 
            }
            else if (value >= thresholdStateAvailabiltyIndex) 
            { 
                m_currentAvailabilityIndex = thresholdStateAvailabiltyIndex; 
                return; 
            }
            m_currentAvailabilityIndex = value;
        }
    }
    public float ThresholdStateAvailabiltyIndex { get => thresholdStateAvailabiltyIndex;  }
    public float MinimumStateAvailabiltyIndex { get => minimumStateAvailabiltyIndex; }
    public bool IsLocked { get => isLocked; set => isLocked = value; }

    private void OnEnable()
    {
        m_currentAvailabilityIndex = startingStateAvailabiltyIndx;
    }

    
  
}

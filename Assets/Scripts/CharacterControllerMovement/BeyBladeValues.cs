using System.Collections.Generic;
using UnityEngine;

public class BeyBladeValues: MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float attackValue;
    [SerializeField]
    [Range(0, 1)]
    private float defenceValue;
    [SerializeField]
    [Range(0, 1)]
    private float staminaValue;
    [SerializeField]
    [Range(0, 1)]
    private float damageValue;
    [SerializeField]
    private float speed;
    [SerializeField]
    private List<ModeValues> modeValueList ;
    public float AttackValue { get => attackValue; }
    public float DefenceValue { get => defenceValue;  }
    public float StaminaValue { get => staminaValue;  }
    public float DamageValue { get => damageValue; }
    public float Speed { get => speed;  }
}
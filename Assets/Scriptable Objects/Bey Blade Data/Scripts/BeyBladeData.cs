using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New BeyBlade Data", menuName = "BeyBlade Data")]
public class BeyBladeData : ScriptableObject
{
    public StateData AttackData, DefenceData, StaminaData, BalanceData;
    public GameObject Model;
}
 
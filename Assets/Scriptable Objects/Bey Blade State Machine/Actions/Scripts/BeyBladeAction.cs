using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Action", menuName = "State Machine / Action")]
public abstract class BeyBladeAction : ScriptableObject
{
    public abstract void Act(BeyBladeStateController _stateController);
}


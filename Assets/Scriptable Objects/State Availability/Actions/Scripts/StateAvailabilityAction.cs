
using UnityEngine;

public abstract class StateAvailabilityAction : ScriptableObject
{
    public abstract void Act(BeyBladeStateController _stateController);
}


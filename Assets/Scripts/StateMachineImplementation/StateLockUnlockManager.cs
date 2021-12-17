using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLockUnlockManager : MonoBehaviour
{
    [SerializeField]
    private List<ValueBooleanPAir> StateUnlockData = new List<ValueBooleanPAir>();
    [System.Serializable]
    private class ValueBooleanPAir
    {
        public StateData StateData;
        public bool IsLocked;
    }
    private void Awake()
    {
        foreach(var _pair in StateUnlockData)
        {
            if (_pair.IsLocked)
                _pair.StateData.IsLocked = true;
            else
                _pair.StateData.IsLocked = false;
        }
    }
}

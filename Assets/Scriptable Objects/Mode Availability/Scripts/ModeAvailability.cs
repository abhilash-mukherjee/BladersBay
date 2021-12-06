using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModeAvailability : ScriptableObject
{
    
    public delegate void ModeAvailabilityIndexChangeManager(string uid,float _newModeAvailabilityIndex);
    public static event ModeAvailabilityIndexChangeManager OnModeAvailabilityIndexChanged;
    [SerializeField]
    protected string modeID;
    protected float modeAvailabilityIndex;
    protected bool m_isModeAvailable = false;
    public bool IsModeAvailable
    {
        get { return m_isModeAvailable; }
    }
}

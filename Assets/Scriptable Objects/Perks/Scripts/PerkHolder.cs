using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class PerkHolder : ScriptableObject, IPerkHolder
{
    public GameObject perkPrefab;
    public virtual void RedeemAllPerks()
    {

    }
}

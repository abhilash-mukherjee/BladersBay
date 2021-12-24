using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Float Perk Holder Incremented With Percentage", menuName = "Perk Holders/ Float Perk Holders / Incremented With Percentage")]
public class FloatPerkHolder_IncrementedWithPercentage : FloatPerkHolder
{
    [SerializeField]
    private List<FloatPerk_IncrementedWithPercentage> floatPerks_IncrementedWithPercentage = new List<FloatPerk_IncrementedWithPercentage>();
    public override void RedeemAllPerks()
    {
        foreach (var _perk in floatPerks_IncrementedWithPercentage)
            _perk.Redeem();
    }
}

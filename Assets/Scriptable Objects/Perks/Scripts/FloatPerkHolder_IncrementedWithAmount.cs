using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Float Perk Holder Incremented With Amount", menuName ="Perk Holders/ Float Perk Holders / Incremented With Amount")]
public class FloatPerkHolder_IncrementedWithAmount : FloatPerkHolder
{
    [SerializeField]
    private List<FloatPerk_IncrementedWithAmount> floatPerks_IncrementedWithAmount = new List<FloatPerk_IncrementedWithAmount>();
    public override void RedeemAllPerks()
    {
        foreach (var _perk in floatPerks_IncrementedWithAmount)
            _perk.Redeem();
    }
}

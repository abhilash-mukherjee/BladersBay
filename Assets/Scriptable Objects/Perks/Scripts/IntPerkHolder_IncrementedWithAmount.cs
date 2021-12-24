﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Int Perk Holder Incremented With Amount", menuName = "Perk Holders/ Int Perk Holders / Incremented With Amount")]
public class IntPerkHolder_IncrementedWithAmount : PerkHolder
{
    [SerializeField]
    private List<IntPerk_IncrementedWithAmount> inttPerks_IncrementedWithAmount = new List<IntPerk_IncrementedWithAmount>();
    public override void RedeemAllPerks()
    {
        foreach (var _perk in inttPerks_IncrementedWithAmount)
            _perk.Redeem();
    }
}

using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Boolean Perk Holder", menuName = "Perk Holders/ boolean perk holder")]
public class BooleanPerkHolder : PerkHolder
{
    [SerializeField]
    private List<BooleanPerk> booleanPerks;
    public override void RedeemAllPerks()
    {
        foreach (var perk in booleanPerks)
            perk.Redeem();
    }
}

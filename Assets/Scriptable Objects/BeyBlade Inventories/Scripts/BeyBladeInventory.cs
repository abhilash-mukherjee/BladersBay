using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeyBlade Inventory", menuName = "Inventory")]
public class BeyBladeInventory : ScriptableObject
{
    private List<PerkHolder> inventoryPerkList = new List<PerkHolder>();

    public List<PerkHolder> InventoryPerkList { get => inventoryPerkList; }

    public void AddPerkToInventory(PerkHolder _perk)
    {
        if (inventoryPerkList.Contains(_perk))
            return;
        else
        {
            _perk.perkPrefab.AddComponent<TransitionCard_SD>();
            inventoryPerkList.Add(_perk);
        }
    }
    public void RemovePerkFromInventory(PerkHolder _perkHolder)
    {
        if (!inventoryPerkList.Contains(_perkHolder))
            return;
        inventoryPerkList.Remove(_perkHolder);
    }
}



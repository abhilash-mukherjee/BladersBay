using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeyBlade Inventory", menuName = "Inventory")]
public class BeyBladeInventory : ScriptableObject
{
    [SerializeField] 
    private List<FloatPerkHolder_IncrementedWithPercentage> inventoryPerkList = new List<FloatPerkHolder_IncrementedWithPercentage>();

    public List<FloatPerkHolder_IncrementedWithPercentage> InventoryPerkList { get => inventoryPerkList; }

    public void AddPerkToInventory(FloatPerkHolder_IncrementedWithPercentage _perk)
    {
        if (inventoryPerkList.Contains(_perk))
            return;
        else
        {
            _perk.perkPrefab.AddComponent<TransitionCard_SD>();
            inventoryPerkList.Add(_perk);
        }
    }
    public void RemovePerkFromInventory(FloatPerkHolder_IncrementedWithPercentage _perkHolder)
    {
        if (!inventoryPerkList.Contains(_perkHolder))
            return;
        inventoryPerkList.Remove(_perkHolder);
    }
}



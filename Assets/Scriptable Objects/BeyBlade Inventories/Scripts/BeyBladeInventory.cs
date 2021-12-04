using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeyBlade Inventory", menuName = "BeyBlade System/BeyBlade Inventory")]
public class BeyBladeInventory : ScriptableObject
{
    public List<BeyPartInventorySlot> beyPartSlots = new List<BeyPartInventorySlot>();
    public void AddBeyPart(BeyPartObject _beyPartObject, int _amount)
    {
        foreach(var _slot in beyPartSlots)
        {
            if(_slot.slotTag == _beyPartObject.partTag)
            {
                _slot.AddPart(_beyPartObject, _amount);
                return;
            }
        }
        beyPartSlots.Add(new BeyPartInventorySlot(_beyPartObject, _amount));
    }
}

[System.Serializable]
public class BeyPartInventorySlot
{
    public List<BeyPartObject> beyPartList = new List<BeyPartObject>();
    public int amt;
    public BeyPartTag slotTag;
    public BeyPartInventorySlot(BeyPartObject _beyPartObject, int _amount)
    {
        amt = _amount;
        slotTag = _beyPartObject.partTag;
        beyPartList.Add(_beyPartObject);
    }

    public void AddPart(BeyPartObject _beyPartObject, int _amount)
    {
        amt += _amount;
        beyPartList.Add(_beyPartObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkListManager : MonoBehaviour
{
    [SerializeField]
    BeyBladeInventory inventory;
    [SerializeField]
    private TransitionManager_SD transitionManager;
    private List<PerkHolder> inventoryPerks = new List<PerkHolder>();
    private void Start()
    {
        foreach(var _perk in inventory.InventoryPerkList)
        {
            Instantiate(_perk.perkPrefab, transform);
            inventoryPerks.Add(_perk);
            var _card = _perk.perkPrefab.GetComponent<TransitionCard_SD>();
            transitionManager.AddToCardList(_card);
        }
    }
    private void OnEnable()
    {
        PerkButtonClickManager.OnPerkButtonClicked += RedeemPerk;
    }
    private void OnDisable()
    {
        PerkButtonClickManager.OnPerkButtonClicked -= RedeemPerk;

    }
    public void RedeemPerk(GameObject _gameObject)
    {
        Debug.Log("Redeem Called");
        var _perk = inventoryPerks.Find(p => p.perkPrefab == _gameObject);
        if (_perk != null)
        {
            _perk.RedeemAllPerks();
        }
    }
}

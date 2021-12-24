using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkListManager : MonoBehaviour
{
    [SerializeField]
    BeyBladeInventory inventory;
    [SerializeField]
    private TransitionManager_SD transitionManager;
    private Dictionary<GameObject, PerkHolder> gameObjectPerkMapping = new Dictionary<GameObject, PerkHolder>();
    private void Start()
    {
        foreach(var _perk in inventory.InventoryPerkList)
        {
            var _perkPrefab = Instantiate(_perk.perkPrefab, transform);
            var _card = _perkPrefab.GetComponent<TransitionCard_SD>();
            transitionManager.AddToCardList(_card);
            gameObjectPerkMapping.Add(_perkPrefab, _perk);
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
        if(gameObjectPerkMapping.ContainsKey(_gameObject))
        {
            gameObjectPerkMapping[_gameObject].RedeemAllPerks();
        }
    }
}
